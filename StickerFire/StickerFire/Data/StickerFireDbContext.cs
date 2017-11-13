using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Data
{
    public class StickerFireDbContext : DbContext
    {
        public StickerFireDbContext(DbContextOptions<StickerFireDbContext>Options): base(Options)
        {

        }
    }
}
