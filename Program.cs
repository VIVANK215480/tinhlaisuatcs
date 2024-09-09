using System;
using System.Collections.Generic;
using System.Text;
using LIBDLL;

namespace CStestDLL
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

            Calculator calculator = new Calculator();
            double totalAmount = calculator.CalculateTotalAmount(principal, interestRate, years);
            double interest = calculator.CalculateInterest(principal, interestRate, years);

            Console.WriteLine($"Tổng số tiền sau {years} năm: {totalAmount:F2}");
            Console.WriteLine($"Tổng tiền lãi: {interest:F2}");
        }
    }
}
