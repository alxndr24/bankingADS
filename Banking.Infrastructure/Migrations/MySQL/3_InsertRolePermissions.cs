using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(31)]
    public class InsertRolePermissions : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("3_InsertRolePermissions.sql");
        }

        public override void Down()
        {
        }
    }
}
