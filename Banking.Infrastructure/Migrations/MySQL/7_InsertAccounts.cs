using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(71)]
    public class InsertAccounts : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("7_InsertAccounts.sql");
        }

        public override void Down()
        {
        }
    }
}
