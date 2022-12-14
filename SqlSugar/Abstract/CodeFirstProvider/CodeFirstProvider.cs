using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
namespace SqlSugar
{
    public partial class CodeFirstProvider : ICodeFirst
    {
        #region Properties
        public virtual SqlSugarClient Context { get; set; }
        private bool IsBackupTable { get; set; }
        private int MaxBackupDataRows { get; set; }
        #endregion

        #region Public methods
        public virtual ICodeFirst BackupTable(int maxBackupDataRows = int.MaxValue)
        {
            this.IsBackupTable = true;
            this.MaxBackupDataRows = maxBackupDataRows;
            return this;
        }
        public virtual void InitTables(Type entityType)
        {

            this.Context.Utilities.RemoveCacheAll();
            this.Context.InitMppingInfo(entityType);
            if (!this.Context.DbMaintenance.IsAnySystemTablePermissions())
            {
                Check.Exception(true, "Dbfirst and  Codefirst requires system table permissions");
            }
            Check.Exception(this.Context.IsSystemTablesConfig, "Please set SqlSugarClent Parameter ConnectionConfig.InitKeyType=InitKeyType.Attribute ");
            var executeResult = Context.Ado.UseTran(() =>
            {
                Execute(entityType);
            });
            Check.Exception(!executeResult.IsSuccess, executeResult.ErrorMessage);
        }
        public virtual void InitTables(Type[] entityTypes)
        {
            if (entityTypes.IsValuable())
            {
                foreach (var item in entityTypes)
                {
                    InitTables(item);
                }
            }
        }
        public virtual void InitTables(string entitiesNamespace)
        {
            var types = Assembly.Load(entitiesNamespace).GetTypes();
            InitTables(types);
        }
        public virtual void InitTables(params string[] entitiesNamespaces)
        {
            if (entitiesNamespaces.IsValuable())
            {
                foreach (var item in entitiesNamespaces)
                {
                    InitTables(item);
                }
            }
        }
        #endregion

        #region Core Logic
        protected virtual void Execute(Type entityType)
        {
            var entityInfo = this.Context.EntityProvider.GetEntityInfo(entityType);
            var tableName = GetTableName(entityInfo);
            var isAny = this.Context.DbMaintenance.IsAnyTable(tableName);
            if (isAny)
                ExistLogic(entityInfo);
            else
                NoExistLogic(entityInfo);
        }
        public virtual void NoExistLogic(EntityInfo entityInfo)
        {
            var tableName = GetTableName(entityInfo);
            Check.Exception(entityInfo.Columns.Where(it => it.IsPrimarykey).Count() > 1, "Use Code First ,The primary key must not exceed 1");
            List<DbColumnInfo> columns = new List<DbColumnInfo>();
            if (entityInfo.Columns.IsValuable())
            {
                foreach (var item in entityInfo.Columns.Where(it => it.IsIgnore == false))
                {
                    DbColumnInfo dbColumnInfo = EntityColumnToDbColumn(entityInfo, tableName, item);
                    columns.Add(dbColumnInfo);
                }
            }
            this.Context.DbMaintenance.CreateTable(tableName, columns);
            var pkColumns = entityInfo.Columns.Where(it => it.IsPrimarykey).ToList();
            foreach (var item in pkColumns)
            {
                this.Context.DbMaintenance.AddPrimaryKey(tableName, item.DbColumnName);
            }
        }
        public virtual void ExistLogic(EntityInfo entityInfo)
        {
            if (entityInfo.Columns.IsValuable())
            {
                Check.Exception(entityInfo.Columns.Where(it => it.IsPrimarykey).Count() > 1, "Use Code First ,The primary key must not exceed 1");

                var tableName = GetTableName(entityInfo);
                var dbColumns = this.Context.DbMaintenance.GetColumnInfosByTableName(tableName);
                ConvertColumns(dbColumns);
                var entityColumns = entityInfo.Columns.Where(it => it.IsIgnore == false).ToList();
                var dropColumns = dbColumns
                                          .Where(dc => !entityColumns.Any(ec => dc.DbColumnName.Equals(ec.OldDbColumnName, StringComparison.CurrentCultureIgnoreCase)))
                                          .Where(dc => !entityColumns.Any(ec => dc.DbColumnName.Equals(ec.DbColumnName, StringComparison.CurrentCultureIgnoreCase)))
                                          .ToList();
                var addColumns = entityColumns
                                          .Where(ec => ec.OldDbColumnName.IsNullOrEmpty() || !dbColumns.Any(dc => dc.DbColumnName.Equals(ec.OldDbColumnName, StringComparison.CurrentCultureIgnoreCase)))
                                          .Where(ec => !dbColumns.Any(dc => ec.DbColumnName.Equals(dc.DbColumnName, StringComparison.CurrentCultureIgnoreCase))).ToList();
                var alterColumns = entityColumns
                                           .Where(ec => !dbColumns.Any(dc => dc.DbColumnName.Equals(ec.OldDbColumnName, StringComparison.CurrentCultureIgnoreCase)))
                                           .Where(ec =>
                                                          dbColumns.Any(dc => dc.DbColumnName.Equals(ec.DbColumnName)
                                                               && ((ec.Length != dc.Length && !UtilMethods.GetUnderType(ec.PropertyInfo).IsEnum() && UtilMethods.GetUnderType(ec.PropertyInfo).IsIn(UtilConstants.StringType)) ||
                                                                    ec.IsNullable != dc.IsNullable ||
                                                                    IsSamgeType(ec, dc)))).ToList();
                var renameColumns = entityColumns
                    .Where(it => !string.IsNullOrEmpty(it.OldDbColumnName))
                    .Where(entityColumn => dbColumns.Any(dbColumn => entityColumn.OldDbColumnName.Equals(dbColumn.DbColumnName, StringComparison.CurrentCultureIgnoreCase)))
                    .ToList();


                var isChange = false;
                foreach (var item in addColumns)
                {
                    this.Context.DbMaintenance.AddColumn(tableName, EntityColumnToDbColumn(entityInfo, tableName, item));
                    isChange = true;
                }
                foreach (var item in dropColumns)
                {
                    this.Context.DbMaintenance.DropColumn(tableName, item.DbColumnName);
                    isChange = true;
                }
                foreach (var item in alterColumns)
                {
                    this.Context.DbMaintenance.UpdateColumn(tableName, EntityColumnToDbColumn(entityInfo, tableName, item));
                    isChange = true;
                }
                foreach (var item in renameColumns)
                {
                    this.Context.DbMaintenance.RenameColumn(tableName, item.OldDbColumnName, item.DbColumnName);
                    isChange = true;
                }

                foreach (var item in entityColumns)
                {
                    var dbColumn = dbColumns.FirstOrDefault(dc => dc.DbColumnName.Equals(item.DbColumnName, StringComparison.CurrentCultureIgnoreCase));
                    if (dbColumn == null) continue;
                    var pkDiff = item.IsPrimarykey != dbColumn.IsPrimarykey;
                    var idEntityDiff = item.IsIdentity != dbColumn.IsIdentity;
                    if (dbColumn != null && pkDiff && !idEntityDiff)
                    {
                        var isAdd = item.IsPrimarykey;
                        if (isAdd)
                        {
                            this.Context.DbMaintenance.AddPrimaryKey(tableName, item.DbColumnName);
                        }
                        else
                        {
                            this.Context.DbMaintenance.DropConstraint(tableName, string.Format("PK_{0}_{1}", tableName, item.DbColumnName));
                        }
                    }
                    else if (pkDiff || idEntityDiff)
                    {
                        ChangeKey(entityInfo, tableName, item);
                    }
                }
                if (isChange && IsBackupTable)
                {
                    this.Context.DbMaintenance.BackupTable(tableName, tableName + DateTime.Now.ToString("yyyyMMddHHmmss"), MaxBackupDataRows);
                }
            }
        }

