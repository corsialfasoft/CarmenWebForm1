using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace CarmenWebForm1 {
    public partial class CercaProdotti : Page {
        public List<Prodotto> Prodotti { get; set; }
        public string Message { get; set; }

        public class Prodotto{
		    public int ID { get; set; }
		    public string Descrizione { get; set; }
		    public int Giacenza { get; set; }
	        
            public Prodotto(int id, string descr, int qta){
                this.ID=id;
                this.Descrizione=descr;
                this.Giacenza=qta;
            }
            public Prodotto(){
            }
        }
        public interface IRichieste{
		    List<Prodotto> RicercaDescrizione(string descrizione);
		    void AggiungiOrdine(List<Prodotto> listP);
	    }
        protected void Page_Load(object sender,EventArgs e) {
            Message = Request["Message"] ?? null;
        }      
        public List<Prodotto> RicercaDescrizione(string descrizione) {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(localdb)\MSSQLLocalDB";
            builder.InitialCatalog = "RICHIESTE";
            SqlConnection conn = new SqlConnection(builder.ToString());
            try{ 
				conn.Open();
				SqlCommand cmd = new SqlCommand("SP_CercaProdottoPerDescr", conn);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@Descr", System.Data.SqlDbType.NVarChar).Value=descrizione;
				SqlDataReader reader = cmd.ExecuteReader();
				List<Prodotto> listProd = new List<Prodotto>();
				while(reader.Read()){
                    Prodotto a = new Prodotto(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
					listProd.Add(a);
				}
				reader.Close();
                cmd.Dispose();
                return listProd;				
            }catch (Exception e) {
                throw e;
            }finally{ 
                conn.Dispose();
            }
		}
        
        protected void Cerca_Click(object sender,EventArgs e) {
            //if (txt_Id.Text!=""){
             if (!String.IsNullOrEmpty(txt_Id.Text)) { 
                //RicercaId(int.Parse(txt_Id.Text));
                Response.Redirect($"~/DettaglioProdotto.aspx?codice={txt_Id.Text}");
            }else if (!String.IsNullOrEmpty(txt_Descr.Text)) {
                Prodotti = RicercaDescrizione(txt_Descr.Text);
                tabProdotti.Prodotti=Prodotti;
                tabProdotti.CaricaProdottiTrovati();
            }                
        }
    }
}