using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(50)]
    public class CreateAgentTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("5_CreateAgentTable.sql");
        }

        public override void Down()
        {
        }
    }
}
