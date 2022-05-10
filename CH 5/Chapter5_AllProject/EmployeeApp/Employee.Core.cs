using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    partial class Employee
    {
        // Field data.
        private string _empName;
        private int _empId;
        private float _currPay;
        private int _empAge;
        private string _empSSN;
        private EmployeePayTypeEnum _payType;

        // Properties!

        public EmployeePayTypeEnum PayType
        {
            get => _payType;
            set => _payType = value;
        }
        public string SocialSecurityNumber
        {
            get => _empSSN;
            private set => _empSSN = value;
        }
        public int Age
        {
            get => _empAge;
            set => _empAge = value;
        }
        public string Name
        {
            get { return _empName; }
            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                }
                else
                {
                    _empName = value;
                }
            }
        }
        public int Id // Note lack of parentheses
        {
            get { return _empId; }
            set { _empId = value; }
        }
        public float Pay
        {
            get { return _currPay; }
            set { _currPay = value; }
        }
        // Constructors.
        // Updated constructors.
        public Employee() { }
        public Employee(string name, int id, float pay, string empSnn)
        : this(name, 0, id, pay, empSnn, EmployeePayTypeEnum.Salaried) { }
        public Employee(string name, int age, int id, float pay, string ssn, EmployeePayTypeEnum payType)
        {
            // Better! Use properties when setting class data.
            // This reduces the amount of duplicate error checks.
            Name = name;
            Age = age;
            Id = id;
            Pay = pay;
            // Check incoming ssn parameter as required and then set the value.
            _empSSN = ssn;
            PayType = payType;
        }

}
