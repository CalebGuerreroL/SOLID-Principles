using System;
using System.Linq;
using DatabaseFirst_DWB.DataAccess;

namespace DatabaseFirst_DWB
{
    class Program
    {
        public static void SimpleSelect()
        {
            var dataContext = new NorthwindContext();
            var employeeQuery = dataContext.Employees.Select(s => s);
            var output = employeeQuery.ToList();

            foreach(var employee in output)
            {
                Console.WriteLine($"Nombre: {employee.FirstName}");
            }
        }

        public static void Excercise1()
        {
            NorthwindContext dataContext = new NorthwindContext();
            var employeeQuery = dataContext.Employees.AsQueryable();
            // var employeeQuery = dataContext.Employees.Select(s => s); same shit ↑
            var output = employeeQuery.ToList();
        }

        public static void Excercise2()
        {
            var dataContext = new NorthwindContext();
            var employeeQuery = dataContext.Employees
                .Select(s => new
                {
                    s.Title,
                    s.FirstName,
                    s.LastName
                })
                .Where(w => w.Title == "Sales Representative");

            var output = employeeQuery.ToList();

            foreach (var employee in output)
            {
                Console.WriteLine($"Nombre: {employee.FirstName} {employee.LastName}");
            }
        }

        public static void Excercise3()
        {
            var dataContext = new NorthwindContext();
            var employeeQuery = dataContext.Employees
                .Where(w => w.Title != "Sales Representative")
                .Select(s => new
                {
                    Puesto = s.Title,
                    Nombre = s.FirstName,
                    Apellido = s.LastName
                });

            var output = employeeQuery.ToList();

            foreach (var employee in output)
            {
                Console.WriteLine($"Nombre: {employee.Nombre} {employee.Apellido}");
            }
        }

        static void Main(string[] args)
        {
            SimpleSelect();
        }
    }
}
