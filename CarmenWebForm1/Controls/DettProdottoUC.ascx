<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="DettProdottoUC.ascx.cs" 
    Inherits="CarmenWebForm1.DettProdottoUC" %>
 <div class="col-sm-4">
        <asp:Label runat="server">Codice Prodotto </asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:Label runat="server"><%=prodotto.ID %></asp:Label>
    </div>
    <div class="col-sm-4">
        <asp:Label runat="server">Descrizione Prodotto </asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:Label runat="server"><%=prodotto.Descrizione %></asp:Label>
    </div>
    <div class="col-sm-4">
        <asp:Label runat="server">Giacenza </asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:Label runat="server"><%=prodotto.Giacenza %></asp:Label>
    </div>
