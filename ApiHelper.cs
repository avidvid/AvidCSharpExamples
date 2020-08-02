using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AvidTest
{
    //nuget Microsoft.AspNet.WebApi.Client
    public static class ApiHelper
    {
        public static HttpClient ApiClinet { get; set; } = new HttpClient();
        public static void InitializeClient()
        {
            if (ApiClinet==null)
            {
                ApiClinet = new HttpClient();
            }
            //ApiClinet.BaseAddress = new Uri("");
            ApiClinet.DefaultRequestHeaders.Accept.Clear();
            ApiClinet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
    public static class ComicProcessor
    {
        public static async Task<ComicModel> LoadComic(int comicNumber =0)
        {
            string url = "";
            if (comicNumber == 0)
            {
                url = $"https://xkcd.com/info.0.json";
            }
            else
            {
                url = $"https://xkcd.com/{comicNumber}/info.0.json";
            }
            //memory managment, clean up, dispose 
            using (HttpResponseMessage response = await ApiHelper.ApiClinet.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();
                    return comic;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public static async Task LoadImage(int comicNumber = 0)
        {
            var comic = await ComicProcessor.LoadComic(comicNumber);
            var uriSource = new Uri(comic.Img, UriKind.Absolute);
        }
        public class ComicModel
        {
            public int Num { get; set; }
            public string Title { get; set; }
            public string Img { get; set; }
        }
    }
    public static class SunProcessor
    {
        public static async Task<SunModel> LoadSunInformation()
        {
            string url = "https://api.sunrise-sunset.org/json?lat=41.49&lng=-75.53&date=today";
            //memory managment, clean up, dispose 
            using (HttpResponseMessage response = await ApiHelper.ApiClinet.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SunResultModel result = await response.Content.ReadAsAsync<SunResultModel>();
                    return result.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public static async void LoadSunInfo()
        {
            var sunInfo = await SunProcessor.LoadSunInformation();
            Console.WriteLine($"Sunrise is at {sunInfo.Sunrise.ToLocalTime().ToShortDateString()}");
            Console.WriteLine($"Sunset is at {sunInfo.Sunset.ToLocalTime().ToShortDateString()}");
        }
        public class SunResultModel
        {
            public SunModel Results { get; set; }
        }
        public class SunModel
        {
            public DateTime Sunrise { get; set; }
            public DateTime Sunset { get; set; }
        }
    }
}