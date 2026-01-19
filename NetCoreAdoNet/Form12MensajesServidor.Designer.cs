namespace NetCoreAdoNet
{
    partial class Form12MensajesServidor
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
            txtId = new TextBox();
            txtNombre = new TextBox();
            label2 = new Label();
            txtLocalidad = new TextBox();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            lblServidor = new Label();
            lstDepartamentos = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 37);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "Id";
            // 
            // txtId
            // 
            txtId.Location = new Point(48, 55);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(48, 119);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 101);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(48, 187);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(100, 23);
            txtLocalidad.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 169);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 4;
            label3.Text = "Localidad";
            label3.Click += label3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(33, 241);
            button1.Name = "button1";
            button1.Size = new Size(125, 53);
            button1.TabIndex = 6;
            button1.Text = "Nuevo Departamento";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(287, 58);
            label4.Name = "label4";
            label4.Size = new Size(100, 15);
            label4.TabIndex = 7;
            label4.Text = "DEPARTAMENTOS";
            // 
            // lblServidor
            // 
            lblServidor.AutoSize = true;
            lblServidor.ForeColor = SystemColors.Highlight;
            lblServidor.Location = new Point(48, 364);
            lblServidor.Name = "lblServidor";
            lblServidor.Size = new Size(63, 15);
            lblServidor.TabIndex = 8;
            lblServidor.Text = "lblServidor";
            // 
            // lstDepartamentos
            // 
            lstDepartamentos.FormattingEnabled = true;
            lstDepartamentos.Location = new Point(287, 90);
            lstDepartamentos.Name = "lstDepartamentos";
            lstDepartamentos.Size = new Size(462, 289);
            lstDepartamentos.TabIndex = 9;
            // 
            // Form12MensajesServidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstDepartamentos);
            Controls.Add(lblServidor);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(txtLocalidad);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "Form12MensajesServidor";
            Text = "Form12MensajesServidor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtLocalidad;
        private Label label3;
        private Button button1;
        private Label label4;
        private Label lblServidor;
        private ListBox lstDepartamentos;
    }
}