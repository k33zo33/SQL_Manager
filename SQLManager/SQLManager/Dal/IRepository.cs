using SQLManager.Models;
using System.Data;

namespace SQLManager.Dal
{
    internal interface IRepository
    {
        DataSet CreateDataset(DBEntity dBEntity);
        IEnumerable<Column> GetColumns(DBEntity entity);
        IEnumerable<Database> GetDatabases();
        IEnumerable<DBEntity> GetDBEntities(Database database, DBEntityType entityType);
        IEnumerable<Parameter> GetParameters(Procedure procedure);
        IEnumerable<Procedure> GetProcedures(Database database);
        void Login(string server, string username, string password);
        Result ExecuteSqlScript(string script);
    }
}