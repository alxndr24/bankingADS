using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(20)]
    public class CreateRoleTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("2_CreateRoleTable.sql");
        }

        public override void Down()
        {
        }
    }
}
