using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(51)]
    public class InsertAgentTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("5_InserAgentTable.sql");
        }

        public override void Down()
        {
        }
    }
}
