using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using Langben.App.Models;
using System.IO;
using System.Drawing;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Controls;
using System.Drawing.Imaging;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 委托单信息
    /// </summary>
    public class ORDER_TASK_INFORMATIONController : BaseController
    {
        public ActionResult ErWeiMa(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        public ActionResult Show(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPut]
        public ActionResult QianZi(string id, string s)
        {
            byte[] byt = Convert.FromBase64String(s);
            Stream stream = new MemoryStream(byt);


            return View();
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexSef()
        {

            return View();
        }

        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Details(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(string id)
        {

            return View();
        }
        /// <summary>
        /// 保存发送-如果已经存在，判断状态，
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(ORDER_TASK_INFORMATION entity)
        {

            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            {
                string currentPerson = GetCurrentPerson();
                if (string.IsNullOrWhiteSpace(entity.ID))
                {
                    entity.CREATETIME = DateTime.Now;
                    entity.CREATEPERSON = currentPerson;
                    entity.ID = Result.GetNewId();
                    entity.ORDER_STATUS = Common.ORDER_STATUS_INFORMATION.已分配.ToString();
                    var ms = new System.IO.MemoryStream();
                    string path = Server.MapPath("~/up/ErWeiMa/");
                    foreach (var item in entity.APPLIANCE_DETAIL_INFORMATION)
                    {
                        item.ID = Result.GetNewId();
                        item.CREATETIME = DateTime.Now;
                        item.CREATEPERSON = currentPerson;
                        //二维码生成
                        ErrorCorrectionLevel Ecl = ErrorCorrectionLevel.M; //误差校正水平   
                        string Content = item.ID;//待编码内容  
                        QuietZoneModules QuietZones = QuietZoneModules.Two;  //空白区域   
                        int ModuleSize = 12;//大小  
                        var encoder = new QrEncoder(Ecl);
                        QrCode qr;
                        if (encoder.TryEncode(Content, out qr))//对内容进行编码，并保存生成的矩阵  
                        {
                            Renderer r = new Renderer(ModuleSize);
                            r.QuietZoneModules = QuietZones;
                            r.WriteToStream(qr.Matrix, ms, ImageFormat.Png);

                        }
                        
                       
                        //QRCodeHelper.GetQRCode(item.ID, ms);
                        var pathErWeiMa = path + item.ID + ".png";
                        System.IO.FileStream fs = new System.IO.FileStream(pathErWeiMa, System.IO.FileMode.OpenOrCreate);

                        //Bitmap bmp = new Bitmap(fs);
                        //Graphics g = Graphics.FromImage(bmp);
                        //String str = item.APPLIANCE_NAME;
                        //Font font = new Font("宋体", 8);
                        //SolidBrush sbrush = new SolidBrush(Color.Black);
                        //g.DrawString(str, font, sbrush, new PointF(10, 10));
                       
                        //bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                        System.IO.BinaryWriter w = new System.IO.BinaryWriter(fs);
                        w.Write(ms.ToArray());
                        fs.Close();
                        //器具明细信息_承接实验室表添加数据
                        foreach (var it in item.UNDERTAKE_LABORATORYID.TrimEnd(',').Split(','))
                        {
                            item.APPLIANCE_LABORATORY.Add(new APPLIANCE_LABORATORY()
                            {
                                ID = Result.GetNewId(),
                                UNDERTAKE_LABORATORYID = it,
                                ORDER_STATUS = Common.ORDER_STATUS.已分配.ToString(),
                                EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.已分配.GetHashCode().ToString(),
                                DISTRIBUTIONPERSON = currentPerson,
                                DISTRIBUTIONTIME = DateTime.Now,
                                CREATEPERSON = currentPerson,
                                CREATETIME = DateTime.Now,
                                ISRECEIVE = Common.ISRECEIVE.是.ToString(),
                                RECYCLING = entity.RECYCLING
                            });
                        }
                    }
                    ms.Close();

                    string returnValue = string.Empty;
                    if (m_BLL.Create(ref validationErrors, entity))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，委托单信息的信息的Id为" + entity.ID, "委托单信息"
                            );//写入日志 
                        result.Code = Common.ClientCode.Succeed;
                        result.Message = Suggestion.InsertSucceed;
                        result.Id = entity.ID;
                        return Json(result); //提示创建成功
                    }
                    else
                    {
                        if (validationErrors != null && validationErrors.Count > 0)
                        {
                            validationErrors.All(a =>
                            {
                                returnValue += a.ErrorMessage;
                                return true;
                            });
                        }
                        LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，委托单信息的信息，" + returnValue, "委托单信息"
                            );//写入日志                      
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.InsertFail + returnValue;
                        return Json(result); //提示插入失败
                    }
                }
                else
                {

                }
            }

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 

            return Json(result);

        }

        public ActionResult Createto(string id)
        {

            return View();
        }

        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        IBLL.IORDER_TASK_INFORMATIONBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public ORDER_TASK_INFORMATIONController()
            : this(new ORDER_TASK_INFORMATIONBLL()) { }

        public ORDER_TASK_INFORMATIONController(ORDER_TASK_INFORMATIONBLL bll)
        {
            m_BLL = bll;
        }

    }
}


