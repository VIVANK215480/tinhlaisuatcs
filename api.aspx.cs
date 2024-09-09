using System;
using System.Collections.Generic;
using Newtonsoft.Json; // Thư viện JSON.NET
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LIBDLL;

namespace Webv2
{
    public partial class api : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                try
                {
                    // Đọc dữ liệu JSON từ request
                    var jsonData = new System.IO.StreamReader(Request.InputStream).ReadToEnd();

                    // Chuyển dữ liệu JSON thành đối tượng RequestData
                    var requestData = JsonConvert.DeserializeObject<RequestData>(jsonData);

                    // Kiểm tra dữ liệu có hợp lệ hay không
                    if (requestData.Principal <= 0 || requestData.InterestRate <= 0 || requestData.Years <= 0)
                    {
                        throw new Exception("Dữ liệu nhập không hợp lệ. Vui lòng nhập các giá trị lớn hơn 0.");
                    }

                    // Sử dụng DLL để tính toán
                    Calculator calculator = new Calculator();
                    double totalAmount = calculator.CalculateTotalAmount(
                        requestData.Principal,
                        requestData.InterestRate,
                        requestData.Years
                    );
                    double interest = calculator.CalculateInterest(
                        requestData.Principal,
                        requestData.InterestRate,
                        requestData.Years
                    );

                    // Đóng gói kết quả vào format JSON
                    var response = new ResponseData
                    {
                        Ok = true,
                        Data = new { TotalAmount = totalAmount, Interest = interest }
                    };

                    // Gửi kết quả về cho client dưới dạng JSON
                    SendResponse(response);
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi và gửi phản hồi lỗi về client
                    var errorResponse = new ResponseData
                    {
                        Ok = false,
                        Error = ex.Message
                    };
                    SendResponse(errorResponse);
                }
            }
        }

        // Phương thức gửi phản hồi dạng JSON
        private void SendResponse(ResponseData response)
        {
            Response.ContentType = "application/json";
            Response.Write(JsonConvert.SerializeObject(response)); // Sử dụng JSON.NET để serialize đối tượng thành JSON
            Response.End();
        }

        // Định nghĩa các lớp dữ liệu
        public class RequestData
        {
            public double Principal { get; set; } // Số tiền gốc
            public double InterestRate { get; set; } // Lãi suất
            public int Years { get; set; } // Số năm
        }

        public class ResponseData
        {
            public bool Ok { get; set; }
            public object Data { get; set; }
            public string Error { get; set; }
        }
    }
}

