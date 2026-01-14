namespace NetCoreAdoNet
{
    partial class Form04EliminarPlantilla
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
            lstPlantilla = new ListBox();
            btnEliminarEmpPlantilla = new Button();
            txtEmpNoPlantilla = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // lstPlantilla
            // 
            lstPlantilla.FormattingEnabled = true;
            lstPlantilla.Location = new Point(368, 68);
            lstPlantilla.Name = "lstPlantilla";
            lstPlantilla.Size = new Size(257, 334);
            lstPlantilla.TabIndex = 9;
            // 
            // btnEliminarEmpPlantilla
            // 
            btnEliminarEmpPlantilla.Location = new Point(85, 110);
            btnEliminarEmpPlantilla.Name = "btnEliminarEmpPlantilla";
            btnEliminarEmpPlantilla.Size = new Size(115, 67);
            btnEliminarEmpPlantilla.TabIndex = 8;
            btnEliminarEmpPlantilla.Text = "ELIMINAR EMPLEADO PLANTILLA";
            btnEliminarEmpPlantilla.UseVisualStyleBackColor = true;
            btnEliminarEmpPlantilla.Click += btnEliminarEmpPlantilla_Click;
            // 
            // txtEmpNoPlantilla
            // 
            txtEmpNoPlantilla.Location = new Point(85, 68);
            txtEmpNoPlantilla.Name = "txtEmpNoPlantilla";
            txtEmpNoPlantilla.Size = new Size(100, 23);
            txtEmpNoPlantilla.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(368, 39);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 6;
            label2.Text = "Plantilla";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 39);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 5;
            label1.Text = "Introduce el ID";
            // 
            // Form04EliminarPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstPlantilla);
            Controls.Add(btnEliminarEmpPlantilla);
            Controls.Add(txtEmpNoPlantilla);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form04EliminarPlantilla";
            Text = "Form04EliminarPlantilla";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstPlantilla;
        private Button btnEliminarEmpPlantilla;
        private TextBox txtEmpNoPlantilla;
        private Label label2;
        private Label label1;
    }
}