using System;
using StaticDataAndMembers;

Console.WriteLine("***** Fun with Static Data *****\n");
SavingsAccount s1 = new SavingsAccount(50);
SavingsAccount s2 = new SavingsAccount(100);
// Print the current interest rate.
Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());
// Make new object, this does NOT 'reset' the interest rate.
SavingsAccount s3 = new SavingsAccount(10000.75);
Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());
// Make an account.
SavingsAccount s11 = new SavingsAccount(50);
// Print the current interest rate.
Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());
// Try to change the interest rate via property.
SavingsAccount.SetInterestRate(0.08);
// Make a second account.
SavingsAccount s22 = new SavingsAccount(100);
// Should print 0.08...right??
Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());
// This is just fine.
TimeUtilClass.PrintDate();
TimeUtilClass.PrintTime();
Console.ReadLine();

