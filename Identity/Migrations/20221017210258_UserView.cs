using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    public partial class UserView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("create view UserAvatars as select AspNetUsers.UserName , Avatar.Id from AspNetUsers inner join Avatar on AspNetUsers.AvatarId = Avatar.Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view UserAvatars");
        }
    }
}
