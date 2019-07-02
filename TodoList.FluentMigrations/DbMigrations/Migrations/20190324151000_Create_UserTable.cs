using FluentMigrator;

namespace TodoList.FluentMigrations.DbMigrations.Migrations
{
    [Migration(201903241510)]
    public class UserTable : Migration
    {
        public override void Down() { }

        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserName").AsString(100).Nullable()
                .WithColumn("Password").AsString(200).Nullable()
                .WithColumn("Email").AsString(100).Nullable()
                .WithColumn("Name").AsString(200).Nullable();
        }
    }
}
