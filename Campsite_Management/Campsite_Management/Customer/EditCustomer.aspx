<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="Campsite_Management.Customer.EditCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <script type="text/javascript">
     function showAlert(message, type) {
         Swal.fire({
             icon: type,
             title: message,
             confirmButtonText: 'OK'
         });
     }
             </script>
             <br />
 <br />

 <h1 style="color: #15c269; font-family: 'Brush Script MT', cursive; font-size: 60px; text-align: center;">Edit Customer Record</h1>
 <br />
 <br />

    <div class="container">
        <form runat="server">
            <a class="btn btn-primary" href="Customers.aspx">Back</a>
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="First Name"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCampID" runat="server" Text="Select Camp Area"></asp:Label>
            <br />
            <asp:DropDownList ID="CampAreas" runat="server" DataValueField="ID" DataTextField="CampAreaName">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblplaka" runat="server" Text="Enter The Licence Plate"></asp:Label>
            <asp:TextBox ID="txtlicanceplate" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblPhone" runat="server" Text="Enter Customer Phone Number"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblRegion" runat="server" Text="Select Region"></asp:Label>
            <asp:DropDownList ID="ddlRegion" runat="server"></asp:DropDownList>
            <br />
            <asp:Label ID="lblEntryDate" runat="server" Text="Entry Date"></asp:Label>
            <asp:TextBox ID="txtEntryDate" runat="server" placeholder="YYYY-MM-DD"></asp:TextBox>
            <br />
            <asp:Label ID="lblQuitDate" runat="server" Text="Quit Date"></asp:Label>
            <asp:TextBox ID="txtQuitDate" runat="server" placeholder="YYYY-MM-DD"></asp:TextBox>
            <br />
            <asp:Button ID="btnSAVE" runat="server" Text="Save" OnClick="Btn_Save" />
            <br />
            <br />
        </form>

</asp:Content>
