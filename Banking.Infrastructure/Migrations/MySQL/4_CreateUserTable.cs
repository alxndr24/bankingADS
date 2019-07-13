using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(40)]
    public class CreateUserTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("4_CreateUserTable.sql");
        }

        public override void Down()
        {
        }
    }
}
