using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(11)]
    public class InsertPermissions : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("1_InsertPermissions.sql");
        }

        public override void Down()
        {
        }
    }
}
