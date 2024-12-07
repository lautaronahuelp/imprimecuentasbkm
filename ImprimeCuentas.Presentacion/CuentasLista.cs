using ImprimeCuentas.Presentacion.Clases;
namespace ImprimeCuentas.Presentacion
{
    public partial class CuentasLista : Form
    {
        public CuentasLista()
        {
            InitializeComponent();
        }

        private void ObtieneYCarga()
        {
            //CuentaMySQL cuentas = new CuentaMySQL("1", 0, "2", "AB");

            //this.cuentasDataGridView.DataSource = cuentas.CuentasObtenidas;

            RepresentantesComercialesMySQL representantes = new RepresentantesComercialesMySQL();
            this.representanteComercialComboBox.DataSource = representantes.RepresentantesObtenidos;
            this.representanteComercialComboBox.DisplayMember = "nombre_mix";
            this.representanteComercialComboBox.ValueMember = "codigo";

        }

        private void CuentasLista_Load(object sender, EventArgs e)
        {
            this.ObtieneYCarga();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.cuentaTextBox.Text = string.Empty;
            this.particionNumericUpDown.Value = 0;
            this.particionCheckBox.Checked = false;
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string cuenta = null;
            int particion = -1;

            if(this.cuentaTextBox.Text != string.Empty) cuenta = this.cuentaTextBox.Text;
            if (this.particionCheckBox.Checked) particion = (int) this.particionNumericUpDown.Value;
            

            CuentaMySQL cuentas = new CuentaMySQL(cuenta, particion, "1", "AB");

            this.cuentasDataGridView.DataSource = cuentas.CuentasObtenidas;
        }
    }
}
