using System.Runtime.Serialization;

namespace PapaciccioPhone.Models.ApiResponses
{
    public class CommandResponse : PapaciccioApiResponse
    {
        [DataMember(Name = "command")]
        public Command Command { get; set; }
    }
}
