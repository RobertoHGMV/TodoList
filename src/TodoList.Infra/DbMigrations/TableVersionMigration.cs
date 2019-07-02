using FluentMigrator.Runner.VersionTableInfo;

namespace TodoList.Infra.DbMigrations
{
    [VersionTableMetaData]
    public class TableVersionMigration : IVersionTableMetaData
    {
        public object ApplicationContext { get; set; }

        public bool OwnsSchema
        {
            get { return true; }
        }


        public string ColumnName
        {
            get { return "Version"; }
        }

        public string SchemaName
        {
            get { return ""; }
        }

        public string TableName
        {
            get { return "TD_Version"; }
        }

        public string UniqueIndexName
        {
            get { return "TD_IDX_Version"; }
        }

        public virtual string AppliedOnColumnName
        {
            get { return "AppliedOn"; }
        }

        public virtual string DescriptionColumnName
        {
            get { return "Description"; }
        }
    }
}
