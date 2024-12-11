<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Management.aspx.cs" Inherits="CampingApp_Example.Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <h1 style="color: #1e7ce8; font-size: 65px; font-family: 'Brush Script MT',cursive; text-align: center;">CampingAPP MANAGEMENT</h1>
    <br />
    <br />

    <div class="hiking_text">
        <a href="CampArea/CampArea.aspx">
            <img class="hiking_img" src="images/CampAreas.jpeg" style="float: right;" width="500px"
                height="350px" />
        </a>
        <a href="CampMaterial/CampMaterial.aspx">
            <img class="hiking_img" src="images/materials.jpeg" style="float: left; width: 500px; height: 350px;" />
        </a>

    </div>

    <div class="hiking_text">
        <a href="Customer/Customers.aspx">
            <img class="hiking_img" src="images/Customers.jpeg" style="float: right;" width="500px"
                height="350px" />
        </a>
        <a href="CampActivity/campActivity.aspx">
            <img class="hiking_img" src="images/offROAD.jpeg" style="float: left; width: 500px; height: 350px;" />
        </a>

    </div>
</asp:Content>
