using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(70)]
    public class CreateAccountTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("7_CreateAccountTable.sql");
        }

        public override void Down()
        {
        }
    }
}
