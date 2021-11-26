
namespace TPS_PAVI.GUILayer
{
    partial class frmAvanceUsuarioCurso
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
            this.dgvUsuariosCurso = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCursos = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            this.btnActualizarAvance = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosCurso)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsuariosCurso
            // 
            this.dgvUsuariosCurso.AllowUserToAddRows = false;
            this.dgvUsuariosCurso.AllowUserToDeleteRows = false;
            this.dgvUsuariosCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuariosCurso.Location = new System.Drawing.Point(27, 144);
            this.dgvUsuariosCurso.Name = "dgvUsuariosCurso";
            this.dgvUsuariosCurso.ReadOnly = true;
            this.dgvUsuariosCurso.RowTemplate.Height = 25;
            this.dgvUsuariosCurso.Size = new System.Drawing.Size(644, 231);
            this.dgvUsuariosCurso.TabIndex = 0;
            this.dgvUsuariosCurso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuariosCurso_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Curso:";
            // 
            // cboCursos
            // 
            this.cboCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCursos.FormattingEnabled = true;
            this.cboCursos.Location = new System.Drawing.Point(87, 32);
            this.cboCursos.Name = "cboCursos";
            this.cboCursos.Size = new System.Drawing.Size(141, 21);
            this.cboCursos.TabIndex = 2;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnConsultar.Location = new System.Drawing.Point(244, 29);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(80, 27);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.Location = new System.Drawing.Point(27, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 59);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFiltrar.Location = new System.Drawing.Point(236, 18);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 27);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Usuario:";
            // 
            // btnLimpiarBusqueda
            // 
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(329, 29);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(160, 27);
            this.btnLimpiarBusqueda.TabIndex = 5;
            this.btnLimpiarBusqueda.Text = "Limpiar búsqueda";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            // 
            // btnActualizarAvance
            // 
            this.btnActualizarAvance.Enabled = false;
            this.btnActualizarAvance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnActualizarAvance.Location = new System.Drawing.Point(27, 380);
            this.btnActualizarAvance.Name = "btnActualizarAvance";
            this.btnActualizarAvance.Size = new System.Drawing.Size(125, 27);
            this.btnActualizarAvance.TabIndex = 6;
            this.btnActualizarAvance.Text = "Actualizar avance";
            this.btnActualizarAvance.UseVisualStyleBackColor = true;
            this.btnActualizarAvance.Click += new System.EventHandler(this.btnActualizarAvance_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button4.Location = new System.Drawing.Point(591, 380);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 27);
            this.button4.TabIndex = 7;
            this.button4.Text = "Salir";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(87, 18);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(136, 29);
            this.txtUsuario.TabIndex = 6;
            // 
            // frmAvanceUsuarioCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 431);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnActualizarAvance);
            this.Controls.Add(this.btnLimpiarBusqueda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.cboCursos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvUsuariosCurso);
            this.Name = "frmAvanceUsuarioCurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avance usuarios por curso";
            this.Load += new System.EventHandler(this.frmAvanceUsuarioCurso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosCurso)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuariosCurso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCursos;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
        private System.Windows.Forms.Button btnActualizarAvance;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtUsuario;
    }
}