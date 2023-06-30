namespace Hamer.Thomas.SegundoParcial
{
    partial class SalasPartida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalasPartida));
            this.panelSalas = new System.Windows.Forms.Panel();
            this.lblOrdenar = new System.Windows.Forms.Label();
            this.btnPuntosJugadorDos = new System.Windows.Forms.Button();
            this.btnPuntosJugadorUno = new System.Windows.Forms.Button();
            this.btnEstadoSala = new System.Windows.Forms.Button();
            this.btnCreadorSala = new System.Windows.Forms.Button();
            this.btnCrearSala = new System.Windows.Forms.Button();
            this.btnEstadisticasUsuario = new System.Windows.Forms.Button();
            this.btnActualizarSalas = new System.Windows.Forms.Button();
            this.pictureBoxPantallaDeCarga = new System.Windows.Forms.PictureBox();
            this.lblSalas = new System.Windows.Forms.Label();
            this.DGVSalas = new System.Windows.Forms.DataGridView();
            this.nombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PuntosJ1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PuntosJ2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TurnosRestantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiempoDePartida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCreador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.panelSalas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPantallaDeCarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSalas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSalas
            // 
            this.panelSalas.Controls.Add(this.lblOrdenar);
            this.panelSalas.Controls.Add(this.btnPuntosJugadorDos);
            this.panelSalas.Controls.Add(this.btnPuntosJugadorUno);
            this.panelSalas.Controls.Add(this.btnEstadoSala);
            this.panelSalas.Controls.Add(this.btnCreadorSala);
            this.panelSalas.Controls.Add(this.btnCrearSala);
            this.panelSalas.Controls.Add(this.btnEstadisticasUsuario);
            this.panelSalas.Controls.Add(this.btnActualizarSalas);
            this.panelSalas.Controls.Add(this.pictureBoxPantallaDeCarga);
            this.panelSalas.Controls.Add(this.lblSalas);
            this.panelSalas.Controls.Add(this.DGVSalas);
            this.panelSalas.Controls.Add(this.lblNombreUsuario);
            this.panelSalas.Controls.Add(this.lblBienvenida);
            this.panelSalas.Location = new System.Drawing.Point(12, -4);
            this.panelSalas.Name = "panelSalas";
            this.panelSalas.Size = new System.Drawing.Size(856, 561);
            this.panelSalas.TabIndex = 0;
            // 
            // lblOrdenar
            // 
            this.lblOrdenar.AutoSize = true;
            this.lblOrdenar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenar.ForeColor = System.Drawing.SystemColors.Control;
            this.lblOrdenar.Location = new System.Drawing.Point(25, 461);
            this.lblOrdenar.Name = "lblOrdenar";
            this.lblOrdenar.Size = new System.Drawing.Size(93, 22);
            this.lblOrdenar.TabIndex = 13;
            this.lblOrdenar.Text = "ORDENAR";
            // 
            // btnPuntosJugadorDos
            // 
            this.btnPuntosJugadorDos.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPuntosJugadorDos.Location = new System.Drawing.Point(177, 522);
            this.btnPuntosJugadorDos.Name = "btnPuntosJugadorDos";
            this.btnPuntosJugadorDos.Size = new System.Drawing.Size(152, 30);
            this.btnPuntosJugadorDos.TabIndex = 12;
            this.btnPuntosJugadorDos.Text = "PUNTOS JUGADOR2";
            this.btnPuntosJugadorDos.UseVisualStyleBackColor = true;
            this.btnPuntosJugadorDos.Click += new System.EventHandler(this.btnPuntosJugadorDos_Click);
            // 
            // btnPuntosJugadorUno
            // 
            this.btnPuntosJugadorUno.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPuntosJugadorUno.Location = new System.Drawing.Point(18, 522);
            this.btnPuntosJugadorUno.Name = "btnPuntosJugadorUno";
            this.btnPuntosJugadorUno.Size = new System.Drawing.Size(153, 30);
            this.btnPuntosJugadorUno.TabIndex = 11;
            this.btnPuntosJugadorUno.Text = "PUNTOS JUGADOR1";
            this.btnPuntosJugadorUno.UseVisualStyleBackColor = true;
            this.btnPuntosJugadorUno.Click += new System.EventHandler(this.btnPuntosJugadorUno_Click);
            // 
            // btnEstadoSala
            // 
            this.btnEstadoSala.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadoSala.Location = new System.Drawing.Point(114, 486);
            this.btnEstadoSala.Name = "btnEstadoSala";
            this.btnEstadoSala.Size = new System.Drawing.Size(102, 30);
            this.btnEstadoSala.TabIndex = 10;
            this.btnEstadoSala.Text = "ESTADO";
            this.btnEstadoSala.UseVisualStyleBackColor = true;
            this.btnEstadoSala.Click += new System.EventHandler(this.btnEstadoSala_Click);
            // 
            // btnCreadorSala
            // 
            this.btnCreadorSala.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreadorSala.Location = new System.Drawing.Point(18, 486);
            this.btnCreadorSala.Name = "btnCreadorSala";
            this.btnCreadorSala.Size = new System.Drawing.Size(90, 30);
            this.btnCreadorSala.TabIndex = 9;
            this.btnCreadorSala.Text = "CREADOR";
            this.btnCreadorSala.UseVisualStyleBackColor = true;
            this.btnCreadorSala.Click += new System.EventHandler(this.btnCreadorSala_Click);
            // 
            // btnCrearSala
            // 
            this.btnCrearSala.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearSala.Location = new System.Drawing.Point(355, 486);
            this.btnCrearSala.Name = "btnCrearSala";
            this.btnCrearSala.Size = new System.Drawing.Size(179, 30);
            this.btnCrearSala.TabIndex = 8;
            this.btnCrearSala.Text = "CREAR SALA";
            this.btnCrearSala.UseVisualStyleBackColor = true;
            this.btnCrearSala.Click += new System.EventHandler(this.btnCrearSala_Click);
            // 
            // btnEstadisticasUsuario
            // 
            this.btnEstadisticasUsuario.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadisticasUsuario.Location = new System.Drawing.Point(624, 486);
            this.btnEstadisticasUsuario.Name = "btnEstadisticasUsuario";
            this.btnEstadisticasUsuario.Size = new System.Drawing.Size(179, 30);
            this.btnEstadisticasUsuario.TabIndex = 7;
            this.btnEstadisticasUsuario.Text = "ESTADISTICAS USUARIO";
            this.btnEstadisticasUsuario.UseVisualStyleBackColor = true;
            this.btnEstadisticasUsuario.Click += new System.EventHandler(this.btnEstadisticasUsuario_Click);
            // 
            // btnActualizarSalas
            // 
            this.btnActualizarSalas.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarSalas.Location = new System.Drawing.Point(646, 6);
            this.btnActualizarSalas.Name = "btnActualizarSalas";
            this.btnActualizarSalas.Size = new System.Drawing.Size(179, 30);
            this.btnActualizarSalas.TabIndex = 6;
            this.btnActualizarSalas.Text = "ACTUALIZAR SALAS";
            this.btnActualizarSalas.UseVisualStyleBackColor = true;
            this.btnActualizarSalas.Click += new System.EventHandler(this.btnActualizarSalas_Click);
            // 
            // pictureBoxPantallaDeCarga
            // 
            this.pictureBoxPantallaDeCarga.Image = global::Hamer.Thomas.SegundoParcial.Properties.Resources.cargando;
            this.pictureBoxPantallaDeCarga.Location = new System.Drawing.Point(284, 146);
            this.pictureBoxPantallaDeCarga.Name = "pictureBoxPantallaDeCarga";
            this.pictureBoxPantallaDeCarga.Size = new System.Drawing.Size(297, 243);
            this.pictureBoxPantallaDeCarga.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxPantallaDeCarga.TabIndex = 4;
            this.pictureBoxPantallaDeCarga.TabStop = false;
            this.pictureBoxPantallaDeCarga.Visible = false;
            // 
            // lblSalas
            // 
            this.lblSalas.AutoSize = true;
            this.lblSalas.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalas.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSalas.Location = new System.Drawing.Point(415, 14);
            this.lblSalas.Name = "lblSalas";
            this.lblSalas.Size = new System.Drawing.Size(63, 22);
            this.lblSalas.TabIndex = 3;
            this.lblSalas.Text = "SALAS";
            // 
            // DGVSalas
            // 
            this.DGVSalas.AllowUserToAddRows = false;
            this.DGVSalas.AllowUserToDeleteRows = false;
            this.DGVSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSalas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreUsuario,
            this.estado,
            this.PuntosJ1,
            this.PuntosJ2,
            this.TurnosRestantes,
            this.TiempoDePartida,
            this.ID,
            this.IdCreador});
            this.DGVSalas.Location = new System.Drawing.Point(58, 42);
            this.DGVSalas.Name = "DGVSalas";
            this.DGVSalas.ReadOnly = true;
            this.DGVSalas.Size = new System.Drawing.Size(745, 416);
            this.DGVSalas.TabIndex = 2;
            this.DGVSalas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSalas_CellClick);
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.HeaderText = "Creador";
            this.nombreUsuario.Name = "nombreUsuario";
            this.nombreUsuario.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // PuntosJ1
            // 
            this.PuntosJ1.HeaderText = "Puntos J1";
            this.PuntosJ1.Name = "PuntosJ1";
            this.PuntosJ1.ReadOnly = true;
            // 
            // PuntosJ2
            // 
            this.PuntosJ2.HeaderText = "Puntos J2";
            this.PuntosJ2.Name = "PuntosJ2";
            this.PuntosJ2.ReadOnly = true;
            // 
            // TurnosRestantes
            // 
            this.TurnosRestantes.HeaderText = "Turnos Restantes";
            this.TurnosRestantes.Name = "TurnosRestantes";
            this.TurnosRestantes.ReadOnly = true;
            // 
            // TiempoDePartida
            // 
            this.TiempoDePartida.HeaderText = "Tiempo de partida";
            this.TiempoDePartida.Name = "TiempoDePartida";
            this.TiempoDePartida.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID de Sala";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // IdCreador
            // 
            this.IdCreador.HeaderText = "idcreador";
            this.IdCreador.Name = "IdCreador";
            this.IdCreador.ReadOnly = true;
            this.IdCreador.Visible = false;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNombreUsuario.Location = new System.Drawing.Point(114, 14);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(136, 22);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "nombreUsuario";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBienvenida.Location = new System.Drawing.Point(3, 14);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(105, 22);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Bienvenido:";
            // 
            // SalasPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(59)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(877, 557);
            this.Controls.Add(this.panelSalas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalasPartida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SalasPartida_FormClosing);
            this.Load += new System.EventHandler(this.Salas_Load);
            this.panelSalas.ResumeLayout(false);
            this.panelSalas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPantallaDeCarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSalas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSalas;
        private System.Windows.Forms.DataGridView DGVSalas;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.PictureBox pictureBoxPantallaDeCarga;
        private System.Windows.Forms.Label lblSalas;
        private System.Windows.Forms.Button btnEstadisticasUsuario;
        private System.Windows.Forms.Button btnActualizarSalas;
        private System.Windows.Forms.Label lblOrdenar;
        private System.Windows.Forms.Button btnPuntosJugadorDos;
        private System.Windows.Forms.Button btnPuntosJugadorUno;
        private System.Windows.Forms.Button btnEstadoSala;
        private System.Windows.Forms.Button btnCreadorSala;
        private System.Windows.Forms.Button btnCrearSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuntosJ1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuntosJ2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TurnosRestantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiempoDePartida;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCreador;
    }
}