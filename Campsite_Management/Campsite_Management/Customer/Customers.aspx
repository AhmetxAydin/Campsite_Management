<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="Campsite_Management.Customer.Customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript">
      function showAlert(message, type) {
          Swal.fire({
              icon: type,
              title: message,
              confirmButtonText: 'OK'
          }).then((result) => {
              if (result.isConfirmed) {
                  location.reload();
              }
          });
      }
      </script>

  <br>
  <br>
  <br>
  <h1 style="color: #15c269; font-family: 'Brush Script MT', cursive; font-size: 60px; text-align: center;">All Camp Area Customer Records</h1>
  <br>
  <br>

  <div class="container">
      <form runat="server">
          <br>
          <br>
          <br>
          <asp:Repeater ID="CustomersRepeater" runat="server">
              <HeaderTemplate>
                  <div class="card" style="width: 18rem; margin: 10px; display: inline-block; border-radius: 15px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); transition: transform 0.3s ease-in-out;">
                      <div class="card-body text-center">
                          <h5 class="card-title" style="font-size: 1.5rem; font-weight: bold; color: #4CAF50;">Add New Customer</h5>
                          <br /><br />
                          <p class="card-text" style="font-size: 1.4rem; color: #555;  margin-bottom: 20px;">
                             Click here to add a new customer record.
                          </p>
                          <br />
                          <asp:Button ID="btnAddNew" runat="server" Text="Add New Customer" CssClass="btn btn-success btn-lg" 
                              style="padding: 10px 20px; font-size: 1.1rem; border-radius: 30px; transition: background-color 0.3s, transform 0.3s;" 
                              OnClientClick="this.style.transform='scale(1.1)';" OnClick="btnAddNew_Click" />
                          <br />
                      </div>
                  </div>
              </HeaderTemplate>

              <ItemTemplate>
                  <div class="card" style="width: 18rem; margin: 10px; display: inline-block;">
                      <div class="card-body">
                          <h5 class="card-title"><%# Eval("firstName") %> <%# Eval("lastName") %></h5>
                          <br />
                          <h6 class="card-subtitle mb-2 text-muted">ID: <%# Eval("Id") %></h6>
                          <br />
                          <p class="card-text">
                              CampID : <%# Eval("CampId") %><br />
                              License Plate: <%# Eval("plaka") %><br />
                              Phone: <%# Eval("customerPhone") %><br />
                              Region ID: <%# Eval("region") %><br />
                              Entry Date: <%# Eval("EntryDate", "{0:yyyy-MM-dd}") %><br />
                              Quit Date: <%# Eval("QuitDate", "{0:yyyy-MM-dd}") %>
                          </p>
                          <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary" OnClick="btnEdit_Click" CommandArgument='<%# Eval("Id") %>' />
                          <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="DeleteCustomer" CommandArgument='<%# Eval("Id") %>' />
                      </div>
                  </div>

              </ItemTemplate>
          </asp:Repeater>
      </form>
  </div>
</asp:Content>
