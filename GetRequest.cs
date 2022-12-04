
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Parser
    {
    internal class GetRequest
        {
        HttpWebRequest _request;
        string _url;
        public string Responce { get; set; }
        public Stream MyStream { get; set; }
        public HtmlDocument MyHtml { get; set; }
        public GetRequest(string url)
            {
            _url = url;
            }

            /*Сделал асинхронную загрузку с сайта погоды.через Request-Response. */ 

        public async Task Run() {
            _request = (HttpWebRequest)WebRequest.Create(_url);
            _request.Method = "Get";
            try
                {
 WebResponse response = await _request.GetResponseAsync();
            var stream = response.GetResponseStream();
               MyStream = stream;
                MyHtml = new HtmlDocument();
                MyHtml.Load(MyStream);
            if(stream != null) Responce = new StreamReader(stream).ReadToEnd();
                }
            catch(Exception)
                {

                Console.WriteLine("Вы ввели неправильно город");
                throw new ArgumentException();
                }
          
                 

        }

        }
    }
