﻿using HrApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrApi.Services.Interfaces
{
    public interface IEmployeeService
    {
        bool AddEmployee(Employee employee);
        Employee GetEmployee(int id);
        Employee PutEmployee(int id, Employee company);
        IEnumerable<Employee> GetEmployees();
        bool DeleteEmployee(int id);


    }
}