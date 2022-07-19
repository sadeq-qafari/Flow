using System.Collections.Generic;

namespace Core.AspNetCore.Operations.Logic.SendMessage.Dto
{
    public class SendMessageInDto
    {
        public string MessageName { get; set; }
        public string Receivers { get; set; }
        public int? TenantId { get; set; }
        public List<string> Params { get; set; }
    }
}
