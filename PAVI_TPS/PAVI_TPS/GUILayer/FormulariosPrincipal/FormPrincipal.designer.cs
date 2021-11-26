
namespace TPS_PAVI.Formularios
{
    partial class frmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objetivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarObjetivosDelCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarAvanceUsuariosPorCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoUsuariosPorCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cantidadObjetivosPorCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.soporteToolStripMenuItem,
            this.operacionesToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(480, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // soporteToolStripMenuItem
            // 
            this.soporteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriaToolStripMenuItem,
            this.cursosToolStripMenuItem,
            this.objetivosToolStripMenuItem});
            this.soporteToolStripMenuItem.Name = "soporteToolStripMenuItem";
            this.soporteToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.soporteToolStripMenuItem.Text = "Soporte";
            // 
            // categoriaToolStripMenuItem
            // 
            this.categoriaToolStripMenuItem.Name = "categoriaToolStripMenuItem";
            this.categoriaToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.categoriaToolStripMenuItem.Text = "Categorias";
            this.categoriaToolStripMenuItem.Click += new System.EventHandler(this.categoriaToolStripMenuItem_Click);
            // 
            // cursosToolStripMenuItem
            // 
            this.cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            this.cursosToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.cursosToolStripMenuItem.Text = "Cursos";
            this.cursosToolStripMenuItem.Click += new System.EventHandler(this.cursosToolStripMenuItem_Click);
            // 
            // objetivosToolStripMenuItem
            // 
            this.objetivosToolStripMenuItem.Name = "objetivosToolStripMenuItem";
            this.objetivosToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.objetivosToolStripMenuItem.Text = "Objetivos";
            this.objetivosToolStripMenuItem.Click += new System.EventHandler(this.objetivosToolStripMenuItem_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarObjetivosDelCursoToolStripMenuItem,
            this.actualizarAvanceUsuariosPorCursosToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // actualizarObjetivosDelCursoToolStripMenuItem
            // 
            this.actualizarObjetivosDelCursoToolStripMenuItem.Name = "actualizarObjetivosDelCursoToolStripMenuItem";
            this.actualizarObjetivosDelCursoToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.actualizarObjetivosDelCursoToolStripMenuItem.Text = "Actualizar objetivos del curso";
            this.actualizarObjetivosDelCursoToolStripMenuItem.Click += new System.EventHandler(this.actualizarObjetivosDelCursoToolStripMenuItem_Click);
            // 
            // actualizarAvanceUsuariosPorCursosToolStripMenuItem
            // 
            this.actualizarAvanceUsuariosPorCursosToolStripMenuItem.Name = "actualizarAvanceUsuariosPorCursosToolStripMenuItem";
            this.actualizarAvanceUsuariosPorCursosToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.actualizarAvanceUsuariosPorCursosToolStripMenuItem.Text = "Actualizar avance usuarios por cursos";
            this.actualizarAvanceUsuariosPorCursosToolStripMenuItem.Click += new System.EventHandler(this.actualizarAvanceUsuariosPorCursosToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoUsuariosPorCursoToolStripMenuItem,
            this.cantidadObjetivosPorCursoToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // listadoUsuariosPorCursoToolStripMenuItem
            // 
            this.listadoUsuariosPorCursoToolStripMenuItem.Name = "listadoUsuariosPorCursoToolStripMenuItem";
            this.listadoUsuariosPorCursoToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.listadoUsuariosPorCursoToolStripMenuItem.Text = "Listado usuarios por curso";
            this.listadoUsuariosPorCursoToolStripMenuItem.Click += new System.EventHandler(this.listadoUsuariosPorCursoToolStripMenuItem_Click);
            // 
            // cantidadObjetivosPorCursoToolStripMenuItem
            // 
            this.cantidadObjetivosPorCursoToolStripMenuItem.Name = "cantidadObjetivosPorCursoToolStripMenuItem";
            this.cantidadObjetivosPorCursoToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.cantidadObjetivosPorCursoToolStripMenuItem.Text = "Cantidad objetivos por curso";
            this.cantidadObjetivosPorCursoToolStripMenuItem.Click += new System.EventHandler(this.cantidadObjetivosPorCursoToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 303);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objetivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarObjetivosDelCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarAvanceUsuariosPorCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoUsuariosPorCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cantidadObjetivosPorCursoToolStripMenuItem;
    }
}