namespace Test
{
    internal class Program
    {
        private const string URL = "https://docs.microsoft.com/en-us/dotnet/csharp";
        static void Main(string[] args)
        {
            DoSynchronousWork();
            var someTask = DoSomethingAsync();
            DoSynchronousWorkAfterAwait();
            someTask.Wait();
            Console.Write("\nPress any key to terminate...");
            Console.ReadLine(); 
        }

        public static void DoSynchronousWork()
        {
            Console.WriteLine("Doing some work synchronously");
        }

        static async Task DoSomethingAsync()
        {
            Console.WriteLine("Async task has started...");
            await GetStringAsync();
        }

        static async Task GetStringAsync()
        {
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("Awaiting the result of GetStringAsync of HTTP client...");
                string result = await httpClient.GetStringAsync(URL);
                Console.WriteLine("The awaited task has completed. Let's get the content length..");
                Console.WriteLine("The length of http Get for {URL}");
                Console.WriteLine($"{result.Length} character");

            }
        }

        static void DoSynchronousWorkAfterAwait()
        {
            Console.WriteLine("While waiting for the async task to finish, we can do some unrelated...");
            for (var i = 0; i <= 5; i++)
            {
                for (var j = 0; j <= 5; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine(); 
            }
        }
    }
}