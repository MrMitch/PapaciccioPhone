using System.Runtime.Serialization;

namespace PapaciccioPhone.Models.ApiResponses
{
    public abstract class PapaciccioApiResponse
    {
        [DataMember(Name = "error")]
        public bool Error { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
