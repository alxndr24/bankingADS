using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(61)]
    public class InsertCustomers : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("6_InsertCustomers.sql");
        }

        public override void Down()
        {
        }
    }
}
