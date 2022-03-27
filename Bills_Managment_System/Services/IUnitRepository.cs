using System.Collections.Generic;
using Bills.Models;

namespace Bills.Services
{
    public interface IUnitRepository
    {
        
        List<Unit> GetAll();
        public Unit GetByName(string NAme);
        Unit GetById(int id);
        int Insert(Unit dept);
        
    }
}