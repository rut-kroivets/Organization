﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organization.Core.Entity;
using Organization.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<IEnumerable<Employee>> GetAsync()
        {
            return await _dataContext.employees.Include(e=>e.Positions).ToListAsync();      
        }

        public async Task<ActionResult<Employee>> GetAsync(int id)
        {
            return await _dataContext.employees.FindAsync(id);
        }

        public async Task<Employee> PostAsync(Employee e)
        {
            _dataContext.employees.Add(e);
            await _dataContext.SaveChangesAsync();
            return e;
        }

        public async Task PutAsync(int id, Employee e)
        {
            var employee = _dataContext.employees.Find(id);
            employee.Identity = e.Identity;
            employee.FirstName = e.FirstName;
            employee.LastName = e.LastName;
            employee.StartOfWork = e.StartOfWork;
            employee.DateOfBirth = e.DateOfBirth;
            employee.Gender = e.Gender;
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var employee = _dataContext.employees.Find(id);
            _dataContext.employees.Remove(employee);
            await _dataContext.SaveChangesAsync();
        }
    }
}
