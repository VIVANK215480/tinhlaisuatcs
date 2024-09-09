<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WEBV1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form2" runat="server">
    <div>
        số tiền gốc: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server" Width="183px" style="margin-left: 10px;"></asp:TextBox>
    </div>
    <p>
        lãi suất hằng năm&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server" Width="185px" style="margin-left: 10px;"></asp:TextBox>
    </p>
    <p>
        số năm&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server" Width="187px" style="margin-left: 10px;"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Tính lÃi " style="margin-left: 20px;" OnClick="Button1_Click" />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Kết quả " style="margin-left: 20px;"></asp:Label>
    </p>
</form>

</body>
</html>
