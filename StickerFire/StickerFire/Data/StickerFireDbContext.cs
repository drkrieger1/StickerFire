using Microsoft.EntityFrameworkCore;
using StickerFire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Data
{
    //Context for campaign models
    public class StickerFireDbContext : DbContext
    {
        public StickerFireDbContext(DbContextOptions<StickerFireDbContext>Options): base(Options)
        {

        }

        public DbSet<Campaign> Campaign { get; set; }

    }
}
