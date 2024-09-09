using System;
using System.Collections.Generic;
using System.Text;

namespace LIBDLL
{
    using System;
        public class Calculator
        {
            public double CalculateTotalAmount(double principal, double interestRate, int years)
            {
                return principal * Math.Pow((1 + interestRate / 100), years);
            }

            public double CalculateInterest(double principal, double interestRate, int years)
            {
                double totalAmount = CalculateTotalAmount(principal, interestRate, years);
                return totalAmount - principal;
            }
        }
    }

