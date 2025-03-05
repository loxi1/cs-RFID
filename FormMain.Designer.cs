
using System.Drawing;
using System.Windows.Forms;

namespace RFIDPrendas
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antenatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Configurar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ConteoSimple_ = new System.Windows.Forms.ToolStripMenuItem();
            this.CajaSimpletoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.caja_simple_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.conteoXPO = new System.Windows.Forms.ToolStripMenuItem();
            this.LeerCaja = new System.Windows.Forms.ToolStripMenuItem();
            this.LecturaCajaXOP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1Reporte = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuReporteIncidencias = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.desmatricularCaja = new System.Windows.Forms.ToolStripMenuItem();
            this.desmatricularCajaAuditoria = new System.Windows.Forms.ToolStripMenuItem();
            this.reprocesarCajaOPHM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.Conteo_de_Cajas = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaCantidadtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cajasVerificartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.validarSalidaStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cajasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConteoxCajaReporte = new System.Windows.Forms.ToolStripMenuItem();
            this.ReporteOPHM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPrueba = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfiltoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logouttoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpiLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.functionCallStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.gpiStateGB = new System.Windows.Forms.GroupBox();
            this.gpiNumberLabel = new System.Windows.Forms.Label();
            this.transmitPowerGB = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.dataContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tagDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readDataContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeDataContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockDataContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killDataContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockWriteDataContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockEraseDataContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.accessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.CodigoUsuario_ = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.gpiStateGB.SuspendLayout();
            this.transmitPowerGB.SuspendLayout();
            this.dataContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.AutoSize = false;
            this.mainMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.mainMenuStrip.GripMargin = new System.Windows.Forms.Padding(1, 4, 0, 4);
            this.mainMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.operationsToolStripMenuItem,
            this.userToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(0);
            this.mainMenuStrip.ShowItemToolTips = true;
            this.mainMenuStrip.Size = new System.Drawing.Size(784, 50);
            this.mainMenuStrip.TabIndex = 0;
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.antenatoolStripMenuItem,
            this.Configurar,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(131, 50);
            this.configToolStripMenuItem.Text = "Configuración";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("connectionToolStripMenuItem.Image")));
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.connectionToolStripMenuItem.Text = "Conexión...";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // antenatoolStripMenuItem
            // 
            this.antenatoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("antenatoolStripMenuItem.Image")));
            this.antenatoolStripMenuItem.Name = "antenatoolStripMenuItem";
            this.antenatoolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.antenatoolStripMenuItem.Text = "Antena...";
            this.antenatoolStripMenuItem.Click += new System.EventHandler(this.antenatoolStripMenuItem_Click);
            // 
            // Configurar
            // 
            this.Configurar.Image = ((System.Drawing.Image)(resources.GetObject("Configurar.Image")));
            this.Configurar.Name = "Configurar";
            this.Configurar.Size = new System.Drawing.Size(181, 38);
            this.Configurar.Text = "Ajustes...";
            this.Configurar.Click += new System.EventHandler(this.Configurar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.exitToolStripMenuItem.Text = "Salir";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.ConteoSimple_,
            this.toolStripSeparator1,
            this.caja_simple_menu,
            this.toolStripSeparator4,
            this.desmatricularCaja,
            this.toolStripSeparator5,
            this.Conteo_de_Cajas,
            this.toolStripMenuItemPrueba,
            this.toolStripMenuItemLogin,
            this.toolStripMenuItem1});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(117, 50);
            this.operationsToolStripMenuItem.Text = "Operaciones";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(260, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // ConteoSimple_
            // 
            this.ConteoSimple_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CajaSimpletoolStripMenuItem});
            this.ConteoSimple_.Image = ((System.Drawing.Image)(resources.GetObject("ConteoSimple_.Image")));
            this.ConteoSimple_.Name = "ConteoSimple_";
            this.ConteoSimple_.Size = new System.Drawing.Size(263, 38);
            this.ConteoSimple_.Text = "Conteo Simple";
            this.ConteoSimple_.Visible = false;
            // 
            // CajaSimpletoolStripMenuItem
            // 
            this.CajaSimpletoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CajaSimpletoolStripMenuItem.Image")));
            this.CajaSimpletoolStripMenuItem.Name = "CajaSimpletoolStripMenuItem";
            this.CajaSimpletoolStripMenuItem.Size = new System.Drawing.Size(186, 38);
            this.CajaSimpletoolStripMenuItem.Text = "Caja Simple";
            this.CajaSimpletoolStripMenuItem.Click += new System.EventHandler(this.CajaSimpletoolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(260, 6);
            // 
            // caja_simple_menu
            // 
            this.caja_simple_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conteoXPO,
            this.LeerCaja,
            this.LecturaCajaXOP,
            this.toolStripMenuItem1Reporte,
            this.toolStripMenuReporteIncidencias});
            this.caja_simple_menu.Image = ((System.Drawing.Image)(resources.GetObject("caja_simple_menu.Image")));
            this.caja_simple_menu.Name = "caja_simple_menu";
            this.caja_simple_menu.RightToLeftAutoMirrorImage = true;
            this.caja_simple_menu.Size = new System.Drawing.Size(263, 38);
            this.caja_simple_menu.Text = "Conteo x Colaborador";
            // 
            // conteoXPO
            // 
            this.conteoXPO.Image = ((System.Drawing.Image)(resources.GetObject("conteoXPO.Image")));
            this.conteoXPO.Name = "conteoXPO";
            this.conteoXPO.Size = new System.Drawing.Size(261, 38);
            this.conteoXPO.Text = "Conteo x PO";
            this.conteoXPO.Visible = false;
            this.conteoXPO.Click += new System.EventHandler(this.ConteoXPO_Click);
            // 
            // LeerCaja
            // 
            this.LeerCaja.Image = ((System.Drawing.Image)(resources.GetObject("LeerCaja.Image")));
            this.LeerCaja.Name = "LeerCaja";
            this.LeerCaja.Size = new System.Drawing.Size(261, 38);
            this.LeerCaja.Text = "Conteo x colaborador";
            this.LeerCaja.Visible = false;
            this.LeerCaja.Click += new System.EventHandler(this.LeerCaja_Click);
            // 
            // LecturaCajaXOP
            // 
            this.LecturaCajaXOP.Image = ((System.Drawing.Image)(resources.GetObject("LecturaCajaXOP.Image")));
            this.LecturaCajaXOP.Name = "LecturaCajaXOP";
            this.LecturaCajaXOP.Size = new System.Drawing.Size(261, 38);
            this.LecturaCajaXOP.Text = "Conteo x OP";
            this.LecturaCajaXOP.Click += new System.EventHandler(this.LecturaCajaXOP_Click);
            // 
            // toolStripMenuItem1Reporte
            // 
            this.toolStripMenuItem1Reporte.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1Reporte.Image")));
            this.toolStripMenuItem1Reporte.Name = "toolStripMenuItem1Reporte";
            this.toolStripMenuItem1Reporte.Size = new System.Drawing.Size(261, 38);
            this.toolStripMenuItem1Reporte.Text = "Reporte Conteo";
            this.toolStripMenuItem1Reporte.Click += new System.EventHandler(this.toolStripMenuItem1Reporte_Click);
            // 
            // toolStripMenuReporteIncidencias
            // 
            this.toolStripMenuReporteIncidencias.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuReporteIncidencias.Image")));
            this.toolStripMenuReporteIncidencias.Name = "toolStripMenuReporteIncidencias";
            this.toolStripMenuReporteIncidencias.Size = new System.Drawing.Size(261, 38);
            this.toolStripMenuReporteIncidencias.Text = "Reporte Incidencias";
            this.toolStripMenuReporteIncidencias.Click += new System.EventHandler(this.toolStripMenuReporteIncidencias_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(260, 6);
            this.toolStripSeparator4.Visible = false;
            // 
            // desmatricularCaja
            // 
            this.desmatricularCaja.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desmatricularCajaAuditoria,
            this.reprocesarCajaOPHM});
            this.desmatricularCaja.Image = global::RFIDPrendas.Properties.Resources.return_caja;
            this.desmatricularCaja.Name = "desmatricularCaja";
            this.desmatricularCaja.Size = new System.Drawing.Size(263, 38);
            this.desmatricularCaja.Text = "Gestión vinculos";
            // 
            // desmatricularCajaAuditoria
            // 
            this.desmatricularCajaAuditoria.Image = ((System.Drawing.Image)(resources.GetObject("desmatricularCajaAuditoria.Image")));
            this.desmatricularCajaAuditoria.Name = "desmatricularCajaAuditoria";
            this.desmatricularCajaAuditoria.Size = new System.Drawing.Size(217, 38);
            this.desmatricularCajaAuditoria.Text = "Auditar Caja";
            this.desmatricularCajaAuditoria.Click += new System.EventHandler(this.DesmatricularCajaAuditoria_Click);
            // 
            // reprocesarCajaOPHM
            // 
            this.reprocesarCajaOPHM.Image = ((System.Drawing.Image)(resources.GetObject("reprocesarCajaOPHM.Image")));
            this.reprocesarCajaOPHM.Name = "reprocesarCajaOPHM";
            this.reprocesarCajaOPHM.Size = new System.Drawing.Size(217, 38);
            this.reprocesarCajaOPHM.Text = "Reprocesar Lote";
            this.reprocesarCajaOPHM.Click += new System.EventHandler(this.ReprocesarCajaOPHM_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(260, 6);
            this.toolStripSeparator5.Visible = false;
            // 
            // Conteo_de_Cajas
            // 
            this.Conteo_de_Cajas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cajaCantidadtoolStripMenuItem,
            this.toolStripSeparator6,
            this.cajasVerificartoolStripMenuItem,
            this.toolStripSeparator7,
            this.validarSalidaStripMenuItem1,
            this.toolStripSeparator8,
            this.cajasToolStripMenuItem,
            this.prendasToolStripMenuItem,
            this.ConteoxCajaReporte,
            this.ReporteOPHM});
            this.Conteo_de_Cajas.Image = ((System.Drawing.Image)(resources.GetObject("Conteo_de_Cajas.Image")));
            this.Conteo_de_Cajas.Name = "Conteo_de_Cajas";
            this.Conteo_de_Cajas.Size = new System.Drawing.Size(263, 38);
            this.Conteo_de_Cajas.Text = "Validar Caja";
            // 
            // cajaCantidadtoolStripMenuItem
            // 
            this.cajaCantidadtoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cajaCantidadtoolStripMenuItem.Image")));
            this.cajaCantidadtoolStripMenuItem.Name = "cajaCantidadtoolStripMenuItem";
            this.cajaCantidadtoolStripMenuItem.Size = new System.Drawing.Size(247, 38);
            this.cajaCantidadtoolStripMenuItem.Text = "Prendas en Caja";
            this.cajaCantidadtoolStripMenuItem.ToolTipText = "Registrar Cantidad de Prendas x Caja";
            this.cajaCantidadtoolStripMenuItem.Visible = false;
            this.cajaCantidadtoolStripMenuItem.Click += new System.EventHandler(this.cajaCantidadtoolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(244, 6);
            // 
            // cajasVerificartoolStripMenuItem
            // 
            this.cajasVerificartoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cajasVerificartoolStripMenuItem.Image")));
            this.cajasVerificartoolStripMenuItem.Name = "cajasVerificartoolStripMenuItem";
            this.cajasVerificartoolStripMenuItem.Size = new System.Drawing.Size(247, 38);
            this.cajasVerificartoolStripMenuItem.Text = "Verificar Cajas";
            this.cajasVerificartoolStripMenuItem.Click += new System.EventHandler(this.cajasVerificartoolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(244, 6);
            // 
            // validarSalidaStripMenuItem1
            // 
            this.validarSalidaStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("validarSalidaStripMenuItem1.Image")));
            this.validarSalidaStripMenuItem1.Name = "validarSalidaStripMenuItem1";
            this.validarSalidaStripMenuItem1.Size = new System.Drawing.Size(247, 38);
            this.validarSalidaStripMenuItem1.Text = "Validar salida";
            this.validarSalidaStripMenuItem1.Click += new System.EventHandler(this.ValidarSalidaStripMenuItem1_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(244, 6);
            // 
            // cajasToolStripMenuItem
            // 
            this.cajasToolStripMenuItem.Name = "cajasToolStripMenuItem";
            this.cajasToolStripMenuItem.Size = new System.Drawing.Size(247, 38);
            this.cajasToolStripMenuItem.Text = "Registro de Cajas";
            this.cajasToolStripMenuItem.ToolTipText = "Registro de Cajas y Prendas";
            this.cajasToolStripMenuItem.Visible = false;
            this.cajasToolStripMenuItem.Click += new System.EventHandler(this.cajasToolStripMenuItem_Click);
            // 
            // prendasToolStripMenuItem
            // 
            this.prendasToolStripMenuItem.Name = "prendasToolStripMenuItem";
            this.prendasToolStripMenuItem.Size = new System.Drawing.Size(247, 38);
            this.prendasToolStripMenuItem.Text = "Registro de Prendas";
            this.prendasToolStripMenuItem.Visible = false;
            this.prendasToolStripMenuItem.Click += new System.EventHandler(this.prendasToolStripMenuItem_Click);
            // 
            // ConteoxCajaReporte
            // 
            this.ConteoxCajaReporte.Image = ((System.Drawing.Image)(resources.GetObject("ConteoxCajaReporte.Image")));
            this.ConteoxCajaReporte.Name = "ConteoxCajaReporte";
            this.ConteoxCajaReporte.Size = new System.Drawing.Size(247, 38);
            this.ConteoxCajaReporte.Text = "Reporte";
            this.ConteoxCajaReporte.Click += new System.EventHandler(this.ConteoxCajaReporte_Click);
            // 
            // ReporteOPHM
            // 
            this.ReporteOPHM.Image = ((System.Drawing.Image)(resources.GetObject("ReporteOPHM.Image")));
            this.ReporteOPHM.Name = "ReporteOPHM";
            this.ReporteOPHM.Size = new System.Drawing.Size(247, 38);
            this.ReporteOPHM.Text = "Reporte OP HM";
            this.ReporteOPHM.Click += new System.EventHandler(this.ReporteOPHM_Click);
            // 
            // toolStripMenuItemPrueba
            // 
            this.toolStripMenuItemPrueba.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemPrueba.Image")));
            this.toolStripMenuItemPrueba.Name = "toolStripMenuItemPrueba";
            this.toolStripMenuItemPrueba.Size = new System.Drawing.Size(263, 38);
            this.toolStripMenuItemPrueba.Text = "Prueba";
            this.toolStripMenuItemPrueba.Visible = false;
            this.toolStripMenuItemPrueba.Click += new System.EventHandler(this.toolStripMenuItemPrueba_Click);
            // 
            // toolStripMenuItemLogin
            // 
            this.toolStripMenuItemLogin.Name = "toolStripMenuItemLogin";
            this.toolStripMenuItemLogin.Size = new System.Drawing.Size(263, 38);
            this.toolStripMenuItemLogin.Text = "Login";
            this.toolStripMenuItemLogin.Visible = false;
            this.toolStripMenuItemLogin.Click += new System.EventHandler(this.toolStripMenuItemLogin_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(263, 38);
            this.toolStripMenuItem1.Text = "Conteo x HM";
            this.toolStripMenuItem1.Visible = false;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfiltoolStripMenuItem,
            this.logouttoolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(81, 50);
            this.userToolStripMenuItem.Text = "Usuario";
            // 
            // perfiltoolStripMenuItem
            // 
            this.perfiltoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("perfiltoolStripMenuItem.Image")));
            this.perfiltoolStripMenuItem.Name = "perfiltoolStripMenuItem";
            this.perfiltoolStripMenuItem.Size = new System.Drawing.Size(203, 38);
            this.perfiltoolStripMenuItem.Text = "Perfil";
            this.perfiltoolStripMenuItem.Click += new System.EventHandler(this.PerfiltoolStripMenuItem_Click);
            // 
            // logouttoolStripMenuItem
            // 
            this.logouttoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logouttoolStripMenuItem.Image")));
            this.logouttoolStripMenuItem.Name = "logouttoolStripMenuItem";
            this.logouttoolStripMenuItem.Size = new System.Drawing.Size(203, 38);
            this.logouttoolStripMenuItem.Text = "Cerrar Sessión";
            this.logouttoolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.logouttoolStripMenuItem.Click += new System.EventHandler(this.LogouttoolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(71, 50);
            this.helpToolStripMenuItem.Text = "Ayuda";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.RightToLeftAutoMirrorImage = true;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(165, 38);
            this.aboutToolStripMenuItem.Text = "Nosotros";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // gpiLabel
            // 
            this.gpiLabel.AutoSize = true;
            this.gpiLabel.Location = new System.Drawing.Point(6, 27);
            this.gpiLabel.Name = "gpiLabel";
            this.gpiLabel.Size = new System.Drawing.Size(68, 13);
            this.gpiLabel.TabIndex = 5;
            this.gpiLabel.Text = "Red For Low";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.GreenYellow;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(80, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(114, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.GreenYellow;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(150, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(185, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "  ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(321, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "  ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.GreenYellow;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(288, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "  ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Red;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(254, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "  ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.GreenYellow;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(220, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "  ";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionCallStatusLabel,
            this.connectionStatusLabel,
            this.connectionStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 493);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(784, 25);
            this.statusStrip.TabIndex = 19;
            this.statusStrip.Text = "statusStrip";
            // 
            // functionCallStatusLabel
            // 
            this.functionCallStatusLabel.AutoSize = false;
            this.functionCallStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.functionCallStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.functionCallStatusLabel.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.functionCallStatusLabel.Name = "functionCallStatusLabel";
            this.functionCallStatusLabel.Size = new System.Drawing.Size(716, 20);
            this.functionCallStatusLabel.Text = "Ready";
            this.functionCallStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(0, 20);
            // 
            // connectionStatus
            // 
            this.connectionStatus.AutoSize = false;
            this.connectionStatus.BackgroundImage = global::RFIDPrendas.Properties.Resources.disconnected;
            this.connectionStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.connectionStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.connectionStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(50, 20);
            this.connectionStatus.Text = "Disconnected";
            // 
            // gpiStateGB
            // 
            this.gpiStateGB.Controls.Add(this.gpiNumberLabel);
            this.gpiStateGB.Controls.Add(this.label6);
            this.gpiStateGB.Controls.Add(this.label7);
            this.gpiStateGB.Controls.Add(this.label8);
            this.gpiStateGB.Controls.Add(this.label9);
            this.gpiStateGB.Controls.Add(this.label5);
            this.gpiStateGB.Controls.Add(this.label4);
            this.gpiStateGB.Controls.Add(this.label3);
            this.gpiStateGB.Controls.Add(this.label2);
            this.gpiStateGB.Controls.Add(this.gpiLabel);
            this.gpiStateGB.Location = new System.Drawing.Point(12, 331);
            this.gpiStateGB.Name = "gpiStateGB";
            this.gpiStateGB.Size = new System.Drawing.Size(347, 54);
            this.gpiStateGB.TabIndex = 20;
            this.gpiStateGB.TabStop = false;
            this.gpiStateGB.Text = "GPI State";
            // 
            // gpiNumberLabel
            // 
            this.gpiNumberLabel.AutoSize = true;
            this.gpiNumberLabel.Location = new System.Drawing.Point(77, 38);
            this.gpiNumberLabel.Name = "gpiNumberLabel";
            this.gpiNumberLabel.Size = new System.Drawing.Size(259, 13);
            this.gpiNumberLabel.TabIndex = 18;
            this.gpiNumberLabel.Text = " 1          2          3         4          5          6         7         8";
            // 
            // transmitPowerGB
            // 
            this.transmitPowerGB.Controls.Add(this.label12);
            this.transmitPowerGB.Controls.Add(this.label10);
            this.transmitPowerGB.Controls.Add(this.label11);
            this.transmitPowerGB.Controls.Add(this.hScrollBar1);
            this.transmitPowerGB.Location = new System.Drawing.Point(11, 331);
            this.transmitPowerGB.Name = "transmitPowerGB";
            this.transmitPowerGB.Size = new System.Drawing.Size(347, 53);
            this.transmitPowerGB.TabIndex = 23;
            this.transmitPowerGB.TabStop = false;
            this.transmitPowerGB.Text = "Transmit Power (dbm)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(296, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "2920";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "1620";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(114, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "1620";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(13, 16);
            this.hScrollBar1.Maximum = 2920;
            this.hScrollBar1.Minimum = 1620;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(314, 19);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Value = 1620;
            // 
            // dataContextMenuStrip
            // 
            this.dataContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagDataToolStripMenuItem,
            this.readDataContextMenuItem,
            this.writeDataContextMenuItem,
            this.lockDataContextMenuItem,
            this.killDataContextMenuItem,
            this.blockWriteDataContextMenuItem,
            this.blockEraseDataContextMenuItem});
            this.dataContextMenuStrip.Name = "dataContextMenuStrip";
            this.dataContextMenuStrip.Size = new System.Drawing.Size(135, 158);
            // 
            // tagDataToolStripMenuItem
            // 
            this.tagDataToolStripMenuItem.Name = "tagDataToolStripMenuItem";
            this.tagDataToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.tagDataToolStripMenuItem.Text = "Tag Data";
            this.tagDataToolStripMenuItem.Click += new System.EventHandler(this.tagDataToolStripMenuItem_Click);
            // 
            // readDataContextMenuItem
            // 
            this.readDataContextMenuItem.Name = "readDataContextMenuItem";
            this.readDataContextMenuItem.Size = new System.Drawing.Size(134, 22);
            this.readDataContextMenuItem.Text = "Read";
            this.readDataContextMenuItem.Click += new System.EventHandler(this.readDataContextMenuItem_Click);
            // 
            // writeDataContextMenuItem
            // 
            this.writeDataContextMenuItem.Name = "writeDataContextMenuItem";
            this.writeDataContextMenuItem.Size = new System.Drawing.Size(134, 22);
            this.writeDataContextMenuItem.Text = "Write";
            this.writeDataContextMenuItem.Click += new System.EventHandler(this.writeDataContextMenuItem_Click);
            // 
            // lockDataContextMenuItem
            // 
            this.lockDataContextMenuItem.Name = "lockDataContextMenuItem";
            this.lockDataContextMenuItem.Size = new System.Drawing.Size(134, 22);
            this.lockDataContextMenuItem.Text = "Lock";
            this.lockDataContextMenuItem.Click += new System.EventHandler(this.lockDataContextMenuItem_Click);
            // 
            // killDataContextMenuItem
            // 
            this.killDataContextMenuItem.Name = "killDataContextMenuItem";
            this.killDataContextMenuItem.Size = new System.Drawing.Size(134, 22);
            this.killDataContextMenuItem.Text = "Kill";
            this.killDataContextMenuItem.Click += new System.EventHandler(this.killDataContextMenuItem_Click);
            // 
            // blockWriteDataContextMenuItem
            // 
            this.blockWriteDataContextMenuItem.Name = "blockWriteDataContextMenuItem";
            this.blockWriteDataContextMenuItem.Size = new System.Drawing.Size(134, 22);
            this.blockWriteDataContextMenuItem.Text = "Block Write";
            this.blockWriteDataContextMenuItem.Click += new System.EventHandler(this.blockWriteDataContextMenuItem_Click);
            // 
            // blockEraseDataContextMenuItem
            // 
            this.blockEraseDataContextMenuItem.Name = "blockEraseDataContextMenuItem";
            this.blockEraseDataContextMenuItem.Size = new System.Drawing.Size(134, 22);
            this.blockEraseDataContextMenuItem.Text = "Block Erase";
            this.blockEraseDataContextMenuItem.Click += new System.EventHandler(this.blockEraseDataContextMenuItem_Click);
            // 
            // connectBackgroundWorker
            // 
            this.connectBackgroundWorker.WorkerReportsProgress = true;
            this.connectBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.connectBackgroundWorker_DoWork);
            this.connectBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.connectBackgroundWorker_ProgressChanged);
            this.connectBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.connectBackgroundWorker_RunWorkerCompleted);
            // 
            // accessBackgroundWorker
            // 
            this.accessBackgroundWorker.WorkerReportsProgress = true;
            this.accessBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.accessBackgroundWorker_DoWork);
            this.accessBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.accessBackgroundWorker_ProgressChanged);
            this.accessBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.accessBackgroundWorker_RunWorkerCompleted);
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(686, 4);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(28, 13);
            this.labelUsuario.TabIndex = 21;
            this.labelUsuario.Text = "___";
            // 
            // CodigoUsuario_
            // 
            this.CodigoUsuario_.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CodigoUsuario_.AutoSize = true;
            this.CodigoUsuario_.Location = new System.Drawing.Point(721, 4);
            this.CodigoUsuario_.Name = "CodigoUsuario_";
            this.CodigoUsuario_.Size = new System.Drawing.Size(31, 13);
            this.CodigoUsuario_.TabIndex = 23;
            this.CodigoUsuario_.Text = "____";
            this.CodigoUsuario_.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 518);
            this.Controls.Add(this.CodigoUsuario_);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(16, 250);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RFID";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ClientSizeChanged += new System.EventHandler(this.FormMain_ClientSizeChanged);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gpiStateGB.ResumeLayout(false);
            this.gpiStateGB.PerformLayout();
            this.transmitPowerGB.ResumeLayout(false);
            this.transmitPowerGB.PerformLayout();
            this.dataContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label gpiLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox gpiStateGB;
        private System.Windows.Forms.Label gpiNumberLabel;
        private System.Windows.Forms.GroupBox transmitPowerGB;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatusLabel;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip dataContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tagDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readDataContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeDataContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockDataContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killDataContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockWriteDataContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockEraseDataContextMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatus;
        internal System.ComponentModel.BackgroundWorker connectBackgroundWorker;
        internal System.ComponentModel.BackgroundWorker accessBackgroundWorker;
        internal System.Windows.Forms.ToolStripStatusLabel functionCallStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem antenatoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cajaCantidadtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajasVerificartoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CajaSimpletoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem caja_simple_menu;
        private System.Windows.Forms.ToolStripMenuItem LeerCaja;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1Reporte;
        private System.Windows.Forms.ToolStripMenuItem Configurar;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.ToolStripMenuItem ConteoSimple_;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem Conteo_de_Cajas;
        private System.Windows.Forms.ToolStripMenuItem ConteoxCajaReporte;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPrueba;
        private System.Windows.Forms.Label CodigoUsuario_;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuReporteIncidencias;
        private ToolStripMenuItem toolStripMenuItemLogin;
        private ToolStripMenuItem ReporteOPHM;
        private ToolStripMenuItem conteoXPO;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem validarSalidaStripMenuItem1;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem LecturaCajaXOP;
        private ToolStripMenuItem desmatricularCaja;
        private ToolStripMenuItem desmatricularCajaAuditoria;
        private ToolStripMenuItem reprocesarCajaOPHM;
        private ToolStripMenuItem userToolStripMenuItem;
        private ToolStripMenuItem perfiltoolStripMenuItem;
        private ToolStripMenuItem logouttoolStripMenuItem;
    }
}

