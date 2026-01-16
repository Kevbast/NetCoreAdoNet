namespace NetCoreAdoNet
{
    partial class Form10UpdateEmpleadosOficios
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
            lstOficios = new ListBox();
            lstEmpleados = new ListBox();
            label2 = new Label();
            label3 = new Label();
            txtIncrementoSalario = new TextBox();
            btnSubirSalario = new Button();
            lblSumaSalarial = new Label();
            lblMediaSalarial = new Label();
            lblSalarioMaximo = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 42);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "Oficios";
            // 
            // lstOficios
            // 
            lstOficios.FormattingEnabled = true;
            lstOficios.Location = new Point(46, 71);
            lstOficios.Name = "lstOficios";
            lstOficios.Size = new Size(176, 334);
            lstOficios.TabIndex = 1;
            lstOficios.SelectedIndexChanged += lstOficios_SelectedIndexChanged;
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(257, 71);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(176, 334);
            lstEmpleados.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(257, 42);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 2;
            label2.Text = "Empleados";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(514, 42);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 4;
            label3.Text = "Incremento Salarial";
            // 
            // txtIncrementoSalario
            // 
            txtIncrementoSalario.Location = new Point(514, 71);
            txtIncrementoSalario.Name = "txtIncrementoSalario";
            txtIncrementoSalario.Size = new Size(100, 23);
            txtIncrementoSalario.TabIndex = 5;
            // 
            // btnSubirSalario
            // 
            btnSubirSalario.Location = new Point(514, 113);
            btnSubirSalario.Name = "btnSubirSalario";
            btnSubirSalario.Size = new Size(75, 23);
            btnSubirSalario.TabIndex = 6;
            btnSubirSalario.Text = "Subir Salarios";
            btnSubirSalario.UseVisualStyleBackColor = true;
            btnSubirSalario.Click += btnSubirSalario_Click;
            // 
            // lblSumaSalarial
            // 
            lblSumaSalarial.AutoSize = true;
            lblSumaSalarial.Location = new Point(452, 335);
            lblSumaSalarial.Name = "lblSumaSalarial";
            lblSumaSalarial.Size = new Size(87, 15);
            lblSumaSalarial.TabIndex = 7;
            lblSumaSalarial.Text = "lblSumaSalarial";
            // 
            // lblMediaSalarial
            // 
            lblMediaSalarial.AutoSize = true;
            lblMediaSalarial.Location = new Point(452, 364);
            lblMediaSalarial.Name = "lblMediaSalarial";
            lblMediaSalarial.Size = new Size(90, 15);
            lblMediaSalarial.TabIndex = 8;
            lblMediaSalarial.Text = "lblMediaSalarial";
            // 
            // lblSalarioMaximo
            // 
            lblSalarioMaximo.AutoSize = true;
            lblSalarioMaximo.Location = new Point(452, 390);
            lblSalarioMaximo.Name = "lblSalarioMaximo";
            lblSalarioMaximo.Size = new Size(99, 15);
            lblSalarioMaximo.TabIndex = 9;
            lblSalarioMaximo.Text = "lblSalarioMaximo";
            // 
            // Form10UpdateEmpleadosOficios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblSalarioMaximo);
            Controls.Add(lblMediaSalarial);
            Controls.Add(lblSumaSalarial);
            Controls.Add(btnSubirSalario);
            Controls.Add(txtIncrementoSalario);
            Controls.Add(label3);
            Controls.Add(lstEmpleados);
            Controls.Add(label2);
            Controls.Add(lstOficios);
            Controls.Add(label1);
            Name = "Form10UpdateEmpleadosOficios";
            Text = "Form10UpdateEmpleadosOficios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lstOficios;
        private ListBox lstEmpleados;
        private Label label2;
        private Label label3;
        private TextBox txtIncrementoSalario;
        private Button btnSubirSalario;
        private Label lblSumaSalarial;
        private Label lblMediaSalarial;
        private Label lblSalarioMaximo;
    }
}