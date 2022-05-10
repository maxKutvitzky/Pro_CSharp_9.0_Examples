using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

List<double[]> list = new List<double[]>()
{
    new double[] { 0,0.14,0.75},
    new double[] { 1,0,0.5 },
    new double[] { 0.33,0,0.75 },
    new double[] { 1,0.14,0.25 },
    new double[] { 0,1,0.25 },
    new double[] { 0.33,0.14,0.5 },
    new double[] { 0,0.42,0.5 },
    new double[] { 0,0,1 },
    new double[] { 1,0.42,0 },
    new double[] { 0.33,0.42,0.25 }
};
List<double> sums = new List<double>();
double k = (1.0 / 3.0);
double[] koef = {0.3,0.5,0.2};
foreach (double[] item in list)
{
    double sum = 0;
    for(int i = 0; i < item.Length; ++i)
    {
        sum += item[i]*koef[i];
    }
    sums.Add(sum);
}
foreach(double sum in sums)
{
    Console.WriteLine(Math.Round(sum,2));
}
Console.WriteLine($"{Math.Round(sums.Max(), 2)}");
