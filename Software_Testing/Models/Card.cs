using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Testing.Models
{
    public class Card
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public string expertName { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public DateTime dateTime { get; set; }
        public DateTime guessedTime { get; set; }
        //now 
        //passed time since started will printed to the cardDetail
    }
}
