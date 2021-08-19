using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json.Linq;


namespace TZ
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
       
        public static async Task<string> GetFood(string linkoffood)
        {

            HttpResponseMessage response = await client.GetAsync(linkoffood);

            HttpContent content = response.Content;

            string result = await content.ReadAsStringAsync();

            return result;

        }

        static async Task Main(string[] args)
        {
            bool exit = false;

            while (!exit) 
            {
                Console.WriteLine($"Нажмите клавишу 'S' чтобы отправить запрос\nЧтобы выйти нажмите клавишу 'E'");
                
                ConsoleKeyInfo key = new ConsoleKeyInfo();
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        {
                            exit = true;
                            Console.Clear();
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            Console.Clear();
                            var json = await GetFood($"https://tester.consimple.pro/");

                            var options = new JsonSerializerOptions
                            {
                                IncludeFields = true,
                            };
                            var twoList = JsonSerializer.Deserialize<TwoList>(json, options);

                            Console.WriteLine(twoList);
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Выбрана неверная клавиша");
                            break;
                        }
                }
            }
        }



    }
}
