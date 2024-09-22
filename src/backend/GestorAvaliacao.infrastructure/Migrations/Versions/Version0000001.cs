using FluentMigrator;

namespace GestorAvaliacao.Infrastructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_USER, "Create table User")]
    public class Version0000001 : VersionBase
    {
        public override void Up()
        {
            CreateTableWithDefaults("User")
            .WithColumn("Name").AsString(255).NotNullable()
            .WithColumn("Email").AsString(255).NotNullable()
            .WithColumn("Password").AsString(2000).NotNullable();
        }
    }
}
