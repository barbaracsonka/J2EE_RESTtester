using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace J2EE_RESTtester
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadLine();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("rest/api/dictionary/list");
                if (response.IsSuccessStatusCode)
                {
                    Dictionary[] dicts = await response.Content.ReadAsAsync<Dictionary[]>();
                    foreach (var item in dicts)
                    {
                        Console.WriteLine("Dictionary Name: " + item.Name);
                        Console.WriteLine();
                        HttpResponseMessage response_words = await client.GetAsync("rest/api/translations/" + item.Id.ToString());
                        if (response_words.IsSuccessStatusCode)
                        {
                            TranslationClass [] trans = await response_words.Content.ReadAsAsync<TranslationClass[]>();
                            foreach (var item_word in trans)
                            {
                                Console.WriteLine("\t" + item_word.Original + "\t" + item_word.Translation);
                            }
                            Console.WriteLine("----------------------------------------------------------------");
                            Console.WriteLine();
                        }
                    }
                }
                
            }
        }
    }
}
