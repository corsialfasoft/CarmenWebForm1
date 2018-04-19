<%@ Page Title="DettaglioProdotto" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="DettaglioProdotto.aspx.cs" 
    Inherits="CarmenWebForm1.DettaglioProdotto" %>
<%@ Register TagPrefix="MyUC" TagName="DettProd" Src="~/Controls/DettProdottoUC.ascx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="text-warning">
        <%=Message %>
    </div>
    <MyUC:DettProd ID="dettProd" runat="server" />
    <div class="col-sm-4">
        <asp:Label runat="server">Quantita da richiedere</asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:Label runat="server"></asp:Label>
        <asp:TextBox TextMode="Number" ID="qta" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator
            ID="ReqFieldValCodice"
            ControlToValidate="qta"
            Display="Static"
            CssClass="text-danger"
            ErrorMessage="quantita obbligatoria"
            runat="server" />
        <asp:RangeValidator
            ID="RangeValCodice"
            runat="server"
            ControlToValidate="qta"
            Display="Static"
            ErrorMessage=" Range non valido (si possono scegliere solo i primi 100 prodotti)"
            CssClass="text-danger"
            Type="Integer"
            MinimumValue="1"
            MaximumValue="100" />
        <asp:CustomValidator
            ID="CustomValidator1"
            ControlToValidate="qta"
            Display="Static"
            ErrorMessage="E' possibile ordinare lotti da 50 o multipli!"
            OnServerValidate="QtaValidator"
            runat="server"></asp:CustomValidator>
    </div>
    <asp:Button runat="server" OnClick="Richiedi_Click" class="btn btn-primary" Text="ORDINA" />
    <asp:Button runat="server" PostBackUrl="~/CercaProdotti.aspx" class="btn btn-default" Text="ANNULLA" />
</asp:Content>
