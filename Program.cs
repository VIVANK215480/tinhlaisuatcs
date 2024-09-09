using System;
using System.Collections.Generic;
using System.Text;

namespace tinhlaisuatcs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhập số tiền gốc: ");
            double principal = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập lãi suất hàng năm (%): ");
            double interestRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập số năm: ");
            int years = Convert.ToInt32(Console.ReadLine());

            double totalAmount = principal * Math.Pow((1 + interestRate / 100), years);
            double interest = totalAmount - principal;

            Console.WriteLine($"Tổng số tiền sau {years} năm: {totalAmount:F2}");
            Console.WriteLine($"Tổng tiền lãi: {interest:F2}");
        }
    }
}
