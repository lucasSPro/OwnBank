
using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace GestorAvaliacao.Infrastructure.Migrations.Versions
{
    public abstract class VersionBase : ForwardOnlyMigration
    {
        protected ICreateTableColumnOptionOrWithColumnSyntax CreateTableWithDefaults(string tableName)
        {
            return Create.Table(tableName)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("Ativo").AsBoolean().NotNullable();
        }
    }
}
