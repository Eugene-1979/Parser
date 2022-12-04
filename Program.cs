
using HtmlAgilityPack;

namespace Parser
    {
    internal class Program
        {

        /*Сделал асинхронную загрузку с сайта погоды.через Request-Response. */
      /*  Дополнительно для парсинга Html-устпновил HtmlSAgilityPack*/
        static void Main(string[] args)
            {

            while(true)
                {
                Console.WriteLine(@"Введите город
 Lviv
 Kharkiv
 Odesa
 q-Exit
            ");

                string sity = Console.ReadLine();
                if(sity.Equals("q")) return;
                string url = $"https://www.meteoprog.com/ua/weather/{sity}/";

                GetRequest gt = new GetRequest(url);
                try
                    {
  Task t= Parsing(gt,sity);
                    t.Wait();
                    }
                catch(Exception)
                    {
                    Console.WriteLine("No ok");
                 
                    }
             

                }
            

         
            }

        static async Task  Parsing(GetRequest gt,string sity) {

          await  gt.Run();

            var nodes = gt.MyHtml.DocumentNode.SelectNodes("//div[contains(@class,'thumbnail-item__title')]");
            foreach(var item in nodes)
                {
                string date = item.InnerText.Trim();
                HtmlNode nextSibling1 = item.NextSibling.NextSibling;
                string date1 = nextSibling1.InnerText.Trim();

                HtmlNode nextSibling2 = nextSibling1.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling;


                HtmlNode htmlNode1 = nextSibling2.ChildNodes[1];

                HtmlNode htmlNode3 = nextSibling2.ChildNodes[3];
                string tem_min = htmlNode1.InnerText.Trim();
                string tem_max = htmlNode3.InnerText.Trim();

                Console.WriteLine($"В городе {sity}         {date}  {date1} min t{tem_min} max t{tem_max}");

                };
            }
        }
    }