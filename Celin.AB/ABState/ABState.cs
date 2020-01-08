using BlazorState;
using System;
using System.Collections.Generic;

namespace Celin
{
    public partial class ABState : State<ABState>
    {
        public event EventHandler Changed;
        public string ErrorMessage { get; set; }
        public W01012A.Response Detail { get; set; }
        public IEnumerable<W01012B.Row> ABList { get; set; }
        public object DemoResponse { get; set; }
        public override void Initialize() { }
    }
}
