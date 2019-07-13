using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(80)]
    public class CreateMovementTypeTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("8_CreateMovementTypeTable.sql");
        }

        public override void Down()
        {
        }
    }
}
