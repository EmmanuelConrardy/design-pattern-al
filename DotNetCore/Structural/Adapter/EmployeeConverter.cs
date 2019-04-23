using System;
using System.Collections.Generic;
using Xunit;

namespace Adapter
{
    public class EmployeeConverter
    {
        #region WithoutDesign
        [Fact]
        public void Adapter_WithoutDesign()
        {
            //Our model with incompatible 
            var companyEmplyees = new CompanyEmplyees();

            List<string> employeeList = new List<string>();
            string[][] employees = companyEmplyees.GetEmployees();

            //Convert it 
            foreach (string[] employee in employees)
            {
                employeeList.Add(employee[0]);
                employeeList.Add(",");
                employeeList.Add(employee[1]);
                employeeList.Add(",");
                employeeList.Add(employee[2]);
                employeeList.Add("\n");
            }

            //We use a poor design to pass the data to third party
            ITarget Itarget = new CompanyEmplyeesStub(employeeList);

            ThirdPartyBillingSystem client = new ThirdPartyBillingSystem(Itarget);
            client.ShowEmployeeList();
        }
        public class CompanyEmplyeesStub : ITarget
        {
            private List<string> EmployeeList { get; set; }
            public CompanyEmplyeesStub(List<string> employeeList)
            {
                EmployeeList = employeeList;
            }
            public List<string> GetEmployeeList() { return EmployeeList; }
        }
        #endregion WithoutDesign

        #region WithDesign
        [Fact]
        public void Adapter_With_Design()
        {
            ITarget Itarget = new EmployeeAdapter();
            ThirdPartyBillingSystem client = new ThirdPartyBillingSystem(Itarget);
            client.ShowEmployeeList();
        }
        #endregion WithDesign
    }

    /// <summary>
    ///  Interface: This is the interface which is used by the client to achieve functionality.
    /// </summary>
    public interface ITarget
    {
        List<string> GetEmployeeList();
    }

    /// <summary>
    /// Adaptee: This is the functionality which the client desires but its interface is not compatible with the client.
    /// </summary>
    public class CompanyEmplyees
    {
        public string[][] GetEmployees()
        {
            string[][] employees = new string[4][];

            employees[0] = new string[] { "100", "Deepak", "Team Leader" };
            employees[1] = new string[] { "101", "Rohit", "Developer" };
            employees[2] = new string[] { "102", "Gautam", "Developer" };
            employees[3] = new string[] { "103", "Dev", "Tester" };

            return employees;
        }
    }

    /// <summary>
    /// Client: This is the class which wants to achieve some functionality by using the adaptee’s code (list of employees).
    /// </summary>
    public class ThirdPartyBillingSystem
    {
        /* 
        * This class is from a thirt party and you do'n have any control over it. 
        * But it requires a Emplyee list to do its work
        */

        private ITarget employeeSource;

        public ThirdPartyBillingSystem(ITarget employeeSource)
        {
            this.employeeSource = employeeSource;
        }

        public void ShowEmployeeList()
        {
            // call the clietn list in the interface
            List<string> employee = employeeSource.GetEmployeeList();

            Console.WriteLine("######### Employee List ##########");
            foreach (var item in employee)
            {
                Console.Write(item);
            }

        }
    }

    /// <summary>
    /// Adapter: This is the class which would implement ITarget and would call the Adaptee code which the client wants to call.
    /// </summary>
    public class EmployeeAdapter : CompanyEmplyees, ITarget
    {
        public List<string> GetEmployeeList()
        {
            List<string> employeeList = new List<string>();
            //here the trick, we called what we want to adapt to convert into the desire signature.
            string[][] employees = GetEmployees();

            //Convert it 
            foreach (string[] employee in employees)
            {
                employeeList.Add(employee[0]);
                employeeList.Add(",");
                employeeList.Add(employee[1]);
                employeeList.Add(",");
                employeeList.Add(employee[2]);
                employeeList.Add("\n");
            }

            return employeeList;
        }
    }
}
