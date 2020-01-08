using BlazorState;
using MediatR;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Celin
{
    public partial class ABState
    {
        public class ABHandler : ActionHandler<ABAction>
        {
            AIS.Server E1 { get; }
            ABState State => Store.GetState<ABState>();
            public override async Task<Unit> Handle(ABAction aAction, CancellationToken aCancellationToken)
            {
                State.ErrorMessage = string.Empty;
                try
                {
                    var open = await E1.RequestAsync<W01012B.Response>(
                        new AIS.StackFormRequest
                        {
                            action = AIS.StackFormRequest.open,
                            formRequest = new W01012B.Request(aAction.AB)
                        });
                    if (open.fs_P01012_W01012B.data.gridData.summary.records == 1)
                    {
                        State.Detail = await E1.RequestAsync<W01012A.Response>(
                            new ActionRequest(open, new W01012B.SelectRequest(0)));
                        await E1.RequestAsync<object>(new ActionRequest(State.Detail, AIS.StackFormRequest.close));
                    }
                    else
                    {
                        await E1.RequestAsync<object>(new ActionRequest(open, AIS.StackFormRequest.close));
                    }
                }
                catch (AIS.HttpWebException e)
                {
                    State.ErrorMessage = e.ErrorResponse.message ?? e.Message;
                }
                catch (Exception e)
                {
                    State.ErrorMessage = e.Message;
                }

                var handler = State.Changed;
                handler?.Invoke(State, null);

                return Unit.Value;
            }
            public ABHandler(IStore store, AIS.Server e1) : base(store)
            {
                E1 = e1;
            }
        }
        public class ABListHandler : ActionHandler<ABListAction>
        {
            AIS.Server E1 { get; }
            ABState State => Store.GetState<ABState>();
            public override async Task<Unit> Handle(ABListAction aAction, CancellationToken aCancellationToken)
            {
                State.ErrorMessage = string.Empty;
                try
                {
                    var rs = await E1.RequestAsync<W01012B.Response>(new W01012B.Request(aAction.Search));
                    State.ABList = rs.fs_P01012_W01012B.data.gridData.rowset;
                }
                catch (AIS.HttpWebException e)
                {
                    State.ErrorMessage = e.ErrorResponse.message ?? e.Message;
                }
                catch (Exception e)
                {
                    State.ErrorMessage = e.Message;
                }

                var handler = State.Changed;
                handler?.Invoke(State, null);

                return Unit.Value;
            }
            public ABListHandler(IStore store, AIS.Server e1) : base(store)
            {
                E1 = e1;
            }
        }
        public class DemoRequestHandler : ActionHandler<DemoRequestAction>
        {
            static readonly Regex formPat = new Regex(@"^W(\w+)[A-Z]$");
            AIS.Server E1 { get; }
            ABState State => Store.GetState<ABState>();
            public override async Task<Unit> Handle(DemoRequestAction aAction, CancellationToken aCancellationToken)
            {
                var m = formPat.Match(aAction.FormName.ToUpper());
                if (m.Success)
                {
                    State.ErrorMessage = string.Empty;
                    try
                    {
                        State.DemoResponse = await E1.RequestAsync<object>(
                            new AIS.FormRequest
                            {
                                formName = string.Format("P{0}_{1}", m.Groups[1].Value, aAction.FormName.ToUpper()),
                                formServiceDemo = "TRUE"
                            });
                    }
                    catch (Exception e)
                    {
                        State.ErrorMessage = e.Message;
                    }
                }
                else
                {
                    State.ErrorMessage = string.Format("Form Name {0} not recognised!", aAction.FormName);
                }

                return Unit.Value;
            }
            public DemoRequestHandler(IStore store, AIS.Server e1) : base(store)
            {
                E1 = e1;
            }
        }
    }
}
