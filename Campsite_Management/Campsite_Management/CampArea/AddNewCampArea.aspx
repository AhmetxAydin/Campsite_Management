<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddNewCampArea.aspx.cs" Inherits="Campsite_Management.CampArea.AddNewCampArea" %>
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
<br>
<br>
<h1 style="color: #15c269; font-family: 'Brush Script MT', cursive; font-size: 60px; text-align: center;">Add New Camp Area Record</h1>
<br>
<br>

 <div class="container">
    <form runat="server">
        <a class="btn btn-primary" href="CampArea.aspx">Back</a>
        <br />
        <br />
        <asp:Label ID="lblCampArea" runat="server" Text="Name Of Camp Area"></asp:Label>
        <br>
       
        <asp:TextBox ID="CampArea_Name" runat="server"></asp:TextBox>
        <asp:Label ID="lblAddress" runat="server" Text="Address Of Camp Area"></asp:Label>
        <br>
        <asp:TextBox ID="CampArea_Address" runat="server"></asp:TextBox>
        <br>
        <asp:Label ID="lblPhone" runat="server" Text="Phone Number Of Camp Area"></asp:Label>
        <br>
        <asp:TextBox ID="Camp_Phone" runat="server"></asp:TextBox>
        <br>
        <br>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <br>
        <br>
   </form>
     </div>

</asp:Content>
