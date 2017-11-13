using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Models
{
    public class Campaign
    {
        int ID { get; set; }

        int OwnerID { get; set; }
        string ImgPath { get; set; }
        string Descrition { get; set; }
        bool Published { get; set; }
        //enum category {get; set; }
        int Votes { get; set; }
        int Views { get; set; }
        //Votes Voters 
        string DenyMessage { get; set; }
        bool Active { get; set; }
        DateTime Expiration { get; set; }

    }
}
