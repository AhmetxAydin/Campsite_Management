<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditCampMaterial.aspx.cs" Inherits="Campsite_Management.CampMaterial.EditCampMaterial" %>
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

 <h1 style="color: #15c269; font-family: 'Brush Script MT', cursive; font-size: 60px; text-align: center;">Edit Camp Material</h1>
 <br />
 <br />
<div class="container">
     <form runat="server">
         <a class="btn btn-primary" href="CampMaterial.aspx"> Back</a>
         <br />
         <br />
         <asp:Label ID="lblname" runat="server" Text="Name Of Material"></asp:Label>
         <br>
         <asp:TextBox ID="Material_Name" runat="server"></asp:TextBox>
         <br />
         <asp:Label ID="lblDescription" runat="server" Text="Description Of Material"></asp:Label>
         <br>
         <asp:TextBox ID="Material_Description" runat="server"></asp:TextBox>
         <br />

         <asp:Label ID="lblProducer" runat="server" Text="Producer Of Material"></asp:Label>
         <br>
         <asp:TextBox ID="Material_Producer" runat="server"></asp:TextBox>
         <br />
         <br />
         <asp:Button ID="btnSAVE" runat="server" Text="Save" OnClick="btnSAVE_Click" />
         <br />
         <br />
   </form>
</div>

</asp:Content>
