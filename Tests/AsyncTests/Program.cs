using System.Threading.Tasks;

namespace AsyncTests
{
    public class Program
    {

        public static async Task TestForTest()
        {
            await Test2.Run();
        }

        static void Main(string[] args)
        {
            
            
            // Proper Test2.Run() call
            Test2.Run().Wait();
            
            // Run() waits for the GetStringAsync() inside itself
            Test1.Run();
            
            TestForTest().Wait();
            // Wrong call. Outer method doesn't finish as expected
        }
    }
}
