﻿using SQLManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLManager.Dal
{
    class SQLRepository : IRepository
    {
        #region constants
        private const string ConnectionString = "Server={0};Uid={1};Pwd={2}";
        private const string SelectDatabases = "SELECT name As Name FROM sys.databases";
        private const string SelectEntities = "SELECT TABLE_SCHEMA AS [Schema], TABLE_NAME AS Name FROM {0}.INFORMATION_SCHEMA.{1}S";
        private const string SelectProcedures = "SELECT SPECIFIC_NAME as Name, ROUTINE_DEFINITION as Definition FROM {0}.INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE'";
        private const string SelectColumns = "SELECT COLUMN_NAME as Name, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{1}'";
        private const string SelectProcedureParameters = "SELECT PARAMETER_NAME as Name, PARAMETER_MODE as Mode, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME='{1}'";
        private const string SelectQuery = "SELECT * FROM {0}.{1}.{2}";
        #endregion

        private string? cs;

        public IEnumerable<Database> GetDatabases()
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = SelectDatabases;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Database
                {
                    Name = dr[nameof(Database.Name)].ToString()
                };
            }
        }
        public IEnumerable<Procedure> GetProcedures(Database database)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectProcedures, database.Name);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Procedure
                {
                    Name = dr[nameof(Procedure.Name)].ToString(),
                    Definition = dr[nameof(Procedure.Definition)].ToString(),
                    Database = database
                };
            }
        }
        public IEnumerable<DBEntity> GetDBEntities(Database database, DBEntityType entityType)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectEntities, database.Name, entityType.ToString());
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new DBEntity
                {
                    Name = dr[nameof(DBEntity.Name)].ToString(),
                    Schema = dr[nameof(DBEntity.Schema)].ToString(),
                    Database = database
                };
            }
        }

        public IEnumerable<Column> GetColumns(DBEntity entity)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectColumns, entity.Database?.Name, entity.Name);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Column
                {
                    Name = dr[nameof(Column.Name)].ToString(),
                    DataType = dr[nameof(Column.DataType)].ToString()
                };
            }
        }
        public IEnumerable<Parameter> GetParameters(Procedure procedure)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectProcedureParameters, procedure.Database?.Name, procedure.Name);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Parameter
                {
                    Name = dr[nameof(Parameter.Name)].ToString(),
                    DataType = dr[nameof(Parameter.DataType)].ToString(),
                    Mode = dr[nameof(Parameter.Mode)].ToString()
                };
            }
        }

        public void Login(string server, string username, string password)
        {
            using SqlConnection con = new(
                string.Format(ConnectionString, server, username, password));
            //cs = con.ConnectionString;
            con.Open();
            cs = string.Format(ConnectionString, server, username, password);
        }

        public DataSet CreateDataset(DBEntity dBEntity)
        {
            using SqlConnection con = new(cs);
            SqlDataAdapter da = new(
                string.Format(SelectQuery, dBEntity.Database?.Name, dBEntity.Schema, dBEntity.Name),
                con
                );
            DataSet ds = new();
            da.Fill(ds);
            ds.Tables[0].TableName = dBEntity.Name;
            return ds;
        }

        public Result ExecuteSqlScript(string script)
        {
            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(script, con);
                con.Open();
                cmd.ExecuteNonQuery();

                return new Result
                {
                    Success = true, Message = "Script was successfully executed."
                };
            }
            catch (SqlException ex)
            {

                return new Result
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
