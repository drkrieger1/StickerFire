using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Models
{
    public class Campaign

    {
        public int ID { get; set; }

        public string OwnerID { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Votes { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Views { get; set; }

        [RegularExpression(@"^\S*$", ErrorMessage = "No white space!")]
        [Required]
        public string Title { get; set; }

        public string ImgPath { get; set; }

        [Required]
        [StringLength(400)]
        public string Description { get; set; }
        public string DenyMessage { get; set; }

        public bool Published { get; set; }
        public bool Active { get; set; }


        public Category Category { get; set; }
        public Status Status { get; set; }
        //Votes Voters 
        public DateTime Expiration { get; set; }       
    }
}
