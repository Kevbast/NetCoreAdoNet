namespace NetCoreAdoNet
{
    partial class Form13ParametrosSalida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            cmbDepartamentos = new ComboBox();
            lstEmpleados = new ListBox();
            btnMostrarDatos = new Button();
            label3 = new Label();
            txtSumaSalarial = new TextBox();
            txtMediaSalarial = new TextBox();
            label4 = new Label();
            txtPersonas = new TextBox();
            lblPersonas = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 41);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 0;
            label1.Text = "DEPARTAMENTOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(387, 41);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 1;
            label2.Text = "Empleados";
            // 
            // cmbDepartamentos
            // 
            cmbDepartamentos.FormattingEnabled = true;
            cmbDepartamentos.Location = new Point(42, 59);
            cmbDepartamentos.Name = "cmbDepartamentos";
            cmbDepartamentos.Size = new Size(121, 23);
            cmbDepartamentos.TabIndex = 2;
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(387, 72);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(290, 304);
            lstEmpleados.TabIndex = 3;
            // 
            // btnMostrarDatos
            // 
            btnMostrarDatos.Location = new Point(51, 118);
            btnMostrarDatos.Name = "btnMostrarDatos";
            btnMostrarDatos.Size = new Size(112, 45);
            btnMostrarDatos.TabIndex = 4;
            btnMostrarDatos.Text = "Mostrar DATOS";
            btnMostrarDatos.UseVisualStyleBackColor = true;
            btnMostrarDatos.Click += btnMostrarDatos_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 183);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 5;
            label3.Text = "Suma Salarial";
            // 
            // txtSumaSalarial
            // 
            txtSumaSalarial.Location = new Point(51, 201);
            txtSumaSalarial.Name = "txtSumaSalarial";
            txtSumaSalarial.Size = new Size(100, 23);
            txtSumaSalarial.TabIndex = 6;
            // 
            // txtMediaSalarial
            // 
            txtMediaSalarial.Location = new Point(51, 260);
            txtMediaSalarial.Name = "txtMediaSalarial";
            txtMediaSalarial.Size = new Size(100, 23);
            txtMediaSalarial.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 242);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 7;
            label4.Text = "Media Salarial";
            // 
            // txtPersonas
            // 
            txtPersonas.Location = new Point(51, 316);
            txtPersonas.Name = "txtPersonas";
            txtPersonas.Size = new Size(100, 23);
            txtPersonas.TabIndex = 10;
            // 
            // lblPersonas
            // 
            lblPersonas.AutoSize = true;
            lblPersonas.Location = new Point(51, 298);
            lblPersonas.Name = "lblPersonas";
            lblPersonas.Size = new Size(54, 15);
            lblPersonas.TabIndex = 9;
            lblPersonas.Text = "Personas";
            // 
            // Form13ParametrosSalida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPersonas);
            Controls.Add(lblPersonas);
            Controls.Add(txtMediaSalarial);
            Controls.Add(label4);
            Controls.Add(txtSumaSalarial);
            Controls.Add(label3);
            Controls.Add(btnMostrarDatos);
            Controls.Add(lstEmpleados);
            Controls.Add(cmbDepartamentos);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form13ParametrosSalida";
            Text = "Form13ParametrosSalida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbDepartamentos;
        private ListBox lstEmpleados;
        private Button btnMostrarDatos;
        private Label label3;
        private TextBox txtSumaSalarial;
        private TextBox txtMediaSalarial;
        private Label label4;
        private TextBox txtPersonas;
        private Label lblPersonas;
    }
}