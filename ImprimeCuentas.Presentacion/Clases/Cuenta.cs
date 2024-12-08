using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CredentialManagement;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ImprimeCuentas.Presentacion.Clases
{
    class CuentaMySQL
    {
        protected DataTable cuentasObtenidas;
        protected string connectionString;
        /*{
            get
            {
                return "";
            }
        }*/
        
        public DataTable CuentasObtenidas
        {
            get
            {
                return cuentasObtenidas;
            }
        }
        public CuentaMySQL(string nro_cuenta, int part_cuenta, string agrup_cuenta, string rep_cuenta)
        {
            
            var cm = new Credential { Target = "imprimecuentas" };
            cm.Load();
            connectionString = $"Server=127.0.0.1;Port=3306;Database=bykom;Uid={cm.Username};Pwd={cm.Password}";


            this.cuentasObtenidas = this.getTabla(nro_cuenta, part_cuenta, agrup_cuenta, rep_cuenta);
        }

        protected DataTable getTabla(string n_cuenta = null, int p_cuenta = -1, string a_cuenta = null, string r_cuenta = null)
        {

            string query = "SELECT cue.ORDER_ID AS id, rco.CODIGOALFA AS representante, cue.ID_CL AS nro_cuenta," +
                                                            " cue.PARTICION AS particion, cue.NOMBRE AS descripcion, cue.NOMBRE_DOS AS nombre," +
                                                            " cal.NOMBRE AS calle, cue.NUMERO AS numero, IFNULL(cue.PISO, 'Sin piso') AS piso," +
                                                            " IFNULL(cue.DPTO, 'Sin dpto') AS depto, ciu.NOMBRE AS ciudad, ciu.CODPOSTAL2 AS cod_postal," +
                                                            " cmc.NOMBRE AS rubro," +
                                                            " cat.NOMBRE AS categoria, cue.CONTRATO AS contrato, cue.CENTRALMON AS agrupacion" +
                                                            " FROM bykom.abmacodigos cue" +
                                                            " INNER JOIN bykom.calles cal" +
                                                            " ON cue.CALLE = cal.ORDER_ID" +
                                                            " INNER JOIN bykom.ciudad ciu" +
                                                            " ON cue.CODIGOCIUD = ciu.CODIGOCIUD" +
                                                            " INNER JOIN bykom.abrltipocategoria cat" +
                                                            " ON cue.CODIGOCATE = cat.ORDER_ID" +
                                                            " INNER JOIN bykom.abrltipocomercio cmc" +
                                                            " ON cue.CODIGOCOM = cmc.ORDER_ID" +
                                                            " INNER JOIN bykom.rcmacodigos rco" +
                                                            " ON cue.ID_RC = rco.ORDER_ID";

            if(n_cuenta != null || p_cuenta != -1 || a_cuenta != null || r_cuenta != null)
            {
                query += " WHERE";
                if(n_cuenta != null) query += " cue.ID_CL = @nro_cuenta";
                else query += " TRUE";

                if (p_cuenta != -1) query += " AND cue.PARTICION = @part_cuenta";
                else query += " AND TRUE";

                if (a_cuenta != null) query += " AND cue.CENTRALMON = @agrup_cuenta";
                else query += " AND TRUE";

                if (r_cuenta != null) query += " AND rco.CODIGOALFA = @rep_cuenta";
                else query += " AND TRUE";
            }

            query += " ORDER BY RIGHT(CONCAT(\"000000\", TRIM(nro_cuenta)),6), particion;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmdSelect = new MySqlCommand(query, conn);
                if (n_cuenta != null) cmdSelect.Parameters.Add("@nro_cuenta", MySqlDbType.VarChar);
                if (p_cuenta != -1) cmdSelect.Parameters.Add("@part_cuenta", MySqlDbType.Int32);
                if (a_cuenta != null) cmdSelect.Parameters.Add("@agrup_cuenta", MySqlDbType.VarChar);
                if (r_cuenta != null) cmdSelect.Parameters.Add("@rep_cuenta", MySqlDbType.VarChar);

                if (n_cuenta != null) cmdSelect.Parameters["@nro_cuenta"].Value = n_cuenta;
                if (p_cuenta != -1) cmdSelect.Parameters["@part_cuenta"].Value = p_cuenta;
                if (a_cuenta != null) cmdSelect.Parameters["@agrup_cuenta"].Value = a_cuenta;
                if (r_cuenta != null) cmdSelect.Parameters["@rep_cuenta"].Value = r_cuenta;

                

                conn.Open();
                MySqlDataReader reader = cmdSelect.ExecuteReader();
                DataTable dtCuentas = new DataTable();
               
          
                if (reader != null)
                {
                    dtCuentas.Load(reader);
                }
                conn.Close();
;
                return dtCuentas;
            }

        }


        protected DataTable getDetalle(int order_id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmdSelect = new MySqlCommand("SELECT cue.ID_CL AS nro_cuenta, cue.PARTICION AS particion," +
                                                            " cue.CENTRALMON AS agrupacion, rco.CODIGOALFA AS representante," +
                                                            " cue.NOMBRE AS descripcion, cue.NOMBRE_DOS AS nombre," +
                                                            " cal.NOMBRE AS calle, cue.NUMERO AS numero, IFNULL(cue.PISO, 'Sin piso') AS piso," +
                                                            " IFNULL(cue.DPTO, 'Sin dpto') AS depto, IFNULL(en1.NOMBRE, 'Sin entrecalle') AS entre," +
                                                            " IFNULL(en2.NOMBRE, 'Sin entrecalle') AS y, bar.NOMBRE AS barrio," +
                                                            " ciu.NOMBRE AS ciudad, ciu.CODPOSTAL2 AS cod_postal, IFNULL(cue.CODIGOEMAI, 'Sin e-Mail') AS email," +
                                                            " SUBSTRING(cue.REF_DOMI_M,1,2500) AS referencia, cat.NOMBRE AS categoria, cue.CONTRATO AS contrato," +
                                                            " cmc.NOMBRE AS 'Rubro', pan.NOMBRE AS panel, cue.PANEL_TEL AS linea_enlace," +
                                                            " SUBSTR(cue.DATOS_ALARMA,1,2500) AS nota_panel, mdc.NOMBRE AS gprs, emp.NOMBRE AS operadora," +
                                                            " com.NUMEROCELU AS num_chip" +
                                                            " FROM bykom.abmacodigos cue" +
                                                            " LEFT JOIN pamacodigos pan" +
                                                            " ON cue.CODIGOALAR = pan.ORDER_ID" +
                                                            " LEFT JOIN bykom.calles cal" +
                                                            " ON cue.CALLE = cal.ORDER_ID" +
                                                            " LEFT JOIN bykom.calles en1" +
                                                            " ON cue.CALLE_ENT1 = en1.ORDER_ID" +
                                                            " LEFT JOIN bykom.calles en2" +
                                                            " ON cue.CALLE_ENT2 = en2.ORDER_ID" +
                                                            " LEFT JOIN bykom.ciudad ciu" +
                                                            " ON cue.CODIGOCIUD = ciu.CODIGOCIUD" +
                                                            " LEFT JOIN bykom.barrios bar" +
                                                            " ON cue.CODIGOBARR = bar.CODIGOBARR" +
                                                            " LEFT JOIN bykom.abrltipocategoria cat" +
                                                            " ON cue.CODIGOCATE = cat.ORDER_ID" +
                                                            " LEFT JOIN bykom.abrltipocomercio cmc" +
                                                            " ON cue.CODIGOCOM = cmc.ORDER_ID" +
                                                            " LEFT JOIN bykom.rcmacodigos rco" +
                                                            " ON cue.ID_RC = rco.ORDER_ID" +
                                                            " LEFT JOIN bykom.ed5200 com" +
                                                            " ON cue.ORDER_ID = com.ORDER_RL" +
                                                            " LEFT JOIN bykom.equipos_gprs mdc" +
                                                            " ON com.EQUIPO = mdc.ORDER_ID" +
                                                            " LEFT JOIN bykom.apnprestadoras emp" +
                                                            " ON com.APN1_PRESTADORA = emp.ORDER_ID" +
                                                            " WHERE cue.ORDER_ID = @order_id", conn);
                cmdSelect.Parameters.Add("@order_id", MySqlDbType.Int32);
                

                cmdSelect.Parameters["@order_id"].Value = order_id;
                

                /*MySqlCommand cmdSelect = new MySqlCommand("SELECT cue.ID_CL AS nro_cuenta, cue.PARTICION AS particion," +
                                                            " cue.CENTRALMON AS agrupacion, rco.CODIGOALFA AS representante," +
                                                            " cue.NOMBRE AS descripcion, cue.NOMBRE_DOS AS nombre," +
                                                            " cal.NOMBRE AS calle, cue.NUMERO AS numero, IFNULL(cue.PISO, 'Sin piso') AS piso," +
                                                            " IFNULL(cue.DPTO, 'Sin dpto') AS depto, IFNULL(en1.NOMBRE, 'Sin entrecalle') AS entre," +
                                                            " IFNULL(en2.NOMBRE, 'Sin entrecalle') AS y, bar.NOMBRE AS barrio," +
                                                            " ciu.NOMBRE AS ciudad, ciu.CODPOSTAL2 AS cod_postal, IFNULL(cue.CODIGOEMAI, 'Sin e-Mail') AS email," +
                                                            " SUBSTRING(cue.REF_DOMI_M,1,2500) AS referencia, cat.NOMBRE AS categoria, cue.CONTRATO AS contrato," +
                                                            " cmc.NOMBRE AS 'Rubro', pan.NOMBRE AS panel, cue.PANEL_TEL AS linea_enlace," +
                                                            " SUBSTR(cue.DATOS_ALARMA,1,2500) AS nota_panel, mdc.NOMBRE AS gprs, emp.NOMBRE AS operadora," +
                                                            " com.NUMEROCELU AS num_chip" +
                                                            " FROM bykom.abmacodigos cue" +
                                                            " INNER JOIN pamacodigos pan" +
                                                            " ON cue.CODIGOALAR = pan.ORDER_ID" +
                                                            " INNER JOIN bykom.calles cal" +
                                                            " ON cue.CALLE = cal.ORDER_ID" +
                                                            " INNER JOIN bykom.calles en1" +
                                                            " ON cue.CALLE_ENT1 = en1.ORDER_ID" +
                                                            " INNER JOIN bykom.calles en2" +
                                                            " ON cue.CALLE_ENT2 = en2.ORDER_ID" +
                                                            " INNER JOIN bykom.ciudad ciu" +
                                                            " ON cue.CODIGOCIUD = ciu.CODIGOCIUD" +
                                                            " INNER JOIN bykom.barrios bar" +
                                                            " ON cue.CODIGOBARR = bar.CODIGOBARR" +
                                                            " INNER JOIN bykom.abrltipocategoria cat" +
                                                            " ON cue.CODIGOCATE = cat.ORDER_ID" +
                                                            " INNER JOIN bykom.abrltipocomercio cmc" +
                                                            " ON cue.CODIGOCOM = cmc.ORDER_ID" +
                                                            " INNER JOIN bykom.rcmacodigos rco" +
                                                            " ON cue.ID_RC = rco.ORDER_ID" +
                                                            " LEFT JOIN bykom.ed5200 com" +
                                                            " ON cue.ORDER_ID = com.ORDER_RL" +
                                                            " LEFT JOIN bykom.equipos_gprs mdc" +
                                                            " ON com.EQUIPO = mdc.ORDER_ID" +
                                                            " LEFT JOIN bykom.apnprestadoras emp" +
                                                            " ON com.APN1_PRESTADORA = emp.ORDER_ID" +
                                                            " WHERE cue.ID_CL = @nro_cuenta" +
                                                            " AND cue.PARTICION = @part_cuenta" +
                                                            " AND cue.CENTRALMON = @agrup_cuenta" +
                                                            " AND rco.CODIGOALFA = @rep_cuenta;", conn);*/

                conn.Open();
                MySqlDataReader reader = cmdSelect.ExecuteReader();
                DataTable dtCuentas = new DataTable();
                //DataColumn nro_cuenta = new DataColumn("nro_cuenta", typeof(int));
                DataColumn colReferencia = new DataColumn("referencia_str", typeof(string));
                DataColumn colNotaPanel = new DataColumn("nota_panel_str", typeof(string));
                //dtCuentas.Columns.Add(nro_cuenta);
                dtCuentas.Columns.Add(colReferencia);
                dtCuentas.Columns.Add(colNotaPanel);
                if (reader != null)
                {
                    dtCuentas.Load(reader);
                }
                conn.Close();
                foreach (DataRow row in dtCuentas.Rows)
                {
                    row["referencia_str"] = Encoding.UTF8.GetString((Byte[])row["referencia"]);
                    row["nota_panel_str"] = Encoding.UTF8.GetString((Byte[])row["nota_panel"]);
                }
                dtCuentas.Columns.Remove("referencia");
                dtCuentas.Columns.Remove("nota_panel");
                return dtCuentas;
            }

        }
        
    }
}
