using System.Linq;

namespace EmployeeManagement
{
    public class EmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        public void CreateEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                Console.WriteLine("Empleado creado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el empleado: " + ex.Message);
            }
        }

        public List<Employee> GetEmployeesByName()
        {
            var query = _context.Employees
                .Where(e => e.Status == EmployeeStatus.Active)
                .OrderBy(e => e.Name)
                .ThenByDescending(e => e.BornDate);

            return query.ToList();
        }

        public List<Employee> GetEmployeesByBornDate()
        {
            var query = _context.Employees
                .Where(e => e.Status == EmployeeStatus.Active)
                .OrderByDescending(e => e.BornDate)
                .ThenBy(e => e.Name);

            return query.ToList();
        }
    }
}

