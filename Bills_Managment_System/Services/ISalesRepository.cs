using System.Collections.Generic;
using Bills.Models;

namespace Bills.Services
{
    public interface ISalesRepository
    {        
        public int GetNumber();
        public int GetSalesId();
        List<Sales> GetAll();
        Sales GetById(int id);
        int Insert(Sales sale);
       
    }
}