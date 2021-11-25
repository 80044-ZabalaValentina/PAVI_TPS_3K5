
namespace TPS_PAVI.GUILayer
{
    partial class frmObjetivosCurso
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboCursos = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvObjetivosCurso = new System.Windows.Forms.DataGridView();
            this.gbObjetivos = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtPuntos = new System.Windows.Forms.TextBox();
            this.cboObjetivos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjetivosCurso)).BeginInit();
            this.gbObjetivos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Curso:";
            // 
            // cboCursos
            // 
            this.cboCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCursos.FormattingEnabled = true;
            this.cboCursos.Location = new System.Drawing.Point(79, 72);
            this.cboCursos.Name = "cboCursos";
            this.cboCursos.Size = new System.Drawing.Size(166, 24);
            this.cboCursos.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSalir.Location = new System.Drawing.Point(693, 442);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 30);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnConsultar.Location = new System.Drawing.Point(251, 68);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(92, 29);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dgvObjetivosCurso
            // 
            this.dgvObjetivosCurso.AllowUserToAddRows = false;
            this.dgvObjetivosCurso.AllowUserToDeleteRows = false;
            this.dgvObjetivosCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjetivosCurso.Location = new System.Drawing.Point(5, 26);
            this.dgvObjetivosCurso.Name = "dgvObjetivosCurso";
            this.dgvObjetivosCurso.ReadOnly = true;
            this.dgvObjetivosCurso.RowTemplate.Height = 25;
            this.dgvObjetivosCurso.Size = new System.Drawing.Size(533, 242);
            this.dgvObjetivosCurso.TabIndex = 9;
            this.dgvObjetivosCurso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObjetivosCurso_CellClick);
            // 
            // gbObjetivos
            // 
            this.gbObjetivos.Controls.Add(this.label4);
            this.gbObjetivos.Controls.Add(this.btnEliminar);
            this.gbObjetivos.Controls.Add(this.btnEditar);
            this.gbObjetivos.Controls.Add(this.btnAgregar);
            this.gbObjetivos.Controls.Add(this.txtPuntos);
            this.gbObjetivos.Controls.Add(this.cboObjetivos);
            this.gbObjetivos.Controls.Add(this.label3);
            this.gbObjetivos.Controls.Add(this.label2);
            this.gbObjetivos.Controls.Add(this.dgvObjetivosCurso);
            this.gbObjetivos.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.gbObjetivos.Location = new System.Drawing.Point(9, 102);
            this.gbObjetivos.Name = "gbObjetivos";
            this.gbObjetivos.Size = new System.Drawing.Size(776, 321);
            this.gbObjetivos.TabIndex = 11;
            this.gbObjetivos.TabStop = false;
            this.gbObjetivos.Text = "Objetivos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Underline);
            this.label4.Location = new System.Drawing.Point(570, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Agregar un objetivo";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEliminar.Location = new System.Drawing.Point(107, 283);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(92, 25);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEditar.Location = new System.Drawing.Point(5, 283);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(96, 25);
            this.btnEditar.TabIndex = 16;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAgregar.Location = new System.Drawing.Point(636, 133);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(88, 28);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtPuntos
            // 
            this.txtPuntos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPuntos.Location = new System.Drawing.Point(636, 102);
            this.txtPuntos.Name = "txtPuntos";
            this.txtPuntos.Size = new System.Drawing.Size(79, 25);
            this.txtPuntos.TabIndex = 15;
            // 
            // cboObjetivos
            // 
            this.cboObjetivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObjetivos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboObjetivos.FormattingEnabled = true;
            this.cboObjetivos.Location = new System.Drawing.Point(636, 68);
            this.cboObjetivos.Name = "cboObjetivos";
            this.cboObjetivos.Size = new System.Drawing.Size(135, 25);
            this.cboObjetivos.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label3.Location = new System.Drawing.Point(559, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Puntos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label2.Location = new System.Drawing.Point(546, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Objetivo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(21, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(419, 30);
            this.label5.TabIndex = 18;
            this.label5.Text = "Actualización de los objetivos del curso";
            // 
            // btnLimpiarBusqueda
            // 
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(349, 68);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(167, 29);
            this.btnLimpiarBusqueda.TabIndex = 19;
            this.btnLimpiarBusqueda.Text = "Limpiar búsqueda";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            // 
            // frmObjetivosCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 484);
            this.Controls.Add(this.btnLimpiarBusqueda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbObjetivos);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.cboCursos);
            this.Controls.Add(this.label1);
            this.Name = "frmObjetivosCurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Objetivos del curso";
            this.Load += new System.EventHandler(this.frmObjetivosCurso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjetivosCurso)).EndInit();
            this.gbObjetivos.ResumeLayout(false);
            this.gbObjetivos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCursos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvObjetivosCurso;
        private System.Windows.Forms.GroupBox gbObjetivos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtPuntos;
        private System.Windows.Forms.ComboBox cboObjetivos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
    }
}