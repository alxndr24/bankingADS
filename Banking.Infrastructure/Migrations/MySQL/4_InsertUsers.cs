using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(41)]
    public class InsertUsers : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("4_InsertUsers.sql");
        }

        public override void Down()
        {
        }
    }
}
