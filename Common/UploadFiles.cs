using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web;
using System.Globalization;

namespace Common
{
    public class UploadFiles
    {
        /// <summary>
        /// 最后一步上传
        /// </summary>
        /// <param name="strPath">文件的实体路径</param>
        /// <returns></returns>
        public string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
        /// <summary>
        ///用时间生成文件名
        /// </summary>
        /// <returns></returns>
        public string GetFileNameByTime()
        {
            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo);
            return newFileName;
        }
        /// <summary>
        /// 获取文件的扩展名
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetPostfixStr(string filename)
        {
            int start = filename.LastIndexOf(".");
            int length = filename.Length;
            string postfix = filename.Substring(start + 1);
            return postfix;
        }
        /// <summary>
        /// 上传图片之前的逻辑处理
        /// </summary>
        /// <param name="postedFile">路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public string fileSaveAs(HttpPostedFileBase postedFile, string fileName)
        {
            string ramName = fileName.Substring(0, fileName.LastIndexOf('.'));
            string fileExt = GetPostfixStr(fileName); //文件扩展名，不含“.”
            string ramFileName = GetFileNameByTime() + "." + fileExt; //随机文件名
            string dirPath = GetUpLoadPath(); //上传目录相对路径
            string serverFileName = dirPath + ramFileName;
            //物理完整路径                    
            string toFileFullPath = GetMapPath(dirPath);
            //检查有该路径是否就创建
            if (!Directory.Exists(toFileFullPath))
            {
                Directory.CreateDirectory(toFileFullPath);
            }
            try
            {
                postedFile.SaveAs(toFileFullPath + ramFileName);
            }
            catch
            {
                return "{\"jsonrpc\" : \"2.0\", \"result\" : \"上传错误\"}";
            }
            return "{\"jsonrpc\" : \"" + ramName + "\", \"result\" : \"" + serverFileName + "\"}";
        }

        /// <summary>
        /// 上传文档之前的逻辑处理
        /// </summary>
        /// <param name="postedFile">路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public string ReportToUpload(HttpPostedFileBase postedFile, string fileName, int type)
        {
            string ramName = fileName.Substring(0, fileName.LastIndexOf('.'));
            string fileExt = GetPostfixStr(fileName); //文件扩展名，不含“.”
            string ramFileName = GetFileNameByTime() + "." + fileExt; //随机文件名
            string dirPath = GetUpLoadUpload(); //上传目录相对路径
            string serverFileName = dirPath + ramFileName;
            string toFileFullPath = GetMapPath(dirPath);  //物理完整路径          
            int SIZE = postedFile.ContentLength;//文件大小                                              
            if (!Directory.Exists(toFileFullPath)) //检查有该路径是否就创建
            {
                Directory.CreateDirectory(toFileFullPath);
            }
            try
            {
                postedFile.SaveAs(toFileFullPath + ramFileName);
            }
            catch
            {
                // return "{\"Jsonrpc\" : \"2.0\", \"Result\" : \"上传错误\"}";
                return "{\"NAME\":\"null\"}";
            }
            if (type == 0)
            {
                //string PATH2 = serverFileName.Substring(1, serverFileName.Length - 1);
               //return "{\"NAME2\":\"" + ramFileName + "\",\"SIZE2\":\" "+ SIZE + "\",\"PATH2\":\"" + PATH2 + "\",\"FULLPATH2\":\"" + toFileFullPath + ramFileName + "\",\"SUFFIX2\":\"" + fileExt + "\",";
                return "{NAME2*" + fileName + ",SIZE2*" + SIZE + ",PATH2*" + ramFileName + ",FULLPATH2*" + toFileFullPath + ramFileName + ",SUFFIX2*" + fileExt + ",";
            }
            else if (type == 1)
            {
               //string PATH = serverFileName.Substring(1, serverFileName.Length - 1);
                return "NAME*" + fileName + ",SIZE*" + SIZE + ",PATH*" + ramFileName + ",FULLPATH*" + toFileFullPath + ramFileName + ",SUFFIX*" + fileExt + "}";
               // return "\"NAME\":\"" + ramFileName + "\",\"SIZE\":\"" + SIZE + "\",\"PATH\":\"" + PATH + "\",\"FULLPATH\":\"" + toFileFullPath + ramFileName + "\",\"SUFFIX\":\"" + fileExt + "\"}";
            }
            return null;
        }
        /// <summary>
        /// 返回上传目录相对路径
        /// </summary>
        /// <param name="fileName">上传文件名</param>
        private string GetUpLoadPath()
        {
            string path = "/up/image/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            return path;
        }

        /// <summary>
        /// 返回上传目录相对路径（文档上传）
        /// </summary>
        private string GetUpLoadUpload()
        {
            string path = "/up/TheReport/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            return path;
        }
        /// <summary>
        /// 是否为图片文件
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        private bool IsImage(string _fileExt)
        {
            ArrayList al = new ArrayList();
            al.Add("bmp");
            al.Add("jpeg");
            al.Add("jpg");
            al.Add("gif");
            al.Add("png");
            if (al.Contains(_fileExt.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}
