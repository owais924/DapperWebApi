using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWebApi.Models
{
    public class ProductIdRepository
    {
        private string connectionString;
        public ProductIdRepository()
        {
            connectionString = @"Persist Security Info =False;User ID = sa;password=123;Intial Catalog=DAPPERDB;Data Source=DESKTOP-G4NJHED\SQLEXPRESS;connection Timeout=100000;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }

        }
        public void Add(Product prod)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO ProductId (Name,Quantity,Price) VALUES (@Nmae,@Quantity,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery,prod);
            }
        }
        public IEnumerable <Product> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM ProductId";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }
        public Product GetbyID(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM ProductId where ProductID=@ID";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { ID = ID}).FirstOrDefault();
            }
        }
        public void Delete(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE * FROM ProductId where ProductID=@ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { ID = ID });
            }
        }
        public void Update(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE ProductId SET Name=@Name,Quantity=@Quantity,Price=@Price where ProductID=@ID";
                dbConnection.Open();
                dbConnection.Query(sQuery, prod);
            }
        }

       
    }
}
