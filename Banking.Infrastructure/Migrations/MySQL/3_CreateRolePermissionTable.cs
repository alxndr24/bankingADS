using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(30)]
    public class CreateRolePermissionTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("3_CreateRolePermissionTable.sql");
        }

        public override void Down()
        {
        }
    }
}
