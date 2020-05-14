using Homework_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5.Services
{
    class EmployeeManager
    {
        public List<Departments> Departments { get; }

        public EmployeeManager()
        {
            var employee_id = 1;
            Departments = Enumerable.Range(1, 10)
                .Select(i => new Departments
                {
                    Name = $"Group {i}",
                    Employees = Enumerable
                    .Range(1, 10)
                    .Select(j => new Employee
                    {
                        Name = $"Name {employee_id}",
                        Surname = $"Surname {employee_id}",
                        Patronymic = $"Patronymic {employee_id++}"
                    })
                    .ToList()
                })
                .ToList();

            foreach (var departments in Departments)
                foreach (var employee in departments.Employees)
                   employee.Department = departments;
        }
    }
    
}
