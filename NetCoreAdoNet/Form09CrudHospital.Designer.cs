namespace NetCoreAdoNet
{
    partial class Form09CrudHospital
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
            btnModificar = new Button();
            btnInsertar = new Button();
            btnEliminar = new Button();
            txtDireccion = new TextBox();
            label4 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtIdHospital = new TextBox();
            label2 = new Label();
            lstHospitales = new ListBox();
            label1 = new Label();
            txtTelefono = new TextBox();
            label5 = new Label();
            txtNumCamas = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(550, 392);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(100, 23);
            btnModificar.TabIndex = 22;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(550, 336);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(100, 23);
            btnInsertar.TabIndex = 21;
            btnInsertar.Text = "INSERTAR";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(192, 379);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 20;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(550, 189);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(550, 171);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 18;
            label4.Text = "DIRECCION";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(550, 133);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(550, 115);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 16;
            label3.Text = "Nombre";
            // 
            // txtIdHospital
            // 
            txtIdHospital.Location = new Point(550, 77);
            txtIdHospital.Name = "txtIdHospital";
            txtIdHospital.Size = new Size(100, 23);
            txtIdHospital.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(550, 59);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 14;
            label2.Text = "HOSPITAL_COD";
            // 
            // lstHospitales
            // 
            lstHospitales.FormattingEnabled = true;
            lstHospitales.Location = new Point(12, 79);
            lstHospitales.Name = "lstHospitales";
            lstHospitales.Size = new Size(506, 259);
            lstHospitales.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(150, 49);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 12;
            label1.Text = "HOSPITALES";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(550, 247);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(550, 229);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 23;
            label5.Text = "TELEFONO";
            // 
            // txtNumCamas
            // 
            txtNumCamas.Location = new Point(550, 302);
            txtNumCamas.Name = "txtNumCamas";
            txtNumCamas.Size = new Size(100, 23);
            txtNumCamas.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(550, 284);
            label6.Name = "label6";
            label6.Size = new Size(118, 15);
            label6.TabIndex = 25;
            label6.Text = "NUMERO DE CAMAS";
            // 
            // Form09CrudHospital
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtNumCamas);
            Controls.Add(label6);
            Controls.Add(txtTelefono);
            Controls.Add(label5);
            Controls.Add(btnModificar);
            Controls.Add(btnInsertar);
            Controls.Add(btnEliminar);
            Controls.Add(txtDireccion);
            Controls.Add(label4);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(txtIdHospital);
            Controls.Add(label2);
            Controls.Add(lstHospitales);
            Controls.Add(label1);
            Name = "Form09CrudHospital";
            Text = "Form09CrudHospital";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnModificar;
        private Button btnInsertar;
        private Button btnEliminar;
        private TextBox txtDireccion;
        private Label label4;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtIdHospital;
        private Label label2;
        private ListBox lstHospitales;
        private Label label1;
        private TextBox txtTelefono;
        private Label label5;
        private TextBox txtNumCamas;
        private Label label6;
    }
}