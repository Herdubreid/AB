using BlazorState;
using Celin;
using McMaster.Extensions.CommandLineUtils;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Test
{
    [Subcommand(typeof(ABList))]
    [Subcommand(typeof(DefCmd))]
    class Cmd
    {
        [Command("list", Description = "List Address Book")]
        class ABList : BaseCmd
        {
            async Task OnExecuteAsync()
            {
                await E1.AuthenticateAsync();
                
                string search = Prompt.GetString("Enter Search String:");
                while (!string.IsNullOrEmpty(search))
                {
                    await Delay();

                    if (int.TryParse(search, out var ab))
                    {
                        await Mediator.Send(new ABState.ABAction { AB = ab });
                    }
                    else
                    {
                        await Mediator.Send(new ABState.ABListAction { Search = search });
                    }

                    Dump();

                    search = Prompt.GetString("Enter Search String:");
                }
            }
            public ABList(IStore store, IMediator mediator, Celin.AIS.Server e1) : base(store, mediator, e1) { }
        }
        [Command("def", Description = "Get Form Definition")]
        class DefCmd : BaseCmd
        {
            [Argument(0, Description = "Form Name")]
            [Required]
            string FormName { get; set; }
            async Task OnExecuteAsync()
            {
                await E1.AuthenticateAsync();

                await Delay();

                await Mediator.Send(new ABState.DemoRequestAction { FormName = FormName });

                Dump();
            }
            public DefCmd(IStore store, IMediator mediator, Celin.AIS.Server e1) : base(store, mediator, e1) { }
        }
    }
}
