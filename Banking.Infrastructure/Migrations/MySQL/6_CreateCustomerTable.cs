using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(60)]
    public class CreateCustomerTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("6_CreateCustomerTable.sql");
        }

        public override void Down()
        {
        }
    }
}
