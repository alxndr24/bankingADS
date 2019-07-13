using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(10)]
    public class CreatePermissionsTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("1_CreatePermissionTable.sql");
        }

        public override void Down()
        {
        }
    }
}
