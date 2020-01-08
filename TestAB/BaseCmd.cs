using BlazorState;
using Celin;
using McMaster.Extensions.CommandLineUtils;
using MediatR;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Test
{
    abstract class BaseCmd
    {
        protected Celin.AIS.Server E1 { get; }
        protected IMediator Mediator { get; }
        protected IStore Store { get; }
        protected ABState State => Store.GetState<ABState>();

        [Option("-j|--json", CommandOptionType.SingleValue, Description = "Output result to Json File")]
        protected (bool HasValue, string Value) JsonFile { get; set; }
        [Option("-d|--delay", CommandOptionType.SingleValue, Description = "Minutes to Delay Execution")]
        protected (bool HasValue, int Value) Minutes { get; set; }
        protected async Task Delay()
        {
            if (Minutes.HasValue)
            {
                var until = DateTime.Now.AddMinutes(Minutes.Value);
                Console.WriteLine("Execute at {0}", until.ToString("t"));
                while (until.CompareTo(DateTime.Now) > 0)
                {
                    Console.Write("Time Remaining: {0}\r", until.Subtract(DateTime.Now).ToString(@"hh\:mm\:ss"));
                    await Task.Delay(TimeSpan.FromSeconds(1d));
                }
            }
        }
        protected void Dump()
        {
            var state = new
            {
                State.ErrorMessage,
                State.Detail,
                State.ABList,
                State.DemoResponse
            };
            var json = JsonSerializer.Serialize(state, new JsonSerializerOptions { WriteIndented = true });
            if (JsonFile.HasValue)
            {
                var fs = File.CreateText($"{JsonFile.Value}.json");
                fs.Write(json);
                fs.Close();
            }
            else
            {
                Console.WriteLine(json);
            }
        }
        public BaseCmd(IStore store, IMediator mediator, Celin.AIS.Server e1)
        {
            Store = store;
            Mediator = mediator;
            E1 = e1;
        }
    }
}
