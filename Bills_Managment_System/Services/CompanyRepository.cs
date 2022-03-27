using Bills.Data;
using Bills.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bills.Services
{
    
    public class CompanyRepository: ICompanyRepository 
    {
        BillsDBcontext context;
        public CompanyRepository(BillsDBcontext _context)
        {
            context = _context;
        }
        public Company GetByName(string Name)
        {
            Company comp = context.Company.Where(s => s.Name == Name).FirstOrDefault();
            return comp;
        }

        public Company GetById(int id)
        {
            Company comp = context.Company.FirstOrDefault(s => s.Id == id);
            return comp;
        }
        
        public int Insert(Company dept)
        {
            context.Company.Add(dept);
            int raws = context.SaveChanges();
            return raws;
        }

        public List<Company> GetAll()
        {
            List<Company> compList = context.Company.ToList();
            return compList;
        }

    }
}
