using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTests
{
    public static class Test1
    {
        public static async Task Run()
        {
            var task = GetStringAsync();
            Console.WriteLine("Outer Async Method.");
            task.Wait();
        }

        private static async Task GetStringAsync()
        {
            Console.WriteLine("Inner Async Method.");
            var text = await new WebClient().DownloadStringTaskAsync("http://habrahabr.ru");
            Console.WriteLine("Загрузка страницы завершена, начинается обработка...");
        }
    }
}
