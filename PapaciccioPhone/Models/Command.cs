using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PapaciccioPhone.Models
{
    [DataContract]
    public class Command
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "date")]
        public int Timestamp { get; set; }

        [DataMember(Name = "sauces")]
        public List<string> Sauces { get; set; }

        [DataMember(Name = "toppings")]
        public List<string> Toppings { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
