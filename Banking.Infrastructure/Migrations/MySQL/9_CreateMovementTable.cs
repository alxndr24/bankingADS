using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(90)]
    public class CreateMovementTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("9_CreateMovementTable.sql");
        }

        public override void Down()
        {
        }
    }
}
