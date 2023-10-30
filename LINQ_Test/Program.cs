using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<Employee> employees = new List<Employee>()
            { new Employee{ EmployeeId=1,EmployeeName="Faraz Sayed",Age=23,DepartmentID=1},
                new Employee{ EmployeeId=2,EmployeeName="Aamir Shaikh",Age=22,DepartmentID=1} ,
                new Employee{ EmployeeId=3,EmployeeName="Mohammed Farooqui",Age=23,DepartmentID=2},
                new Employee{ EmployeeId=4,EmployeeName="Rehan Umatia",Age=22,DepartmentID=1 },
                new Employee{ EmployeeId=5,EmployeeName="Sohail Qureshi",Age=12,DepartmentID=2}
            };


            IList<Department> Dept = new List<Department>()
            { new Department{ Id=1,Name="IT"},
                new Department{ Id=2,Name="Suport"}
            };

            //Creating A Predicate Function using Delegate
            Func<Employee, bool> isYounger = delegate (Employee e)
            {
                return e.Age > 18 && e.Age < 30;
            };

            //var filterResult = from s in employees
            //                   where s.EmployeeName.Contains("o")
            //                   select s;
            //foreach (var item in filterResult) 
            //{
            //    Console.WriteLine(item.EmployeeId+","+item.EmployeeName);
            //}
            //Console.ReadLine();


            //Query Syntax With Predicate Function

            //var filterResult = from s in employees
            //                   where isYounger(s)
            //                   select s;
            //foreach (var item in filterResult)
            //{
            //    Console.WriteLine(item.EmployeeId + "," + item.EmployeeName);
            //}

            ////method Syntax
            //var filterResult = employees.Where(e => e.EmployeeName.Contains("o") || e.EmployeeName.Contains("F")).ToList();
            //foreach (var item in filterResult)
            //{
            //    Console.WriteLine(item.EmployeeId + "," + item.EmployeeName);
            //}

            //Query Syntax
            //var filterResult = from e in employees
            //                   where e.EmployeeName.Contains("o") || e.EmployeeName.Contains("F")
            //                   select e;
            //foreach ( var item in filterResult ) 
            //{
            //    Console.WriteLine(item.EmployeeId + "," + item.EmployeeName);
            //}

            //order By : by default Ascending

            //var orderEmployeeList = from e in employees
            //                        orderby e.EmployeeName ,e.Age
            //                        select e;

            // order by descending
            //var orderEmployeeList = from e in employees
            //                        orderby e.EmployeeName descending, e.Age descending
            //                        select e;

            //var orderEmployeeList = employees.OrderBy(e => e.EmployeeName);

            //descending
            //var orderEmployeeList = employees.OrderByDescending(e => e.EmployeeName).ThenBy(e=> e.Age);


            //foreach (var item in orderEmployeeList)
            //{
            //    Console.WriteLine(item.EmployeeId + "," + item.EmployeeName);
            //}
            //Group BY query syntax

            //Age
            //var groupResult = from e in employees
            //                  group e by e.Age;

            //Employee First letter Wise
            //var groupResult = from e in employees
            //                  group e by e.EmployeeName[0];

            //method syntax
            // first order by and then group by
            //var groupResult=employees.OrderBy(e=> e.Age).GroupBy(e=> e.EmployeeName[0]);


            //foreach (var item in groupResult) 
            //{
            //    Console.WriteLine(item.Key);
            //    foreach(var inneritem in item) 
            //    {
            //        Console.WriteLine(inneritem.EmployeeName);
            //    }
            //}


            //joins

            //var innerJoin=employees.Join(
            //    //outer sequence
            //    Dept,//inner sequence
            //    e=> e.DepartmentID,//outerkeyselector
            //    d=>d.Id,//inner key selector  
            //    (e, d) => new 
            //    {
            //        EmployeeName=e.EmployeeName,
            //        DepartmentName=d.Name
            //    }
            //            );
            //foreach(var item in innerJoin) 
            //{
            //    Console.WriteLine(item.EmployeeName+ ",Department:"+item.DepartmentName);
            //}

            //Group by and join
            //var innerJoin = employees.Join(
            //    //outer sequence
            //    Dept,//inner sequence
            //    e => e.DepartmentID,//outerkeyselector
            //    d => d.Id,//inner key selector  
            //    (e, d) => new
            //    {
            //        EmployeeName = e.EmployeeName,
            //        DepartmentName = d.Name
            //    }
            //            );

            //var groupResult = innerJoin.GroupBy(e => e.DepartmentName);
            //foreach (var item in groupResult)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach(var inneritem in item) 
            //    {
            //        Console.WriteLine(inneritem.EmployeeName + ",Department:" + inneritem.DepartmentName);
            //    }

            //}

            //query syntax

            var innerJoin = from e in employees
                            join d in Dept
                            on e.DepartmentID equals d.Id
                            select new 
                            {
                            EmployeeName=e.EmployeeName,
                                DepartmentName = d.Name
                            }
                            ;

            var groupResult = innerJoin.GroupBy(e => e.DepartmentName);
            foreach (var item in groupResult)
            {
                Console.WriteLine(item.Key);
                foreach (var inneritem in item)
                {
                    Console.WriteLine(inneritem.EmployeeName + ",Department:" + inneritem.DepartmentName);
                }

            }

            Console.ReadLine();



            // To Solve NameSpace Error use Control + . Where Error is there to resolve the Error
        }
    }

    public class Employee 
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Age { get; set; }

        public int DepartmentID { get; set; }

    }


    public class Department 
    {
        public int Id { get; set;}

        public string Name { get; set; }

    }
}
