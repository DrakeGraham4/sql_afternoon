using System.Collections.Generic;
using System.Linq;
using System.Data;
using sql_afternoon.Models;
using Dapper;
using System;

namespace sql_afternoon.Repositories
{
    public class HousesRepository
    {
        private readonly IDbConnection _db;
        public HousesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<House> GetAll()
        {
            string sql = "SELECT * FROM houses;";
            return _db.Query<House>(sql).ToList();
        }

        internal House GetById(int id)
        {
            string sql = "SELECT * FROM houses WHERE id = @id";
            return _db.QueryFirstOrDefault<House>(sql, new { id });
        }

        internal House Create(House houseData)
        {
            string sql = @"
            INSERT INTO houses
            (bedrooms, bathrooms, description, price, year)
            VALUES
            (@Bedrooms, @Bathrooms, @Description, @Price, @Year);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, houseData);
            houseData.Id = id;
            return houseData;
        }

        internal void Update(House original)
        {
            string sql = @"
            UPDATE houses
            SET
            bedrooms = @Bedrooms,
            bathrooms = @Bathrooms,
            description = @Description,
            price = @Price,
            year = @Year
            WHERE id = @id;";
            _db.Execute(sql, original);

        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM houses WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }

}