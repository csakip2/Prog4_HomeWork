using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Transporter.ConsoleClient
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNum { get; set; }
        public string EMail { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}\t Name: {Name}\tAddress: {Adress}\tPhoneNum: {PhoneNum}\te-Mail: {EMail}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WAITING.....");
            Console.ReadLine();

            string url = "http://localhost:50643/api/CustomerApi/";

            using (HttpClient client = new HttpClient())
            {
                string json = client.GetStringAsync(url + "all").Result;
                var list = JsonConvert.DeserializeObject<List<Customer>>(json);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();

                Dictionary<string, string> postData;
                string response;

                postData = new Dictionary<string, string>();
                postData.Add(nameof(Customer.Name), "Új Zoli");
                postData.Add(nameof(Customer.Adress), "Új út 123");
                postData.Add(nameof(Customer.PhoneNum), "06301234567");
                postData.Add(nameof(Customer.EMail), "uj.zoli@randommail.org");

                response = client.PostAsync(url + "add", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;

                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("Add: " + response);
                Console.WriteLine("All: ");
                list = JsonConvert.DeserializeObject<List<Customer>>(json);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();

                int custId = list.Single(x => x.Name == "Új Zoli").Id;

                postData = new Dictionary<string, string>();
                postData.Add(nameof(Customer.Id), custId.ToString());
                postData.Add(nameof(Customer.Name), "Uj Zoli");
                postData.Add(nameof(Customer.Adress), "Régi út 123");
                postData.Add(nameof(Customer.PhoneNum), "06301234567");
                postData.Add(nameof(Customer.EMail), "uj.zoli@randommail.org");

                response = client.PostAsync(url + "mod", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;

                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("MOD: " + response);
                Console.WriteLine("All: ");
                list = JsonConvert.DeserializeObject<List<Customer>>(json);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();

                response = client.GetStringAsync(url + "del/" + custId).Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("DEL: " + response);
                Console.WriteLine("All: ");
                list = JsonConvert.DeserializeObject<List<Customer>>(json);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();



            }

        }
    }
}
