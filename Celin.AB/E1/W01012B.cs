using System.Linq;

namespace Celin.W01012B
{
    public class Row
    {
        public string z_AT1_50 { get; set; }
        public int z_AN8_19 { get; set; }
        public string z_TAX_51 { get; set; }
        public string z_ALKY_48 { get; set; }
        public string z_SIC_49 { get; set; }
        public string z_ALPH_20 { get; set; }
    }
    public class Response : AIS.FormResponse
    {
        public AIS.Form<AIS.FormData<Row>> fs_P01012_W01012B { get; set; }
    }
    public class SelectRequest : AIS.ActionRequest
    {
        public SelectRequest(int row)
        {
            formActions = new AIS.Action[]
            {
                new AIS.FormAction
                {
                    command = AIS.FormAction.SelectRow,
                    controlID = $"1.{row}"
                },
                new AIS.FormAction
                {
                    command = AIS.FormAction.DoAction,
                    controlID = "14"
                }
            }
            .ToList();
        }
    }
    public class Request : AIS.FormRequest
    {
        public Request(int ab) : this()
        {
            query = new AIS.Query
            {
                matchType = AIS.Query.MATCH_ALL,
                autoFind = true,
                condition = new AIS.Condition[]
                {
                    new AIS.Condition
                    {
                        controlId = "1[19]",
                        @operator = AIS.Condition.EQUAL,
                        value = new AIS.Value[]
                        {
                            new AIS.Value
                            {
                                content = ab.ToString(),
                                specialValueId = AIS.Value.LITERAL
                            }
                        }
                    }
                }
                .ToList()
            };
        }
        public Request(string search) : this()
        {
            query = new AIS.Query
            {
                matchType = AIS.Query.MATCH_ALL,
                autoFind = true,
                condition = search
                    .Trim()
                    .Split(' ')
                    .Select(s => new AIS.Condition
                    {
                        controlId = "1[20]",
                        @operator = AIS.Condition.STR_CONTAIN,
                        value = new AIS.Value[]
                        {
                            new AIS.Value
                            {
                                content = s,
                                specialValueId = AIS.Value.LITERAL
                            }
                        }
                    })
                    .ToList()
            };
        }
        public Request()
        {
            outputType = "GRID_DATA";
            formName = "P01012_W01012B";
            returnControlIDs = "1";
        }
    }
}
