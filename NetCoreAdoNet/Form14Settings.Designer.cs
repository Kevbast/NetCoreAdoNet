namespace NetCoreAdoNet
{
    partial class Form14Settings
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
            button1 = new Button();
            lblConexion = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnLeerHelperConfiguration = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(37, 27);
            button1.Name = "button1";
            button1.Size = new Size(161, 45);
            button1.TabIndex = 0;
            button1.Text = "Leer Settings";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblConexion
            // 
            lblConexion.AutoSize = true;
            lblConexion.Location = new Point(49, 110);
            lblConexion.Name = "lblConexion";
            lblConexion.Size = new Size(71, 15);
            lblConexion.TabIndex = 1;
            lblConexion.Text = "lblConexion";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(37, 160);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(298, 215);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(429, 160);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(328, 215);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // btnLeerHelperConfiguration
            // 
            btnLeerHelperConfiguration.Location = new Point(503, 27);
            btnLeerHelperConfiguration.Name = "btnLeerHelperConfiguration";
            btnLeerHelperConfiguration.Size = new Size(180, 65);
            btnLeerHelperConfiguration.TabIndex = 4;
            btnLeerHelperConfiguration.Text = "LEER HELPER CONFIGURATION";
            btnLeerHelperConfiguration.UseVisualStyleBackColor = true;
            btnLeerHelperConfiguration.Click += btnLeerHelperConfiguration_Click;
            // 
            // Form14Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLeerHelperConfiguration);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(lblConexion);
            Controls.Add(button1);
            Name = "Form14Settings";
            Text = "Form14Settings";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label lblConexion;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnLeerHelperConfiguration;
    }
}