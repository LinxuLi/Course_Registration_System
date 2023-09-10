<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab7.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
    <title>Add Student</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="center-container">
            <h1>Students</h1>

            <label>Student Name: </label>
            <asp:TextBox ID="StudentName" CssClass="input" runat="server" /><br/>
            <asp:RequiredFieldValidator 
    ID="StudentNameValidator" 
    runat="server" 
    ControlToValidate="StudentName" 
    ErrorMessage="Reqirement!" 
    ForeColor="Red" 
    Display="Dynamic" />
            <br/>
            <label>Student Type: </label>
            <asp:DropDownList ID="StudentType" CssClass="input" runat="server" style="display:inline">
                <asp:ListItem Text="Select ..." Value="" />
                <asp:ListItem Text="Full Time" Value="FulltimeStudent" />
                <asp:ListItem Text="Part Time" Value="ParttimeStudent" />
                <asp:ListItem Text="Coop" Value="CoopStudent" />
            </asp:DropDownList><br/>
            <asp:RequiredFieldValidator 
    ID="TypeRequiredValidator" 
    runat="server" 
    ControlToValidate="StudentType" 
    InitialValue="" 
    ErrorMessage="Must select one!" 
    ForeColor="Red" 
    Display="Dynamic" />

            <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" CssClass="error" />

            <h2>Students currently in the system:</h2>

            <asp:GridView ID="StudentsGrid" CssClass="table" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                </Columns>
                <EmptyDataTemplate>
                    <tr>
                        <td colspan="2" style="text-align:center;color:red;">No Student Yet!</td>
                    </tr>
                </EmptyDataTemplate>
            </asp:GridView><br/>

            <asp:Button ID="AddButton" CssClass="button" Text="Add" runat="server" OnClick="AddButton_Click" /><br/>
            <a href="RegisterCourse.aspx">RegisterCourse</a>
        </div>
    </form>
</body>
</html>
