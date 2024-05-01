using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace geofinder
{
    public class Data
    {
        public string ip { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string postal { get; set; }
        public string timezone { get; set; }    

        public string loc { get; set; }
    }
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "GeoFinder";
            Console.WriteLine("GeoFinder v1.02");

            bool continueSearching = true;

            while (continueSearching)
            {
                Console.Write("Enter the IP address to find the location (or type 'exit' to quit): ");
                string ip = Console.ReadLine();

                if (ip.ToLower() == "exit")
                {
                    continueSearching = false;
                    break;
                }

                string url = $"https://ipinfo.io/{ip}/json";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();

                        Console.WriteLine("[+] Request Successfully Made");

                        string responseData = await response.Content.ReadAsStringAsync();
                        Data ipInfo = JsonConvert.DeserializeObject<Data>(responseData);

                        if (!string.IsNullOrEmpty(ipInfo.loc))
                        {
                            Console.Clear();
                            Console.WriteLine("IP: " + ipInfo.ip);
                            Console.WriteLine("City: " + ipInfo.city);
                            Console.WriteLine("Region: " + ipInfo.region);
                            Console.WriteLine("Country: " + ipInfo.country);
                            Console.WriteLine("Postal: " + ipInfo.postal);
                            Console.WriteLine("Timezone: " + ipInfo.timezone);

                            string[] Coords = ipInfo.loc.Split(',');
                            string googleMapsUrl = $"https://www.google.com/maps/?q={Coords[0]},{Coords[1]}";
                            Console.WriteLine($"Google Maps: {googleMapsUrl}");

                            Process.Start(new ProcessStartInfo
                            {
                                FileName = googleMapsUrl,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            Console.WriteLine("Location coordinates not available.");
                        }
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine($"[!] Error: {e.Message}");
                    }
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}