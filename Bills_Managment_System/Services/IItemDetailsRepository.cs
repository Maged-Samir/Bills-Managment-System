using System;
using System.Collections.Generic;
using Bills.Models;

namespace Bills.Services
{
    public interface IItemDetailsRepository
    {
        List<SalesDetalis> GetAll();
        SalesDetalis GetById(int id);
        int Insert(SalesDetalis dept);
        public List<SalesDetalis> GetByDate(DateTime startDate, DateTime endDate);
        
    }
}