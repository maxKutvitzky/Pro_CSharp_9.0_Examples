using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Manager : Employee
    {
        public int StockOptions { get; set; }
        /*public Manager(string fullName, int age, int empId, float currPay, string ssn, int numbOfOpts)
        {
            // This property is defined by the Manager class.
            StockOptions = numbOfOpts;
            // Assign incoming parameters using the
            // inherited properties of the parent class.
            Id = empId;
            Age = age;
            Name = fullName;
            Pay = currPay;
            PayType = EmployeePayTypeEnum.Salaried;
            // OOPS! This would be a compiler error,
            // if the SSN property were read-only!
            SocialSecurityNumber = ssn;
        }*/
        public Manager()
        {

        }
        public Manager(string fullName, int age, int empId, float currPay, string ssn, int numbOfOpts)
        : base(fullName, age, empId, currPay, ssn, EmployeePayTypeEnum.Salaried)
        {
            // This property is defined by the Manager class.
            StockOptions = numbOfOpts;
        }
        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random r = new Random();
            StockOptions += r.Next(500);
        }
        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Number of Stock Options: {0}", StockOptions);
        }
    }
}
