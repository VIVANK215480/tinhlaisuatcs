$(document).ready(function () {
    function sendData() {
        // Lấy dữ liệu từ các input fields
        var dataToSend = {
            principal: $('#principal').val(),
            interestRate: $('#interestRate').val(),
            years: $('#years').val()
        };

        // Kiểm tra dữ liệu hợp lệ
        if (isNaN(dataToSend.principal) || dataToSend.principal === '') {
            $('#result').html('Số tiền gốc chưa nhập đúng!');
            $('#principal').focus();
            return;
        }
        if (isNaN(dataToSend.interestRate) || dataToSend.interestRate === '') {
            $('#result').html('Lãi suất chưa nhập đúng!');
            $('#interestRate').focus();
            return;
        }
        if (isNaN(dataToSend.years) || dataToSend.years === '') {
            $('#result').html('Số năm chưa nhập đúng!');
            $('#years').focus();
            return;
        }

        // Gửi dữ liệu đến server qua AJAX
        $.ajax({
            url: 'api.aspx',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(dataToSend),
            success: function (response) {
                // Xử lý phản hồi từ server
                try {
                    var json = JSON.parse(response);
                    if (json.ok) {
                        $('#result').html('Kết quả: Tổng tiền là ' + json.data.TotalAmount + ', Lãi suất là ' + json.data.Interest);
                    } else {
                        $('#result').html('Lỗi: ' + json.error);
                    }
                } catch (e) {
                    $('#result').html('Lỗi phân tích JSON: ' + e.message);
                }
            },
            error: function (xhr, status, error) {
                $('#result').html('Lỗi kết nối: ' + error);
            }
        });
    }

    // Khi bấm nút "Tính", gọi hàm sendData
    $('#result').click(function () {
        sendData();
    });
});
