using System.Collections.Generic;
using Bills.Models;

namespace Bills.Services
{
    public interface ICompanyRepository
    {
        public Company GetByName(string Name);
        int Insert(Company dept);
        List<Company> GetAll();
        Company GetById(int id);
       
    }
}