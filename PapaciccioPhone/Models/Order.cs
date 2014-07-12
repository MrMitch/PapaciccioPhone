using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PapaciccioPhone.Models
{
    [DataContract]
    public class Order
    {
        [DataMember(Name = "toppings")]
        public List<string> Toppings { get; set; }

        [DataMember(Name = "sauces")]
        public List<string> Sauces { get; set; }

        [DataMember(Name = "pasta")]
        public string Pasta { get; set; }

        [DataMember(Name = "size")]
        public string Size { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
