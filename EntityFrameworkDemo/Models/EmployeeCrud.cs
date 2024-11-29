namespace EntityFrameworkDemo.Models
{
    public class EmployeeCrud
    {
        private readonly ApplicationDbContext db;
        public EmployeeCrud(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            // LINQ
            //var result = from e in db.Employees
            //             select e;

            //return result;

            // Lambda
            return db.Employees.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            //LINQ
            //var result= (from e in db.Employees
            //            where e.id==id
            //            select e).SingleOrDefault();
            //return result;

            // Lambda

            return db.Employees.Where(x => x.id == id).SingleOrDefault();


        }
        public int AddEmployee(Employee emp)
        {
            int result = 0;
            // add data in the DbSet 
            db.Employees.Add(emp);  
            // Add() will add emp object in the DbSet
            // update changes to Db
            result = db.SaveChanges();
            return result;
        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            // search the data that we need to modify in the DbSet
            var e = db.Employees.Where(x => x.id == emp.id).SingleOrDefault();
            if (e != null)
            {
                //update new changes
                e.name = emp.name;
                e.email = emp.email;
                e.salary = emp.salary;
                // update the changes to DB
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            // search the data that we need to modify in the DbSet
            var e = db.Employees.Where(x => x.id == id).SingleOrDefault();
            if (e != null)
            {
                //remove from DbSet
                db.Employees.Remove(e);
                // update the changes to DB
                result = db.SaveChanges();
            }
            return result;
        }
    }


}
