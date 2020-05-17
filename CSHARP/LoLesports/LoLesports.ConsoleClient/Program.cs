using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LoLesports.ConsoleClient
{
    public class Jatekos
    {
        public string Felhasznalonev { get; set; }
        public string Vezeteknev { get; set; }
        public string Keresztnev { get; set; }
        public Nullable<int> Eletkor { get; set; }
        public string Pozicio { get; set; }
        public string Nemzetiseg { get; set; }
        public string Csapatnev { get; set; }

        public override string ToString()
        {
            return $"Felhasználónév={Felhasznalonev}\t" +
                $"Vezetéknév ={ Vezeteknev}\t" +
                $"Keresztnév = { Keresztnev }\t" +
                $"Életkor = { Eletkor }\t" +
                $"Pozíció = { Pozicio }\t" +
                $"Nemzetiség = { Nemzetiseg }\t" +
                $"Csapatnév = { Csapatnev }";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WAITING...");
            Console.ReadLine();

            string url = "http://localhost:61451/api/JatekosApi/";
            using (HttpClient client = new HttpClient())
            {
                string json = client.GetStringAsync(url + "all").Result;
                var list = JsonConvert.DeserializeObject<List<Jatekos>>(json);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();

                Dictionary<string, string> postData;
                string response;

                postData = new Dictionary<string, string>();
                postData.Add(nameof(Jatekos.Felhasznalonev), "YozsiMester");
                postData.Add(nameof(Jatekos.Vezeteknev), "Gyerek");
                postData.Add(nameof(Jatekos.Keresztnev), "Jóska");
                postData.Add(nameof(Jatekos.Eletkor), "12");
                postData.Add(nameof(Jatekos.Pozicio), "MID");
                postData.Add(nameof(Jatekos.Nemzetiseg), "Hungary");
                postData.Add(nameof(Jatekos.Csapatnev), "G2 Esports");
                response = client.PostAsync(url + "add", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("ADD" + response);
                Console.WriteLine("ALL" + json);
                Console.ReadLine();

                string felhasznalonev = JsonConvert.DeserializeObject<List<Jatekos>>(json).Single(x => x.Felhasznalonev == "YozsiMester").Felhasznalonev;
                postData = new Dictionary<string, string>();
                postData.Add(nameof(Jatekos.Felhasznalonev), "YozsiMester");         
                postData.Add(nameof(Jatekos.Vezeteknev), "Pista");
                postData.Add(nameof(Jatekos.Keresztnev), "bácsi");
                postData.Add(nameof(Jatekos.Eletkor), "84");
                postData.Add(nameof(Jatekos.Pozicio), "MID");
                postData.Add(nameof(Jatekos.Nemzetiseg), "Hungary");
                postData.Add(nameof(Jatekos.Csapatnev), "G2 Esports");
                response = client.PostAsync(url + "mod", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("MOD" + response);
                Console.WriteLine("ALL" + json);
                Console.ReadLine();

                //response = client.GetStringAsync(url + "del/" + felhasznalonev).Result;  // stringet nem tudja konvertálni
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("DEL" + response);
                Console.WriteLine("ALL" + json);
                Console.ReadLine();
            }

        }
    }
}
