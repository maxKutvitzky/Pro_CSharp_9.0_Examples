using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    abstract partial class Employee
    {
        // Field data.
        protected string empName;
        protected int empId;
        protected float currPay;
        protected int empAge;
        protected string empSSN;
        protected EmployeePayTypeEnum payType;
        // Contain a BenefitPackage object.
        protected BenefitPackage EmpBenefits = new BenefitPackage();

        // Properties
        
        // Expose object through a custom property.
        public BenefitPackage Benefits
        {
            get { return EmpBenefits; }
            set { EmpBenefits = value; }
        }
        public EmployeePayTypeEnum PayType
        {
            get => payType;
            set => payType = value;
        }
        public string SocialSecurityNumber
        {
            get => empSSN;
            private set => empSSN = value;
        }
        public int Age
        {
            get => empAge;
            set => empAge = value;
        }
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                }
                else
                {
                    empName = value;
                }
            }
        }
        public int Id
        {
            get { return empId; }
            set { empId = value; }
        }
        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }
        // Constructors.
        public Employee() { }
        public Employee(string name, int id, float pay, string empSnn)
        : this(name, 0, id, pay, empSnn, EmployeePayTypeEnum.Salaried) { }
        public Employee(string name, int age, int id, float pay, string ssn, EmployeePayTypeEnum payType)
        {

            Name = name;
            Age = age;
            Id = id;
            Pay = pay;
            empSSN = ssn;
            PayType = payType;
        }

    }
}
