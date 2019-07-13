using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(21)]
    public class InsertRoles : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("2_InsertRoles.sql");
        }

        public override void Down()
        {
        }
    }
}
