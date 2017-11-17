using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Models
{
    //Combines the Login and Register view models into one supreme...MEGAVIEWMODEL!
    //So we can have our login and register on the same view.
    public class MegaViewModel
    {
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
    }
}
