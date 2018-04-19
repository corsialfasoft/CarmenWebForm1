using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace CarmenWebForm1 {
    public partial class DettaglioProdotto : Page {
        public string Message;
        public Prodotto prodotto;

        public class Prodotto{
		    public int ID { get; set; }
		    public string Descrizione { get; set; }
		    public int Giacenza { get; set; }
	        public int QuantitaRichiesta { get; set; }

            public Prodotto(int id, string descr, int qta){
                this.ID=id;
                this.Descrizione=descr;
                this.Giacenza=qta;
            }
            public Prodotto(){
            }
        }
        public interface IRichieste{
		    Prodotto RicercaId(int id);
		    void AggiungiOrdine(List<Prodotto> listP);
	    }
        protected void Page_Load(object sender,EventArgs e) {
            prodotto = int.TryParse(Request["Codice"], out int code) ? RicercaId(code) : null;
            if (prodotto == null) {
                Response.Redirect("~/Ricerca.aspx?Message='prodotto non trovato'");
            }
            dettProd.prodotto=prodotto;
        }
        protected void QtaValidator(Object oggetto, ServerValidateEventArgs argomenti) {
            if ((argomenti.Value.Equals("50")) && (argomenti.Value.Equals("100"))) {
                argomenti.IsValid = true;
            } else {
                argomenti.IsValid = false;
            }
        }
        public Prodotto RicercaId(int id){
            Prodotto a = new Prodotto();
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(localdb)\MSSQLLocalDB";
            builder.InitialCatalog = "RICHIESTE";
            SqlConnection conn = new SqlConnection(builder.ToString());
            try{ 
				conn.Open();
				SqlCommand cmd = new SqlCommand("SP_CercaProdottoPerCodice", conn);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@Codice", System.Data.SqlDbType.Int).Value=id;
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()){
                    a = new Prodotto(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
				}
				reader.Close();
                cmd.Dispose();
                return a;
            }catch (Exception e) {
                throw e;
            }finally{ 
                conn.Dispose();
            }
		}
        protected void Richiedi_Click(object sender, EventArgs e) {
            if (Page.IsValid) {
                if (int.TryParse(qta.Text, out int quantitaRichiesta)) {
                    List<Prodotto> prodotti = (List<Prodotto>)Session["listaRichieste"] ?? new List<Prodotto>();
                    var query = from prod in prodotti
                        where prod.ID==prodotto.ID
                        select prod;
                    if(query.FirstOrDefault()!=null){
                        query.FirstOrDefault().QuantitaRichiesta =  query.FirstOrDefault().QuantitaRichiesta +  quantitaRichiesta;
                    }else{
                        prodotto.QuantitaRichiesta=quantitaRichiesta;
                        prodotti.Add(prodotto);
                    }
                    Session["listaRichieste"]=prodotti;
                    Response.Redirect("~/CercaProdotti.aspx?Message=Quantità aggiunta al carrello");
                } else {
                    Message= "La quantità deve essere un valore numerico";
                }
            }else {
                Message = "Pagina non valida!!!";
            }
        }
    }
}