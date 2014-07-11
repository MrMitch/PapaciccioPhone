using System.Runtime.Serialization;
using PapaciccioPhone.ViewModels;

namespace PapaciccioPhone.Models.ApiResponses
{
    public class CommandResponse : PapaciccioApiResponse
    {
        [DataMember(Name = "command")]
        public CommandViewModel Command { get; set; }
    }
}
