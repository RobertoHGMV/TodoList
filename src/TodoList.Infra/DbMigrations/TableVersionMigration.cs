using FluentMigrator.Runner.VersionTableInfo;

namespace TodoList.Infra.DbMigrations
{
    [VersionTableMetaData]
    public class TableVersionMigration : IVersionTableMetaData
    {
        public object ApplicationContext { get; set; }

        public bool OwnsSchema => true;

        public string SchemaName => "TodoList";

        public string TableName => "TD_Version";

        public string ColumnName => "Version";

        public string DescriptionColumnName => "Description";

        public string UniqueIndexName => "TD_IDX_Version";

        public string AppliedOnColumnName => "AppliedOn";
    }
}
