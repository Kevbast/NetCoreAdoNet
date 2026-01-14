namespace NetCoreAdoNet
{
    partial class Form05UpdateSalas
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
            lstSalas = new ListBox();
            label2 = new Label();
            txtNombre = new TextBox();
            btnUpdateSalas = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 40);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 0;
            label1.Text = "Salas";
            // 
            // lstSalas
            // 
            lstSalas.FormattingEnabled = true;
            lstSalas.Location = new Point(12, 70);
            lstSalas.Name = "lstSalas";
            lstSalas.Size = new Size(234, 319);
            lstSalas.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(314, 40);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 2;
            label2.Text = "Nuevo Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(314, 58);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 3;
            // 
            // btnUpdateSalas
            // 
            btnUpdateSalas.Location = new Point(314, 101);
            btnUpdateSalas.Name = "btnUpdateSalas";
            btnUpdateSalas.Size = new Size(100, 31);
            btnUpdateSalas.TabIndex = 4;
            btnUpdateSalas.Text = "Update Salas";
            btnUpdateSalas.UseVisualStyleBackColor = true;
            btnUpdateSalas.Click += btnUpdateSalas_Click;
            // 
            // Form05UpdateSalas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdateSalas);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(lstSalas);
            Controls.Add(label1);
            Name = "Form05UpdateSalas";
            Text = "Form05UpdateSalas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lstSalas;
        private Label label2;
        private TextBox txtNombre;
        private Button btnUpdateSalas;
    }
}