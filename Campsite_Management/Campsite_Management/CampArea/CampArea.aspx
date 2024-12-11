<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CampArea.aspx.cs" Inherits="Campsite_Management.CampArea.CampArea" %>
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
    <br>
    <h1 style="color: #15c269; font-family: 'Brush Script MT', cursive; font-size: 60px; text-align: center;">All Camp Area Records</h1>
    <br>
    <br>

     <div class="container">
        <form runat="server">
            <br>
            <br>
            <br>
        <asp:Repeater ID="CampAreaRepeater" runat="server">
    <HeaderTemplate>

       <div class="card" style="width: 18rem; margin: 10px; display: inline-block; border-radius: 15px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); transition: transform 0.3s ease-in-out;">
    <div class="card-body text-center">
        <h5 class="card-title" style="font-size: 1.5rem; font-weight: bold; color: #4CAF50;">Add New Camp Area</h5>
        <br /><br />
        <p class="card-text" style="font-size: 1.4rem; color: #555;  margin-bottom: 20px;">
           Click here to add a new campsite.
        </p>
        <br />
        <asp:Button ID="btnAddNew" runat="server" Text="Add New Camp Area" CssClass="btn btn-success btn-lg" 
            style="padding: 10px 20px; font-size: 1.1rem; border-radius: 30px; transition: background-color 0.3s, transform 0.3s;" 
            OnClientClick="this.style.transform='scale(1.1)';" OnClick="btnAddNew_Click" />
        <br />
    </div>
</div>
    </HeaderTemplate>

    <ItemTemplate>
        <div class="card" style="width: 18rem; margin: 10px; display: inline-block;">
            <div class="card-body">
                <h5 class="card-title"><%# Eval("CampName") %></h5>
                <br />
                <h6 class="card-subtitle mb-2 text-muted">ID: <%# Eval("Id") %></h6>
                <br />
                <p class="card-text">
                    Address: <%# Eval("CampAddress") %><br /><br />
                    Phone: <%# Eval("CampPhone") %>
                </p>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary" OnClick="EditCampArea" CommandArgument='<%# Eval("ID") %>' />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="DeleteCampArea" CommandArgument='<%# Eval("ID") %>' />
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>



        </form>
    </div>

</asp:Content>
