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
        /// <summary>
        /// 委托单页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ShowPicture(string id = "1611081523323547325feb23206e5")
        {
            
            ViewBag.Id = id;
            return View();
        }
        /// <summary>
        /// 委托单页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Show(string id = "1611081523323547325feb23206e5")
        {

            ViewBag.Id = id;
            return View();
        }
        public ActionResult ErWeiMa(string id = "1611081523323547325feb23206e5")
        {
            ViewBag.Id = id;
            return View();
        }
        public ActionResult ErWeiMa2(string id = "1611081523323547325feb23206e5")
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPut]
        [ValidateInput(false)]
        public ActionResult QianZi(string id, string PICTURE, string HTMLVALUE)
        {
            var pic = "";
            if (!string.IsNullOrWhiteSpace(PICTURE))
            {
                string path = Server.MapPath("~/up/QianZi/");
                var pathErWeiMa = path + id + ".png";
                using (System.IO.FileStream fs = new System.IO.FileStream(pathErWeiMa, System.IO.FileMode.OpenOrCreate))
                {
                    byte[] byt = Convert.FromBase64String(PICTURE);
                    MemoryStream stream = new MemoryStream(byt);
                    System.IO.BinaryWriter w = new System.IO.BinaryWriter(fs);
                    w.Write(stream.ToArray());
                    fs.Close();
                    stream.Close();
                }
                  pic = "/up/QianZi/" + id + ".png";
            }
            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            SIGN sign = new SIGN();
            sign.PICTURE = pic;
            sign.HTMLVALUE = Server.UrlDecode(HTMLVALUE);//解码
            string currentPerson = GetCurrentPerson();
            sign.CREATETIME = DateTime.Now;
            sign.CREATEPERSON = currentPerson;
            sign.ID = Result.GetNewId();

            m_BLL.EditSTATUS(ref validationErrors, id, sign);
            result.Code = Common.ClientCode.Succeed;
            result.Message = Suggestion.InsertSucceed;

            return Json(result); //提示创建成功
        }
        [HttpPut]
        [ValidateInput(false)]
        public ActionResult QianZi2(string id, string PICTURE, string HTMLVALUE)
        {
            SIGN sign = new SIGN();
         
            sign.ID = Result.GetNewId();
            var pic = "";
            if (!string.IsNullOrWhiteSpace(PICTURE))
            {
                string path = Server.MapPath("~/up/QianZi/");
                var  pathErWeiMa = path + sign.ID + ".png";
                using (System.IO.FileStream fs = new System.IO.FileStream(pathErWeiMa, System.IO.FileMode.OpenOrCreate))
                {
                    byte[] byt = Convert.FromBase64String(PICTURE);
                    MemoryStream stream = new MemoryStream(byt);
                    System.IO.BinaryWriter w = new System.IO.BinaryWriter(fs);
                    w.Write(stream.ToArray());
                    fs.Close();
                    stream.Close();
                }
                pic = "/up/QianZi/" + sign.ID + ".png";
            }
            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            
            sign.PICTURE = pic;
            sign.HTMLVALUE = Server.UrlDecode(HTMLVALUE);//解码
            string currentPerson = GetCurrentPerson();
            sign.CREATETIME = DateTime.Now;
            sign.CREATEPERSON = currentPerson;
          
            sign.UPDATEPERSON = id; 
            result.Code = Common.ClientCode.Succeed;
            result.Message = Suggestion.InsertSucceed;
            m_BLL.EditSTATUS2(ref validationErrors, sign);
            return Json(result); //提示创建成功
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
            try
            {
                string currentPerson = GetCurrentPerson();
                if (string.IsNullOrWhiteSpace(entity.ID))
                {
                    List<COMPANY> companylist = m_BLL2.GetByParam(null, "asc", "ID", "COMPANYNAME&" + entity.INSPECTION_ENTERPRISE + "");
                    List<COMPANY> companylist2 = m_BLL2.GetByParam(null, "asc", "ID", "COMPANYNAME&" + entity.CERTIFICATE_ENTERPRISE + "");


                    foreach (var item in companylist)
                    {
                        if (item.COMPANY2 != null)
                        {
                            entity.INSPECTION_ENTERPRISEHELLD = item.COMPANY2.COMPANYNAME;
                            break;
                        }
                    }
                    foreach (var item in companylist2)
                    {
                        if (item.COMPANY2 != null)
                        {
                            entity.CERTIFICATE_ENTERPRISEHELLD = item.COMPANY2.COMPANYNAME;
                            break;
                        }
                    }
                    string ORDER_NUMBER = m_BLL.GetORDER_NUMBER(ref validationErrors);
                    var order = ORDER_NUMBER.Split('*');// DC2016001 * 1 * 2016
                    entity.ORDER_STATUS = Common.ORDER_STATUS_INFORMATION.保存.ToString();
                    var ms = new System.IO.MemoryStream();
                    entity.CREATETIME = DateTime.Now;
                    entity.CREATEPERSON = currentPerson;
                    entity.ID = Result.GetNewId();

                    entity.ORDER_NUMBER = order[0].ToString();
                    entity.ORSERIALNUMBER = Convert.ToDecimal(order[1]);
                    entity.ORYEARS = order[2].ToString();

                    entity.ORDER_STATUS = Common.ORDER_STATUS_INFORMATION.保存.ToString();

                    string path = Server.MapPath("~/up/ErWeiMa/");
                    foreach (var item in entity.APPLIANCE_DETAIL_INFORMATION)
                    {
                        item.ID = Result.GetNewId();
                        item.CREATETIME = DateTime.Now;
                        item.CREATEPERSON = currentPerson;
                        item.BAR_CODE_NUM = item.ID;
                        //二维码生成
                        ErrorCorrectionLevel Ecl = ErrorCorrectionLevel.M; //误差校正水平   
                        string Content = item.ID;//待编码内容  
                        QuietZoneModules QuietZones = QuietZoneModules.Two;  //空白区域   
                        int ModuleSize = 3;//大小  
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

                        //System.IO.FileStream fs = new System.IO.FileStream(pathErWeiMa, System.IO.FileMode.OpenOrCreate);


                        //System.IO.BinaryWriter w = new System.IO.BinaryWriter(fs);
                        #region 二维码加字
                        System.IO.FileStream fss = new System.IO.FileStream(Server.MapPath("~/up/moban.png"), System.IO.FileMode.OpenOrCreate);
                        int filelength = 0;
                        filelength = (int)fss.Length; //获得文件长度 
                        Byte[] image = new Byte[filelength]; //建立一个字节数组 
                        fss.Read(image, 0, filelength); //按字节流读取 
                        System.Drawing.Image imag = System.Drawing.Image.FromStream(fss);
                        //System.Drawing.Image Image = System.Drawing.Image.FromStream(ms);
                        Graphics g = null;
                        g = Graphics.FromImage(imag);
                        string xinghao = item.FACTORY_NUM;//需要写入的字
                        //string xinghao = "123456789abcd";//需要写入的字
                        int w = imag.Width;
                        int h = imag.Height;
                        int y = 0;
                        int x = 380;
                        for (int i = 0; i < xinghao.Length; i++)
                        {
                            if (x > w)
                            {
                                result.Code = Common.ClientCode.Fail;
                                result.Message = "内容太多二维码生成失败！";
                                return Json(result);
                            }
                            else
                            {
                                if (i % 6 == 0)
                                {
                                    x = x + 50;
                                    y = 0;
                                    y = y + 45;
                                    g.DrawString(xinghao[i].ToString(), new Font("宋体", 14), Brushes.Red, new PointF(x, y));//x:值越大越靠右；y：值越小越靠上

                                }
                                else
                                {
                                    y = y + 45;
                                    g.DrawString(xinghao[i].ToString(), new Font("宋体", 14), Brushes.Red, new PointF(x, y));//x:值越大越靠右；y：值越小越靠上
                                }
                            }

                        }
                        System.Drawing.Image ig = CombinImage(imag, ms);
                        fss.Close();
                        TuPanBaoCun(ig, pathErWeiMa);
                        //生成pdf
                        //图片
                        //Image image = Image.GetInstance(imagePath);
                        //cell = new PdfPCell(image, true);
                        //table.AddCell(cell);
                        PDF.Create(path + item.ID);
                        #endregion

                        //w.Write(ms.ToArray());
                        //fs.Close();
                        //器具明细信息_承接实验室表添加数据
                        foreach (var it in item.UNDERTAKE_LABORATORYID.TrimEnd(',').Split(','))
                        {
                            item.APPLIANCE_LABORATORY.Add(new APPLIANCE_LABORATORY()
                            {
                                ID = Result.GetNewId(),
                                UNDERTAKE_LABORATORYID = it,
                                ORDER_STATUS = Common.ORDER_STATUS.保存.ToString(),
                                EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.保存.GetHashCode().ToString(),
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


                result.Code = Common.ClientCode.FindNull;
                result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 
            }
            catch (Exception lastError)
            {

                ExceptionsHander.WriteExceptions(lastError);//将异常写入数据库
            }
            return Json(result);

        }
        /// <summary>
        /// 调用此函数后使此两种图片合并，类似相册，有个
        /// 背景图，中间贴自己的目标图片
        /// </summary>
        /// <param name="sourceImg">粘贴的源图片</param>
        /// <param name="destImg">粘贴的目标图片</param>
        public static Image CombinImage(Image sourceImg, MemoryStream destImg)
        {
            Image imgBack = sourceImg;     //相框图片 模板图片
            Image img = System.Drawing.Image.FromStream(destImg);        //照片图片 二维码
            //从指定的System.Drawing.Image创建新的System.Drawing.Graphics       
            Graphics g = Graphics.FromImage(imgBack);
            //g.DrawImage(imgBack, 0, 0, 148, 124);      // g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);
            //g.FillRectangle(System.Drawing.Brushes.Black, -50, -50, (int)212, ((int)203));//相片四周刷一层黑色边框，这里没有，需要调尺寸
            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);

            int x = 30;
            int y = 30;
            int w = imgBack.Width - 200;
            int h = imgBack.Height - 100;
            g.DrawImage(img, x, y, w, h);
            GC.Collect();
            //string saveImagePath = @"D:\shiyanshi\App\up\sss.png";
            ////save new image to file system.
            //imgBack.Save(saveImagePath, ImageFormat.Png);
            return imgBack;
        }

        /// <summary>
        /// 编码器的函数
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        ImageCodecInfo GetEncoderInfo(String mimeType)

        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        /// <summary>
        /// 图片保存
        /// </summary>
        /// <param name="TP"></param>
        /// <param name="pathErWeiMa"></param>
        public void TuPanBaoCun(Image TP, string pathErWeiMa)
        {
            ImageCodecInfo myImageCodecInfo;
            //获得JPEG格式的编码器
            myImageCodecInfo = GetEncoderInfo("image/jpeg");

            //设置图像质量
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            // for the Quality parameter category.
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            // EncoderParameter object in the array.
            myEncoderParameters = new EncoderParameters(1);
            //设置质量 数字越大质量越好，但是到了一定程度质量就不会增加了，MSDN上没有给范围，只说是32为非负整数
            myEncoderParameter = new EncoderParameter(myEncoder, 100L);

            myEncoderParameters.Param[0] = myEncoderParameter;
            TP.Save(pathErWeiMa, myImageCodecInfo, myEncoderParameters);
        }


        public ActionResult Createto(string id)
        {

            return View();
        }

        /// <summary>
        /// 查看委托单
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ORDER_TASK_INFORMATION ont = m_BLL.GetById(id);
            var data = (from f in ont.SIGN.AsQueryable()
                       orderby f.CREATETIME
                       select f).FirstOrDefault();
            if (data!=null)
            {
                ViewBag.HTML = data.HTMLVALUE;
                ViewBag.Img = data.PICTURE;
            }
                
          
            return View();
        }
        IBLL.IORDER_TASK_INFORMATIONBLL m_BLL;
        IBLL.ICOMPANYBLL m_BLL2;

        ValidationErrors validationErrors = new ValidationErrors();

        public ORDER_TASK_INFORMATIONController()
            : this(new ORDER_TASK_INFORMATIONBLL(), new COMPANYBLL()) { }

        public ORDER_TASK_INFORMATIONController(ORDER_TASK_INFORMATIONBLL bll, COMPANYBLL bll2)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
        }

    }
}


