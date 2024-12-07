using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ImprimeCuentas.Presentacion.Clases
{
    class RepresentantesComercialesMySQL
    {
        protected DataTable representantesObtenidos;
        protected string connectionString
        {
            get
            {
                return "Server=127.0.0.1;Port=3306;Database=bykom;Uid=bkm_lp;";
            }
        }
        
        public DataTable RepresentantesObtenidos
        {
            get
            {
                return representantesObtenidos;
            }
        }
        public RepresentantesComercialesMySQL()
        {
           this.representantesObtenidos = this.getTabla();
        }

        protected DataTable getTabla()
        {

            string query = "SELECT rco.ORDER_ID AS id, rco.CODIGOALFA AS codigo, rco.NOMBRE AS nombre FROM bykom.rcmacodigos rco;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmdSelect = new MySqlCommand(query, conn);


                conn.Open();
                MySqlDataReader reader = cmdSelect.ExecuteReader();
                DataTable dtRepresentantes = new DataTable();
                DataColumn colNombreMix = new DataColumn("nombre_mix", typeof(string));
                dtRepresentantes.Columns.Add(colNombreMix);

                if (reader != null)
                {
                    dtRepresentantes.Load(reader);
                }
                conn.Close();

                foreach (DataRow row in dtRepresentantes.Rows)
                {
                    row["nombre_mix"] = $"{row["codigo"]} | {row["nombre"]}";
                }
                   
                return dtRepresentantes;
            }

        }

        
    }
}
