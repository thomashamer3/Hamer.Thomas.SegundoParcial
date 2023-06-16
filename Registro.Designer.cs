namespace Hamer.Thomas.SegundoParcial
{
    partial class Registro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro));
            this.lblGenerala = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btn_Registrarse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGenerala
            // 
            this.lblGenerala.AutoSize = true;
            this.lblGenerala.BackColor = System.Drawing.Color.Transparent;
            this.lblGenerala.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerala.Location = new System.Drawing.Point(228, 22);
            this.lblGenerala.Name = "lblGenerala";
            this.lblGenerala.Size = new System.Drawing.Size(124, 26);
            this.lblGenerala.TabIndex = 1;
            this.lblGenerala.Text = "La Generala";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(166, 69);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(81, 25);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(171, 97);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(248, 20);
            this.txtUsuario.TabIndex = 3;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.BackColor = System.Drawing.Color.Transparent;
            this.lblClave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.Location = new System.Drawing.Point(166, 144);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(59, 25);
            this.lblClave.TabIndex = 5;
            this.lblClave.Text = "Clave";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(171, 172);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(248, 20);
            this.txtClave.TabIndex = 6;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // btn_Registrarse
            // 
            this.btn_Registrarse.AutoSize = true;
            this.btn_Registrarse.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Registrarse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Registrarse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Registrarse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Registrarse.Location = new System.Drawing.Point(171, 216);
            this.btn_Registrarse.Name = "btn_Registrarse";
            this.btn_Registrarse.Size = new System.Drawing.Size(248, 30);
            this.btn_Registrarse.TabIndex = 7;
            this.btn_Registrarse.Text = "REGISTRARSE";
            this.btn_Registrarse.UseVisualStyleBackColor = false;
            this.btn_Registrarse.Click += new System.EventHandler(this.btn_Registrarse_Click);
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(59)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(546, 418);
            this.Controls.Add(this.btn_Registrarse);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblGenerala);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Registro_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGenerala;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btn_Registrarse;
    }
}