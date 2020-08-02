using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Linq;
using System.Threading.Tasks;


namespace AvidTest
{
    class AsyncAwaitExample
    {


        private async void ExecuteAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            RunDownload();
            watch.Stop();
            Console.WriteLine($"Total Execution time : {watch.ElapsedMilliseconds}");
            watch.Start();

            await RunDownloadAsync();
            watch.Stop();
            Console.WriteLine($"Total Execution time : {watch.ElapsedMilliseconds}");
            watch.Start();

            await RunDownloadParallelAsync();
            watch.Stop();
            Console.WriteLine($"Total Execution time : {watch.ElapsedMilliseconds}");
            watch.Start();

        }
        //Sync (lock all the processes) 
        public void RunDownload()
        {
            List<int> list = new List<int>();
            foreach (var item in list)
            {
                var results = DownloadWebsite("Hello");
                Console.WriteLine(results);
            }
        }
        //ParallelSync (lock all the processes) 
        public void RunDownloadParallel()
        {
            List<string> list = new List<string>();
            List<string> output = new List<string>();
            Parallel.ForEach<string>(list, (site) =>
            {
                WebClient clinet = new WebClient();
                output.Add(clinet.DownloadString(site));
            });
            Console.WriteLine(output);
        }
        //Async
        public async Task RunDownloadAsync()
        {
            List<int> list = new List<int>();
            foreach (var item in list)
            {
                //This wait untill this donload finished befor going to next one 
                var results = await Task.Run(() => DownloadWebsite("Hello"));
                Console.WriteLine(results);
            }
        }
        //ParallelAsync
        public async Task RunDownloadParallelAsync()
        {
            List<string> Sites = new List<string>();
            List<Task<string>> tasks = new List<Task<string>>();
            foreach (var item in Sites)
            {
                tasks.Add(Task.Run(() => DownloadWebsite(item)));
                //OR
                tasks.Add(DownloadWebsiteAsync(item));
            }
            var results = await Task.WhenAll(tasks);
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        private string DownloadWebsite(string websiteURl)
        {
            WebClient clinet = new WebClient();
            var output = clinet.DownloadString(websiteURl);
            return output;
        }

        private async Task<string> DownloadWebsiteAsync(string websiteURl)
        {
            WebClient clinet = new WebClient();
            var output = await clinet.DownloadStringTaskAsync(websiteURl);
            return output;
        }
    }
}
