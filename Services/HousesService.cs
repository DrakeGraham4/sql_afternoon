using System;
using System.Collections.Generic;
using sql_afternoon.Repositories;
using sql_afternoon.Models;

namespace sql_afternoon.Services
{

    public class HousesService
    {

        private readonly HousesRepository _repo;

        public HousesService(HousesRepository repo)
        {
            _repo = repo;
        }
        internal List<House> GetAll()
        {
            return _repo.GetAll();
        }

        internal House GetById(int id)
        {
            House found = _repo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal House Create(House houseData)
        {
            return _repo.Create(houseData);
        }

        internal House Update(House houseData)
        {
            House original = GetById(houseData.Id);
            original.Bedrooms = houseData.Bedrooms;
            original.Bathrooms = houseData.Bathrooms;
            original.Description = houseData.Description ?? original.Description;
            original.Price = houseData.Price;
            original.Year = houseData.Year;
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