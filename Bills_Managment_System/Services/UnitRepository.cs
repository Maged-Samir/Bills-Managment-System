using System.Collections.Generic;
using System.Linq;
using Bills.Data;
using Bills.Models;

namespace Bills.Services
{
    
    public class UnitRepository: IUnitRepository 
    {
        BillsDBcontext context;
        public UnitRepository(BillsDBcontext _context)
        {
            context = _context;
        }
        public Unit GetByName(string NAme)
        {
            Unit unit = context.Unit.Where(s => s.Name == NAme).FirstOrDefault();
            return unit;
        }
        public List<Unit> GetAll()
        {
            List<Unit> unitList = context.Unit.ToList();
            return unitList;
        }

        public Unit GetById(int id)
        {
            Unit dept = context.Unit.FirstOrDefault(s => s.Id == id);
            return dept;
        }

        public int Insert(Unit dept)
        {
            context.Unit.Add(dept);
            int raws = context.SaveChanges();
            return raws;
        }
    }
}
