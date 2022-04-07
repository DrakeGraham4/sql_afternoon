using System;
using System.Collections.Generic;
using sql_afternoon.Repositories;
using sql_afternoon.Models;

namespace sql_afternoon.Services
{

    public class CarsService
    {

        private readonly CarsRepository _repo;

        public CarsService(CarsRepository repo)
        {
            _repo = repo;
        }
        internal List<Car> GetAll()
        {
            return _repo.GetAll();
        }

        internal Car GetById(int id)
        {
            Car found = _repo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Car Create(Car carData)
        {
            return _repo.Create(carData);
        }

        internal Car Update(Car carData)
        {
            Car original = GetById(carData.Id);
            original.Make = carData.Make ?? original.Make;
            original.Model = carData.Model ?? original.Model;
            original.Price = carData.Price;
            original.Year = carData.Year;
            _repo.Update(original);
            return original;
        }

        internal void Delete(int id)
        {
            GetById(id);
            _repo.Delete(id);
        }
    }
}
