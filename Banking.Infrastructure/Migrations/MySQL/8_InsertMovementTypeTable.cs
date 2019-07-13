using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(81)]
    public class MovementType : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("8_InsertMovementTypeTable.sql");
        }

        public override void Down()
        {
        }
    }
}
