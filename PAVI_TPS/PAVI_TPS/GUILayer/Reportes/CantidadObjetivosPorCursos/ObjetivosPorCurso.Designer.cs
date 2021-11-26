
namespace PAVI_TPS.GUILayer.Reportes.CantidadObjetivosPorCursos
{
    partial class frmObjetivosPorCurso
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
            this.btnGenerar = new System.Windows.Forms.Button();
            this.rpvObjetivos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(22, 26);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(210, 32);
            this.btnGenerar.TabIndex = 0;
            this.btnGenerar.Text = "Generar reporte";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // rpvObjetivos
            // 
            this.rpvObjetivos.LocalReport.ReportEmbeddedResource = "PAVI_TPS.GUILayer.Reportes.CantidadObjetivosPorCursos.ReportObjetivosPorCursos.rd" +
    "lc";
            this.rpvObjetivos.Location = new System.Drawing.Point(22, 82);
            this.rpvObjetivos.Name = "rpvObjetivos";
            this.rpvObjetivos.ServerReport.BearerToken = null;
            this.rpvObjetivos.Size = new System.Drawing.Size(754, 343);
            this.rpvObjetivos.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(647, 448);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(129, 32);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmObjetivosPorCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.rpvObjetivos);
            this.Controls.Add(this.btnGenerar);
            this.Name = "frmObjetivosPorCurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Objetivos por curso";
            this.Load += new System.EventHandler(this.ObjetivosPorCurso_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerar;
        private Microsoft.Reporting.WinForms.ReportViewer rpvObjetivos;
        private System.Windows.Forms.Button btnSalir;
    }
}