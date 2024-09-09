using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LIBDLL;
namespace WEBV1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double principal = Convert.ToDouble(TextBox1.Text);
            double interestRate = Convert.ToDouble(TextBox2.Text);
            int years = Convert.ToInt32(TextBox3.Text);

            Calculator calculator = new Calculator();
            double totalAmount = calculator.CalculateTotalAmount(principal, interestRate, years);
            double interest = calculator.CalculateInterest(principal, interestRate, years);

            Label1.Text = $"Tổng số tiền sau {years} năm: {totalAmount:F2}<br/>Tổng tiền lãi: {interest:F2}";

            // Thay đổi thuộc tính layout (ví dụ: thay đổi màu chữ)
            Label1.ForeColor = System.Drawing.Color.Green;
        }
    }
}