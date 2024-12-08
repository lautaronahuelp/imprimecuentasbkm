using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CredentialManagement;
using MySql.Data.MySqlClient;

namespace ImprimeCuentas.Presentacion.Clases
{
    class AgrupacionesReceptorasMySQL
    {
        protected DataTable agrupacionesObtenidas;
        protected string connectionString;

        
        public DataTable AgrupacionesObtenidas
        {
            get
            {
                return agrupacionesObtenidas;
            }
        }
        public AgrupacionesReceptorasMySQL()
        {
            var cm = new Credential { Target = "imprimecuentas" };
            cm.Load();
            connectionString = $"Server=127.0.0.1;Port=3306;Database=bykom;Uid={cm.Username};Pwd={cm.Password}";
            this.agrupacionesObtenidas = this.getTabla();
        }

        protected DataTable getTabla()
        {

            string query = "SELECT agr.ORDER_ID AS id, agr.NOMBRE as nombre FROM bykom.agmaagrupaciones agr;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmdSelect = new MySqlCommand(query, conn);


                conn.Open();
                MySqlDataReader reader = cmdSelect.ExecuteReader();
                DataTable dtAgrupaciones = new DataTable();
               

                if (reader != null)
                {
                    dtAgrupaciones.Load(reader);
                }
                conn.Close();     
                   
                return dtAgrupaciones;
            }

        }

        
    }
}
