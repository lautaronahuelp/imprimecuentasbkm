using ImprimeCuentas.Presentacion.Clases;
namespace ImprimeCuentas.Presentacion
{
    public partial class CuentaDetalle : Form
    {
        public CuentaDetalle()
        {
            InitializeComponent();
        }

        private void ObtieneYCarga()
        {
            CuentaMySQL cuentas = new CuentaMySQL("1", 0, "2", "AB");

            this.cuentasDataGridView.DataSource = cuentas.CuentasObtenidas;
        }

        private void CuentasLista_Load(object sender, EventArgs e)
        {
            this.ObtieneYCarga();
        }
    }
}
