namespace NetCoreAdoNet
{
    partial class Form11ProcedimientosHospitalPlantilla
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
            txtIncremento = new TextBox();
            label2 = new Label();
            btnModificarSalarios = new Button();
            label3 = new Label();
            cmbHospitales = new ComboBox();
            lstPlantilla = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 32);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "HOSPITALES";
            // 
            // txtIncremento
            // 
            txtIncremento.Location = new Point(277, 59);
            txtIncremento.Name = "txtIncremento";
            txtIncremento.Size = new Size(118, 23);
            txtIncremento.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(277, 32);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 2;
            label2.Text = "INCREMENTO";
            // 
            // btnModificarSalarios
            // 
            btnModificarSalarios.Location = new Point(136, 109);
            btnModificarSalarios.Name = "btnModificarSalarios";
            btnModificarSalarios.Size = new Size(154, 23);
            btnModificarSalarios.TabIndex = 4;
            btnModificarSalarios.Text = "MODIFICAR SALARIOS";
            btnModificarSalarios.UseVisualStyleBackColor = true;
            btnModificarSalarios.Click += btnModificarSalarios_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 200);
            label3.Name = "label3";
            label3.Size = new Size(127, 15);
            label3.TabIndex = 5;
            label3.Text = "PERSONAS PLANTILLA";
            // 
            // cmbHospitales
            // 
            cmbHospitales.FormattingEnabled = true;
            cmbHospitales.Location = new Point(34, 59);
            cmbHospitales.Name = "cmbHospitales";
            cmbHospitales.Size = new Size(121, 23);
            cmbHospitales.TabIndex = 6;
            // 
            // lstPlantilla
            // 
            lstPlantilla.FormattingEnabled = true;
            lstPlantilla.Location = new Point(35, 218);
            lstPlantilla.Name = "lstPlantilla";
            lstPlantilla.Size = new Size(280, 184);
            lstPlantilla.TabIndex = 7;
            // 
            // Form11ProcedimientosHospitalPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstPlantilla);
            Controls.Add(cmbHospitales);
            Controls.Add(label3);
            Controls.Add(btnModificarSalarios);
            Controls.Add(txtIncremento);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form11ProcedimientosHospitalPlantilla";
            Text = "Form11ProcedimientosHospitalPlantilla";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIncremento;
        private Label label2;
        private Button btnModificarSalarios;
        private Label label3;
        private ComboBox cmbHospitales;
        private ListBox lstPlantilla;
    }
}