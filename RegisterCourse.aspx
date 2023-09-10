<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab7.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
    <title>Register Course</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="center-container">
            <h1>Course Registration</h1>

            <label>Student: </label>
            <asp:DropDownList ID="StudentDropdown" CssClass="input" runat="server" AutoPostBack="True" OnSelectedIndexChanged="StudentDropdown_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="StudentRequired" runat="server" ControlToValidate="StudentDropdown" ErrorMessage="Must select a student!" ForeColor="Red" Display="Dynamic" /><br/>

            <asp:Label ID="SummaryLabel" runat="server" ForeColor="Black" CssClass="summary" /><br/>

            <h2>Available Courses:</h2>

            <asp:CheckBoxList ID="CourseCheckList" CssClass="table" runat="server">
            </asp:CheckBoxList><br/>

            <asp:Button ID="SaveButton" CssClass="button" Text="Save" runat="server" OnClick="SaveButton_Click" /><br/>

            <a href="AddStudent.aspx">AddStudent</a>
        </div>
    </form>
</body>
</html>
