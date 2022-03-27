using System.Collections.Generic;
using System.Linq;
using Bills.Data;
using Bills.Models;

namespace Bills.Services
{
    //CRUD DEpartment Model
    public class TypeRepository: ITypeRepository 
    {
        BillsDBcontext context;
        
        public TypeRepository(BillsDBcontext _context)
        {
            context = _context;
        }

        public Type GetByName(string Name)
        {
            Type type = context.Type.Where(s => s.Name == Name).FirstOrDefault();
            return type;
        }

        public List<Type> GetAll()
        {
            List<Type> typeList = context.Type.ToList();
            return typeList;
        }
        public List<Type> GetAll(int com_id)
        {
            List<Type> typeList = context.Type.Where(s=>s.Campany_Id==com_id).ToList();
            return typeList;
        }

        public Type GetById(int id)
        {
            Type type = context.Type.FirstOrDefault(s => s.Id == id);
            return type;
        }

        public int Insert(Type type)
        {
            context.Type.Add(type);
            int raws = context.SaveChanges();
            return raws;
        }
        
    }
}
