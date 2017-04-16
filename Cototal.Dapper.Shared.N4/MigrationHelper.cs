namespace Cototal.Dapper.Shared.N4
{
    /// <summary>
    /// DRY up some of the common database creation tasks. Specific to SQL Server
    /// </summary>
    public class MigrationHelper
    {
        public string CreateEnumTable(string tableName, params string[] fields)
        {
            var insertValues = new string[fields.Length];
            for (var i = 0; i < fields.Length; i++)
            {
                insertValues[i] = $"({i}, '{fields[i]}')";
            }
            return $@"CREATE TABLE {tableName}(
                Id int NOT NULL,
                Name varchar(250) NOT NULL,
                PRIMARY KEY CLUSTERED (Id ASC)
            ); INSERT INTO {tableName} VALUES {string.Join(", ", insertValues)};";
        }

        public string CreateTable(string tableName, params string[] columns)
        {
            return $@"CREATE TABLE {tableName}(
                Id int IDENTITY(1,1) NOT NULL,
                {string.Join(",\n", columns)},
                PRIMARY KEY CLUSTERED (Id ASC))";
        }

        public string CreateForeignKey(string foreignTable, string primaryTable,
            string fieldName = null, bool nullable = false, bool cascade = true)
        {
            var nullType = nullable ? "NULL" : "NOT NULL";
            var cascadeOption = cascade ? "CASCADE" : "NO ACTION";
            var foreignKeyName = fieldName ?? $"{primaryTable}Id";

            var keyName = $"FK_{foreignTable}_{primaryTable}_{foreignKeyName}";
            return $@"{foreignKeyName} int {nullType},
                CONSTRAINT {keyName} FOREIGN KEY ({foreignKeyName})
                REFERENCES {primaryTable} (Id) ON DELETE {cascadeOption}";
        }

        public string CreateIndex(string tableName, params string[] properties)
        {
            var propertyList = string.Join(", ", properties);
            var indexName = $"IX_{tableName}_{string.Join("_", properties)}";
            return $"CREATE INDEX {indexName} ON {tableName} ({propertyList})";
        }

        public string CreateUniqueIndex(string tableName, params string[] properties)
        {
            var propertyList = string.Join(", ", properties);
            var indexName = $"UIX_{tableName}_{string.Join("_", properties)}";
            return $"CREATE UNIQUE INDEX {indexName} ON {tableName} ({propertyList})";
        }
    }
}
