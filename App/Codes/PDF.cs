using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
 
using Langben.DAL;
using System.Globalization;
using System.Runtime.Serialization;
using Common;
using iTextSharp.text;

using iTextSharp.text.pdf;
using System.IO;
namespace Models
{
        /// <summary>
    /// 当前登陆者
    /// </summary>
    public class PDF
    {

        /// <summary>
        /// 获取当前登陆人的用户名
        /// </summary>
        /// <returns></returns>
        public static string Create(string path)
        {
            var doc1 = new Document();
            //use a variable to let my code fit across the page...

         
            PdfWriter.GetInstance(doc1, new FileStream(path + ".pdf", FileMode.Create));

            doc1.Open();
            //图片
            
            Image img = Image.GetInstance(path+".png");//HttpRuntime.AppDomainAppPath在一般处理程序中使用，获取网站程序的根目录
            doc1.Add(img);
           
            doc1.Close();
            return string.Empty;
        }
       
    }
     

}

