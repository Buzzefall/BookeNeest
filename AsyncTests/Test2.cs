using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTests
{
    public static class Test2
    {
        // Run() calls GetStringAsync() => GetStringAsync() is awaiting for habr source code
        // => yeilding control back to Run()
        // => but Run() already is awaiting for GetStringAsync() to return 
        // => hence, Run() is yeilding control back to it's caller - Main()
        // => the program finishes, if Main() won't call Run() like Test2.Run().Wait() or await for Run() to complete;

        public static async Task Run()
        {
            var text = await GetStringAsync();
            Console.WriteLine("Outer async method.");
            Console.WriteLine("Загрузка страницы завершена, начинается обработка...");
        }
        private static async Task<string> GetStringAsync()
        {
            Console.WriteLine("Inner async method.");
            var result = await new WebClient().DownloadStringTaskAsync("http://habrahabr.ru");
            Console.WriteLine("Загрузка страницы завершена, начинается обработка...");
            return result;
        }
    }
}
