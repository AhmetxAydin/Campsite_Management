<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditCampActivity.aspx.cs" Inherits="Campsite_Management.CampActivity.EditCampActivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script type="text/javascript">
        function showAlert(message ,type) {
            Swal.fire({
                icon: type,
                title: message,
                confirmButtonText: 'OK'
            });     
        }
        </script>
         <br />
 <br />

 <h1 style="color: #15c269; font-family: 'Brush Script MT', cursive; font-size: 60px; text-align: center;">Edit Camp Activity</h1>
 <br />
 <br />

        <div class="container">
        <form runat="server">
            <a class="btn btn-primary" href="campActivity.aspx"> Back</a>
            <br />
            <br />
            <asp:Label ID="lblCampID" runat="server" Text="Select Camp Area"></asp:Label>
            <br />
            <asp:DropDownList ID="CampAreas" runat="server" DataValueField="ID" DataTextField="CampAreaName">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblActivity" runat="server" Text="Name Of Activity"></asp:Label>
            <asp:TextBox ID="CampActivity" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Description Of Activity"></asp:Label>
            <asp:TextBox ID="ActivityDescription" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" />
            <br />
            <br />
        </form>
        </div>
</asp:Content>
