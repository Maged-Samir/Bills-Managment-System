using System.Collections.Generic;
using Bills.Models;

namespace Bills.Services
{
    public interface ITypeRepository
    {

        public List<Type> GetAll(int com_id);
        public Type GetByName(string Name);
        List<Type> GetAll();
        Type GetById(int id);
        int Insert(Type dept);
    }
}