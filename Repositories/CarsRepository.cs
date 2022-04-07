using System.Collections.Generic;
using System.Linq;
using System.Data;
using sql_afternoon.Models;
using Dapper;
using System;

namespace sql_afternoon.Repositories
{
    public class CarsRepository
    {
        private readonly IDbConnection _db;
        public CarsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Car> GetAll()
        {
            string sql = "SELECT * FROM cars;";
            return _db.Query<Car>(sql).ToList();
        }

        internal Car GetById(int id)
        {
            string sql = "SELECT * FROM cars WHERE id = @id;";
            return _db.QueryFirstOrDefault<Car>(sql, new { id });
        }

        internal Car Create(Car carData)
        {
            string sql = @"
            INSERT INTO cars
            (make, model, price, year)
            VALUES
            (@Make, @Model, @Price, @Year);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, carData);
            carData.Id = id;
            return carData;
        }

        internal void Update(Car original)
        {
            string sql = @"
            UPDATE cars
            SET
            make = @Make,
            model = @Model,
            price = @Price,
            year = @Year
            WHERE id = @Id;";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM cars WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}