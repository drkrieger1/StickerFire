using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Models
{
    public class Campaign
    {   
        
       int ID { get; set; }
       int OwnerID { get; set; }
       int Votes { get; set; }
       int Views { get; set; }

       string ImgPath { get; set; }
       string Descrition { get; set; }
       string DenyMessage { get; set; }

       bool Published { get; set; }
       bool Active { get; set; }

        Category Category { get; set; }
        Status Status { get; set; }
        //Votes Voters 
        DateTime Expiration { get; set; }

    }
}
