using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExtractorApp_Sample_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********************************");
            Console.WriteLine("*** ExtractorApp Sample API Application");

            Console.WriteLine("***********************************");
            Console.WriteLine("Connect to the Public API");

            // Connect to the public API 
            string sPublicResponse = GetPublicAPIData();
            
            // Display the Response in the console
            Console.WriteLine(sPublicResponse);

            Console.WriteLine("***********************************");
            Console.WriteLine("Connect to Private API");

            // ExtractorApp allows you to secure the API with an Access key
            // An Authorization header is required to access a private API
            string sPrivateResponse = GetPrivateAPIData();

            // Display the Response in the console
            Console.WriteLine(sPrivateResponse);

            Console.WriteLine("----------------=---------------------");
            Console.WriteLine("Complete");
            Console.ReadKey();
        }

        public static string GetPublicAPIData()
        {
            string sresponse = "";
            
            // Connect to the ExtractorApp API
            string _apiToken = "ub3wYyE6fECyo5EMJ8FbYXBxE";

            string sURL = "https://api.extractorapp.com/api/data?token=" + _apiToken;

            WebRequest request = WebRequest.Create(sURL);

            request.Method = "GET";
            request.ContentType = "application/json";

            // Do the request to get the response
            StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
            sresponse = responseReader.ReadToEnd();
            responseReader.Close();
            
            return sresponse;
        }

        public static string GetPrivateAPIData()
        {
            string sresponse = "";

            // Connect to the ExtractorApp API
            string _apiToken = "nW6ExWXoKLsuyjAOqxGBsJnFt";

            string sURL = "https://api.extractorapp.com/api/data?token=" + _apiToken;

            WebRequest request = WebRequest.Create(sURL);

            String username = "test@extractorapp.com";
            String password = "PTtWkNQl4jgdSltF6ApHtMa1";
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            request.Headers.Add("Authorization", "Basic " + encoded);

            request.Method = "GET";
            request.ContentType = "application/json";

            // Do the request to get the response
            StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
            sresponse = responseReader.ReadToEnd();
            responseReader.Close();

            return sresponse;
        }
    }
}
