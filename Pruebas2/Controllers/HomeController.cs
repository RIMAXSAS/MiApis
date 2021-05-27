using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Pruebas2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";

            //DateTime date = DateTime.Now;
            //string dateFormatted = date.ToString("yyyy-MM-dd");
            //string Result = dateFormatted;
            //var url = $"https://openexchangerates.org/api/historical/" + dateFormatted + ".json?app_id=e5aeb295dd7644e690fa7d128fe7fccb&base=USD&symbols=COP";
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //request.Accept = "application/json";
            //try
            //{
            //    using (WebResponse response = request.GetResponse())
            //    {
            //        using (Stream strReader = response.GetResponseStream())
            //        {
            //            if (strReader == null) ;
            //            using (StreamReader objReader = new StreamReader(strReader))
            //            {
            //                string responseBody = objReader.ReadToEnd();
            //                //JArray resp = JArray.Parse(responseBody);

            //                JObject jObject = JObject.Parse(responseBody);

            //                //ArrayList myAL = new ArrayList();
            //                //Categorias categorias = new Categorias();
            //                //List<Categorias> c = new List<Categorias>();
            //                Result = jObject["rates"]["COP"].ToString();
            //                //jObject = JObject.Parse(Result);
            //                //Result = jObject.GetValue("COP").ToString();

            //                /*foreach (JObject content in resp.Children<JObject>())
            //                 {*/

            //                /*c.Add(new Categorias() {
            //                    Name = content["Name"].ToString(),
            //                    CategoryId = content["CategoryId"].ToString(),
            //                    FieldId = content["FieldId"].ToString(),
            //                    IsActive = content["IsActive"].ToString(),
            //                    IsStockKeepingUnit = content["IsStockKeepingUnit"].ToString()
            //                });*/
            //                // Result = Newtonsoft.Json.JsonConvert.SerializeObject(content["rates"].ToString());
            //                //}

            //                //return null;
            //            }
            //        }
            //    }
            //}
            //catch (WebException ex)
            //{
            //    // Handle error
            //    //return "";
            //}

            //DateTime date = DateTime.Now;
            //string dateFormatted = date.ToString("yyyy-MM-dd");
            //string Result = dateFormatted;
            //var url = $"https://trm-colombia.vercel.app/?date="+ dateFormatted +"";
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //request.Accept = "application/json";
            //try
            //{
            //    using (WebResponse response = request.GetResponse())
            //    {
            //        using (Stream strReader = response.GetResponseStream())
            //        {
            //            if (strReader == null) ;
            //            using (StreamReader objReader = new StreamReader(strReader))
            //            {
            //                string responseBody = objReader.ReadToEnd();
            //                //JArray resp = JArray.Parse(responseBody);

            //                JObject jObject = JObject.Parse(responseBody);

            //                //ArrayList myAL = new ArrayList();
            //                //Categorias categorias = new Categorias();
            //                //List<Categorias> c = new List<Categorias>();
            //                Result = jObject["data"]["value"].ToString();
            //                string r = Result == "1"  ? "2" : "1";
            //                //jObject = JObject.Parse(Result);
            //                //Result = jObject.GetValue("COP").ToString();

            //                /*foreach (JObject content in resp.Children<JObject>())
            //                 {*/

            //                /*c.Add(new Categorias() {
            //                    Name = content["Name"].ToString(),
            //                    CategoryId = content["CategoryId"].ToString(),
            //                    FieldId = content["FieldId"].ToString(),
            //                    IsActive = content["IsActive"].ToString(),
            //                    IsStockKeepingUnit = content["IsStockKeepingUnit"].ToString()
            //                });*/
            //                // Result = Newtonsoft.Json.JsonConvert.SerializeObject(content["rates"].ToString());
            //                //}

            //                //return null;
            //            }
            //        }
            //    }
            //}
            //catch (WebException ex)
            //{
            //    // Handle error
            //    //return "";
            //}
            //segunda forma cosumir API
            //DateTime date = DateTime.Now;
            //string dateFormatted = date.ToString("yyyy-MM-dd");
            //string Result = dateFormatted;
            //var url = $"https://www.datos.gov.co/resource/mcec-87by.json?vigenciadesde=" + dateFormatted + "";
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //request.Accept = "application/json";
            //try
            //{
            //    using (WebResponse response = request.GetResponse())
            //    {
            //        using (Stream strReader = response.GetResponseStream())
            //        {
            //            if (strReader == null) ;
            //            using (StreamReader objReader = new StreamReader(strReader))
            //            {
            //                string responseBody = objReader.ReadToEnd();
            //                JArray resp = JArray.Parse(responseBody);
            //                Result = resp[0]["valor"].ToString();
                            
            //            }
            //        }
            //    }
            //}
            //catch (WebException ex)
            //{
            //    // Handle error
            //    //return "";
            //}

           
             //3da forma de invocar API
            DateTime date = DateTime.Now;
            string dateFormatted = date.ToString("yyyy-MM-dd");
            string Result = dateFormatted;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://trm-colombia.vercel.app/");
            var request = httpClient.GetAsync("?date=" + dateFormatted + "").Result;

            try
            {
                if(request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    dynamic tipTable = JsonConvert.DeserializeObject(resultString);
                    string r = tipTable["data"].value;
                }
            }
            catch (WebException ex)
            {
                // Handle error
                //return "";
            } 
             
              
           


            return View();
        }
    }
}
