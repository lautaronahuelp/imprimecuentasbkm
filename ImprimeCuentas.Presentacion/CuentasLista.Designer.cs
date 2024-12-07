namespace ImprimeCuentas.Presentacion
{
    partial class CuentasLista
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
            limpiarButton = new Button();
            buscarButton = new Button();
            cuentaLabel = new Label();
            cuentaTextBox = new TextBox();
            particionLabel = new Label();
            particionNumericUpDown = new NumericUpDown();
            particionCheckBox = new CheckBox();
            representanteComercialComboBox = new ComboBox();
            representanteComercialLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)cuentasDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)particionNumericUpDown).BeginInit();
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
            // limpiarButton
            // 
            limpiarButton.Location = new Point(684, 36);
            limpiarButton.Name = "limpiarButton";
            limpiarButton.Size = new Size(75, 23);
            limpiarButton.TabIndex = 3;
            limpiarButton.Text = "Limpiar";
            limpiarButton.UseVisualStyleBackColor = true;
            limpiarButton.Click += limpiarButton_Click;
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(684, 65);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(75, 23);
            buscarButton.TabIndex = 4;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            buscarButton.Click += buscarButton_Click;
            // 
            // cuentaLabel
            // 
            cuentaLabel.AutoSize = true;
            cuentaLabel.Location = new Point(41, 39);
            cuentaLabel.Name = "cuentaLabel";
            cuentaLabel.Size = new Size(48, 15);
            cuentaLabel.TabIndex = 8;
            cuentaLabel.Text = "Cuenta:";
            // 
            // cuentaTextBox
            // 
            cuentaTextBox.Location = new Point(95, 36);
            cuentaTextBox.Name = "cuentaTextBox";
            cuentaTextBox.Size = new Size(100, 23);
            cuentaTextBox.TabIndex = 7;
            // 
            // particionLabel
            // 
            particionLabel.AutoSize = true;
            particionLabel.Location = new Point(218, 39);
            particionLabel.Name = "particionLabel";
            particionLabel.Size = new Size(57, 15);
            particionLabel.TabIndex = 10;
            particionLabel.Text = "Partición:";
            // 
            // particionNumericUpDown
            // 
            particionNumericUpDown.Location = new Point(281, 36);
            particionNumericUpDown.Name = "particionNumericUpDown";
            particionNumericUpDown.Size = new Size(42, 23);
            particionNumericUpDown.TabIndex = 11;
            // 
            // particionCheckBox
            // 
            particionCheckBox.AutoSize = true;
            particionCheckBox.Location = new Point(329, 41);
            particionCheckBox.Name = "particionCheckBox";
            particionCheckBox.Size = new Size(15, 14);
            particionCheckBox.TabIndex = 12;
            particionCheckBox.UseVisualStyleBackColor = true;
            // 
            // representanteComercialComboBox
            // 
            representanteComercialComboBox.FormattingEnabled = true;
            representanteComercialComboBox.Location = new Point(137, 65);
            representanteComercialComboBox.Name = "representanteComercialComboBox";
            representanteComercialComboBox.Size = new Size(237, 23);
            representanteComercialComboBox.TabIndex = 13;
            // 
            // representanteComercialLabel
            // 
            representanteComercialLabel.AutoSize = true;
            representanteComercialLabel.Location = new Point(41, 69);
            representanteComercialLabel.Name = "representanteComercialLabel";
            representanteComercialLabel.Size = new Size(90, 15);
            representanteComercialLabel.TabIndex = 14;
            representanteComercialLabel.Text = "Rep. Comercial:";
            // 
            // CuentasLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 514);
            Controls.Add(representanteComercialLabel);
            Controls.Add(representanteComercialComboBox);
            Controls.Add(particionCheckBox);
            Controls.Add(particionNumericUpDown);
            Controls.Add(particionLabel);
            Controls.Add(cuentaLabel);
            Controls.Add(cuentaTextBox);
            Controls.Add(buscarButton);
            Controls.Add(limpiarButton);
            Controls.Add(cuentasDataGridView);
            Name = "CuentasLista";
            Text = "Listado de Cuentas";
            Load += CuentasLista_Load;
            ((System.ComponentModel.ISupportInitialize)cuentasDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)particionNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView cuentasDataGridView;
        private Button limpiarButton;
        private Button buscarButton;
        private Label cuentaLabel;
        private TextBox cuentaTextBox;
        private Label particionLabel;
        private NumericUpDown particionNumericUpDown;
        private CheckBox particionCheckBox;
        private ComboBox representanteComercialComboBox;
        private Label representanteComercialLabel;
    }
}
