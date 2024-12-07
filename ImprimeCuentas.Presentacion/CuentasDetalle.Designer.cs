namespace ImprimeCuentas.Presentacion
{
    partial class CuentasDetalle
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cuentasDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)cuentasDataGridView).BeginInit();
            SuspendLayout();
            // 
            // cuentasDataGridView
            // 
            cuentasDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cuentasDataGridView.Location = new Point(12, 91);
            cuentasDataGridView.Name = "cuentasDataGridView";
            cuentasDataGridView.ReadOnly = true;
            cuentasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cuentasDataGridView.Size = new Size(776, 394);
            cuentasDataGridView.TabIndex = 0;
            // 
            // CuentasLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 514);
            Controls.Add(cuentasDataGridView);
            Name = "CuentasLista";
            Text = "Cuenta";
            Load += CuentasLista_Load;
            ((System.ComponentModel.ISupportInitialize)cuentasDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView cuentasDataGridView;
    }
}
