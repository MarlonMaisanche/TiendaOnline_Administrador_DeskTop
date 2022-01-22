using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace AppAdminDesktop_Presentación
{
    class API_MEDIA_STORE
    {
        public static dynamic Get(string url)
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
            //myWebRequest.CookieContainer = myCookie;
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myHttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            //Leemos los datos
            string Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
            dynamic data = JsonConvert.DeserializeObject(Datos);
            return data;
        }

        public static dynamic Upload(String url, String ruta)
        {
            
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "multipart/form-data");
            String  extension = Path.GetExtension(ruta);
            String content = GetContentType(extension);
            request.AddFile("file", ruta,contentType: content);
            IRestResponse response = client.Execute(request);
            dynamic datos = JsonConvert.DeserializeObject(response.Content);
            return datos;

        }
        public static string GetContentType(string fileExtension)
        {
            var mimeTypes = new Dictionary<String, String>
            {
                {".bmp", "image/bmp"},
                {".gif", "image/gif"},
                {".jpeg", "image/jpeg"},
                {".jpg", "image/jpeg"},
                {".png", "image/png"},
                {".tif", "image/tiff"},
                {".tiff", "image/tiff"},
                {".doc", "application/msword"},
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                {".pdf", "application/pdf"},
                {".ppt", "application/vnd.ms-powerpoint"},
                {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".xls", "application/vnd.ms-excel"},
                {".csv", "text/csv"},
                {".xml", "text/xml"},
                {".txt", "text/plain"},
                {".zip", "application/zip"},
                {".ogg", "application/ogg"},
                {".mp3", "audio/mpeg"},
                {".wma", "audio/x-ms-wma"},
                {".wav", "audio/x-wav"},
                {".wmv", "audio/x-ms-wmv"},
                {".swf", "application/x-shockwave-flash"},
                {".avi", "video/avi"},
                {".mp4", "video/mp4"},
                {".mpeg", "video/mpeg"},
                {".mpg", "video/mpeg"},
                {".qt", "video/quicktime"}
            };

            return mimeTypes.ContainsKey(fileExtension) ? mimeTypes[fileExtension] : "application/octet-stream";
        }
        public static dynamic Put(string url, string json, string autorizacion = null)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("content-type", "application/json");
       
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                if (autorizacion != null)
                {
                    request.AddHeader("Authorization", autorizacion);
                }
                IRestResponse response = client.Execute(request);
                dynamic datos = JsonConvert.DeserializeObject(response.Content);
                return datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static dynamic GetUsuarioYPass(string url, String usuario, String pass)
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
            //myWebRequest.CookieContainer = myCookie;
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myHttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            //Leemos los datos
            string Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
            dynamic data = JsonConvert.DeserializeObject(Datos);
            return data;
        }
        public static dynamic Post(string url, string json, string autorizacion = null)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                if (autorizacion != null)
                {
                    request.AddHeader("Authorization", autorizacion);
                }
                IRestResponse response = client.Execute(request);
                dynamic datos = JsonConvert.DeserializeObject(response.Content);
                return datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static dynamic Delete(string url, string autorizacion = null)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.DELETE);
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", ParameterType.RequestBody);
                if (autorizacion != null)
                {
                    request.AddHeader("Authorization", autorizacion);
                }
                IRestResponse response = client.Execute(request);
                dynamic datos = JsonConvert.DeserializeObject(response.Content);
                return datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