        protected virtual void ChangeKey(EntityInfo entityInfo, string tableName, EntityColumnInfo item)
        {
            string constraintName = string.Format("PK_{0}_{1}", tableName, item.DbColumnName);
            if (this.Context.DbMaintenance.IsAnyConstraint(constraintName))
                this.Context.DbMaintenance.DropConstraint(tableName, constraintName);
            this.Context.DbMaintenance.DropColumn(tableName, item.DbColumnName);
            this.Context.DbMaintenance.AddColumn(tableName, EntityColumnToDbColumn(entityInfo, tableName, item));
            if (item.IsPrimarykey)
                this.Context.DbMaintenance.AddPrimaryKey(tableName, item.DbColumnName);
        }

        protected virtual void ConvertColumns(List<DbColumnInfo> dbColumns)
        {

        }
        #endregion

        #region Helper methods
        public virtual string GetCreateTableString(EntityInfo entityInfo)
        {
            StringBuilder result = new StringBuilder();
            var tableName = GetTableName(entityInfo);
            return result.ToString();
        }
        public virtual string GetCreateColumnsString(EntityInfo entityInfo)
        {
            StringBuilder result = new StringBuilder();
            var tableName = GetTableName(entityInfo);
            return result.ToString();
        }
        protected virtual string GetTableName(EntityInfo entityInfo)
        {
            return this.Context.EntityProvider.GetTableName(entityInfo.EntityName);
        }
        protected virtual DbColumnInfo EntityColumnToDbColumn(EntityInfo entityInfo, string tableName, EntityColumnInfo item)
        {
            var propertyType = UtilMethods.GetUnderType(item.PropertyInfo);
            var result = new DbColumnInfo()
            {
                TableId = entityInfo.Columns.IndexOf(item),
                DbColumnName = item.DbColumnName.IsValuable() ? item.DbColumnName : item.PropertyName,
                IsPrimarykey = item.IsPrimarykey,
                IsIdentity = item.IsIdentity,
                TableName = tableName,
                IsNullable = item.IsNullable,
                DefaultValue = item.DefaultValue,
                ColumnDescription = item.ColumnDescription,
                Length = item.Length,
                DecimalDigits=item.DecimalDigits
            };
            if (!string.IsNullOrEmpty(item.DataType))
            {
                result.DataType = item.DataType;
            }
            else if (propertyType.IsEnum())
            {
                result.DataType = this.Context.Ado.DbBind.GetDbTypeName(item.Length > 9 ? UtilConstants.LongType.Name : UtilConstants.IntType.Name);
            }
            else
            {
                result.DataType = this.Context.Ado.DbBind.GetDbTypeName(propertyType.Name);
            }
            return result;
        }

        protected virtual bool IsSamgeType(EntityColumnInfo ec, DbColumnInfo dc)
        {
            if (!string.IsNullOrEmpty(ec.DataType))
            {
                return ec.DataType != dc.DataType;
            }
            var propertyType = UtilMethods.GetUnderType(ec.PropertyInfo);
            var properyTypeName = string.Empty;
            if (propertyType.IsEnum())
            {
                properyTypeName = this.Context.Ado.DbBind.GetDbTypeName(ec.Length > 9 ? UtilConstants.LongType.Name : UtilConstants.IntType.Name);
            }
            else
            {
                properyTypeName = this.Context.Ado.DbBind.GetDbTypeName(propertyType.Name);
            }
            var dataType = dc.DataType;
            return properyTypeName != dataType;
        }
        #endregion
    }
}
