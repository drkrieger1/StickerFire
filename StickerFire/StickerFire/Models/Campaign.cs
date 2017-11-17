using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Models
{
    //Primary application model. Defines individual sticker campaigns.
    public class Campaign
    {
        //Unique Id
        public int ID { get; set; }

        public string OwnerID { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Votes { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Views { get; set; }

        [Required]
        public string Title { get; set; }

        public string ImgPath { get; set; }

        [Required]
        public string Description { get; set; }

        public string DenyMessage { get; set; }

        public bool Published { get; set; }

        public bool Active { get; set; }

        public Category Category { get; set; }

        public Status Status { get; set; }

        public DateTime Expiration { get; set; }       
    }
}
