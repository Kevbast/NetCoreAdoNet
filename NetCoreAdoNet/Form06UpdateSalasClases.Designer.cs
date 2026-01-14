namespace NetCoreAdoNet
{
    partial class Form06UpdateSalasClases
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
            btnUpdateSalas = new Button();
            txtNombre = new TextBox();
            label2 = new Label();
            lstSalas = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnUpdateSalas
            // 
            btnUpdateSalas.BackColor = SystemColors.WindowFrame;
            btnUpdateSalas.Location = new Point(439, 112);
            btnUpdateSalas.Name = "btnUpdateSalas";
            btnUpdateSalas.Size = new Size(100, 31);
            btnUpdateSalas.TabIndex = 9;
            btnUpdateSalas.Text = "Update Salas";
            btnUpdateSalas.UseVisualStyleBackColor = false;
            btnUpdateSalas.Click += btnUpdateSalas_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(439, 69);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(439, 51);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 7;
            label2.Text = "Nuevo Nombre";
            // 
            // lstSalas
            // 
            lstSalas.FormattingEnabled = true;
            lstSalas.Location = new Point(137, 81);
            lstSalas.Name = "lstSalas";
            lstSalas.Size = new Size(234, 319);
            lstSalas.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(137, 51);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 5;
            label1.Text = "Salas";
            // 
            // Form06UpdateSalasClases
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdateSalas);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(lstSalas);
            Controls.Add(label1);
            Name = "Form06UpdateSalasClases";
            Text = "Form06UpdateSalasClases";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdateSalas;
        private TextBox txtNombre;
        private Label label2;
        private ListBox lstSalas;
        private Label label1;
    }
}