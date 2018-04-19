using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarmenWebForm1 {
    public partial class ListaProdotti : System.Web.UI.UserControl {
        public List<Prodotto> Prodotti { get; set; }
        public bool MostraQtaRichiesta{get;set;}
        public bool DettaProdEnabled{get;set;}
        
        protected void Page_Load(object sender,EventArgs e) {

        }
        public void CaricaProdottiTrovati(object sender,EventArgs e) {
            if (Prodotti != null) {
                foreach (Prodotto p in Prodotti) {
                    TableRow tr = new TableRow();
                    TableCell tdCodice = new TableCell();
                    tdCodice.Controls.Add(new Label() { Text = p.ID.ToString(),CssClass="col-xs-2" });
                    tr.Cells.Add(tdCodice);
                    TableCell tdDescrizione = new TableCell();
                    tdDescrizione.Controls.Add(new Label() { Text = p.Descrizione ,CssClass="col-xs-6" });
                    tr.Cells.Add(tdDescrizione);
                    if(this.DettaProdEnabled){
                        TableCell tdGiacenza = new TableCell();
                        tdGiacenza.Controls.Add(new Label() { Text = p.Giacenza.ToString(),CssClass="col-xs-2" });
                        tr.Cells.Add(tdGiacenza);
                    }
                    TableCell tdButton = new TableCell();
                    if(this.MostraQtaRichiesta){
                        tdButton.Controls.Add(new Button() { Text = "Dettaglio", PostBackUrl = $"DettaglioProdotto?codice={p.ID}" ,CssClass="col-xs-2"});
                        tr.Cells.Add(tdButton);
                        TabProdotti.Rows.Add(tr);
                    }
                }
            }
        }
    }
}