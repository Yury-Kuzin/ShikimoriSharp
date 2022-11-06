using Microsoft.Extensions.Logging;
using ShikimoriSharp;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using System.Xml.Linq;

namespace Shik
{
    class NUnitLogger<T> : ILogger<T>, IDisposable
    {
        private static Action<string> Output => x => Console.WriteLine($"[{DateTime.UtcNow:h:mm:ss:fff}] {x}");

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            Output(formatter(state, exception));
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => this;

        public void Dispose() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var scope = "user_rates comments topics";
            var access = "iKZfLR35H9y2HS0xS6qTQlTy49N6BoxgoWIKi4HfJOI";
            var refresh = "5Gkb8u8z8ba58H7KVurmURwi9QxQGrZdDEmuiE3kJDA";
            var name = "AloneWolf33";
            var clientId = "wrkQsNk1kDRsUmQDfr0F-OqICuZGnFnKaYt8P6-PXiY";
            var clientSecret = "RMAt0d-Qf6ygtroZEbtm-bbRFhjuj7Ii6QYkAk54aSU";
            var userId = "1009362";
            ShikimoriClient Client;
            long UserId;
            AccessToken Token;
            UserId = Convert.ToInt64(userId);
            Token = new AccessToken
            {
                Access_Token = access,
                RefreshToken = refresh,
                Scope = scope
            };
            var logger = new NUnitLogger<Program>();
            Client = new ShikimoriClient(logger, new ClientSettings(name, clientId, clientSecret));
            try
            {
                Task<Anime[]> animes = Client.Animes.GetAnime(null, Token);
                Anime[] aaa = animes.Result;
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }
    }
}