using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Models
{
    public class Campaign
    {
        public int ID { get; set; }
        public int OwnerID { get; set; }
        public int Votes { get; set; }
        public  int Views { get; set; }

        public string ImgPath { get; set; }
        public string Descrition { get; set; }
        public string DenyMessage { get; set; }

        public bool Published { get; set; }
        public bool Active { get; set; }

        public Category Category { get; set; }
        public Status Status { get; set; }
        //Votes Voters 
        public DateTime Expiration { get; set; }

    }
}
