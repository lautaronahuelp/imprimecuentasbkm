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

            AgrupacionesReceptorasMySQL agrupaciones = new AgrupacionesReceptorasMySQL();
            this.agrupacionComboBox.DataSource = agrupaciones.AgrupacionesObtenidas;
            this.agrupacionComboBox.DisplayMember = "nombre";
            this.agrupacionComboBox.ValueMember = "id";

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
            this.representanteComercialComboBox.SelectedValue = " ";
            this.agrupacionComboBox.SelectedValue = -1;
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string cuenta = null;
            int particion = -1;
            string representante = null;
            string agrupacion = null;

            if (this.cuentaTextBox.Text != string.Empty) cuenta = this.cuentaTextBox.Text;
            if (this.particionCheckBox.Checked) particion = (int)this.particionNumericUpDown.Value;
            if (this.representanteComercialComboBox.SelectedValue != null) representante = (string)this.representanteComercialComboBox.SelectedValue;
            if (this.agrupacionComboBox.SelectedValue != null) agrupacion = ((int)this.agrupacionComboBox.SelectedValue).ToString();
            MessageBox.Show($">{this.agrupacionComboBox.SelectedValue}<", "debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CuentaMySQL cuentas = new CuentaMySQL(cuenta, particion, agrupacion, representante);

            this.cuentasDataGridView.DataSource = cuentas.CuentasObtenidas;
        }

    }
}
