using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StickerFire.Migrations.StickerFireDb
{
    public partial class stickerFire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    DenyMessage = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 400, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    ImgPath = table.Column<string>(nullable: true),
                    OwnerID = table.Column<string>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Views = table.Column<int>(nullable: false),
                    Votes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaign");
        }
    }
}
