<%@ Page Title="Cerca Prodotti" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="CercaProdotti.aspx.cs" 
    Inherits="CarmenWebForm1.CercaProdotti" %>

<%@ Register TagPrefix="MyUC" TagName="TabProdotti" Src="~/Controls/ListaProdotti.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:Label runat="server">Codice</asp:Label>
    <asp:TextBox id="txt_Id" runat="server"></asp:TextBox>
    <asp:Label runat="server">Descrizione</asp:Label>
    <asp:TextBox id="txt_Descr" runat="server"></asp:TextBox>
    <asp:Button ID="Cerca" Text="CERCA" OnClick="Cerca_Click" runat="server"></asp:Button>
    <MyUC:TabProdotti MostraQtaRichiesta=false DettaProdEnabled=true ID="tabProdotti" runat="server" />
</asp:Content>
