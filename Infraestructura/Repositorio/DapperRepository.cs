﻿using _20241306PruebaTecnicaAFP.Core.Interface;
using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace _20241306PruebaTecnicaAFP.Infraestructura.Repositorio
{
    public class DapperRepository: IDapper
    {
        private readonly IConfiguration _config;
        public DapperRepository(IConfiguration config)
        {
            _config = config;
        }
        public DbConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString
                   ("DefaultConnection"));
        }
        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection
                  (_config.GetConnectionString("DefaultConnection"));
            return db.Query<T>(sp, parms, commandType: commandType).
                   FirstOrDefault();
        }
        public List<T> GetAll<T>(string sp, DynamicParameters parms,
       CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection
                  (_config.GetConnectionString("DefaultConnection"));
            return db.Query<T>(sp, parms, commandType: commandType).
                   ToList();
        }
        public List<T> GetAllById<T>(string sp, DynamicParameters parms,
       CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection
                  (_config.GetConnectionString("DefaultConnection"));
            return db.Query<T>(sp, parms, commandType: commandType).
                   ToList();
        }
        public int Execute(string sp, DynamicParameters parms,
        CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection
                  (_config.GetConnectionString("DefaultConnection"));
            return db.Execute(sp, parms, commandType: commandType);
        }
        public T Insert<T>(string sp, DynamicParameters parms,
        CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new SqlConnection
                  (_config.GetConnectionString("DefaultConnection"));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms,
                             commandType: commandType, transaction: tran)
                             .FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return result;
        }
        public T Update<T>(string sp, DynamicParameters parms,
        CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new SqlConnection
                  (_config.GetConnectionString("DefaultConnection"));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open(); using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms,
                             commandType: commandType, transaction: tran)
                             .FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return result;
        }
        public void Dispose()
        {
        }
    }
}
