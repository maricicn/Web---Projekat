<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Korisnik.aspx.cs" Inherits="Web___Projekat.Korisnik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Ime korisnika :<asp:TextBox runat="server" name="ime_korisnika" ID="ime_korisnika"></asp:TextBox><br />
    Lozinka :<asp:TextBox runat="server" name="lozinka" ID="lozinka_korisnika"></asp:TextBox><br />
    <asp:Button runat="server" Text="Button" value="PROVERA" OnClick="Unnamed3_Click" />
</asp:Content>
