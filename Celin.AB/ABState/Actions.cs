using BlazorState;

namespace Celin
{
    public partial class ABState
    {
        public class ABAction : IAction
        {
            public int AB { get; set; }
        }
        public class ABListAction : IAction
        {
            public string Search { get; set; }
        }
        public class DemoRequestAction : IAction
        {
            public string FormName { get; set; }
        }
    }
}
