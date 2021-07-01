
namespace Punto_de_venta.Mantenimientos
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgProductos = new System.Windows.Forms.DataGridView();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEstante = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnEstante = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnProveedor = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtBuscar);
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1655, 59);
            this.panel2.TabIndex = 33;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::Punto_de_venta.Properties.Resources.casa__1_;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(16, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(51, 46);
            this.btnCerrar.TabIndex = 34;
            this.btnCerrar.UseVisualStyleBackColor = false;
            
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(1085, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 29);
            this.label8.TabIndex = 30;
            this.label8.Text = "Buscar :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(99, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(320, 29);
            this.label9.TabIndex = 30;
            this.label9.Text = "Mantenimiento de Productos";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtBuscar.Location = new System.Drawing.Point(1202, 13);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(439, 34);
            this.txtBuscar.TabIndex = 9;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.BackColor = System.Drawing.Color.White;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.Gray;
            this.btnNuevo.Location = new System.Drawing.Point(358, 994);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(140, 35);
            this.btnNuevo.TabIndex = 24;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(235)))), ((int)(((byte)(214)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Gray;
            this.btnGuardar.Location = new System.Drawing.Point(29, 994);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 35);
            this.btnGuardar.TabIndex = 24;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            //this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgProductos
            // 
            this.dgProductos.AllowUserToAddRows = false;
            this.dgProductos.AllowUserToOrderColumns = true;
            this.dgProductos.AllowUserToResizeColumns = false;
            this.dgProductos.AllowUserToResizeRows = false;
            this.dgProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProductos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgProductos.Location = new System.Drawing.Point(526, 72);
            this.dgProductos.Name = "dgProductos";
            this.dgProductos.ReadOnly = true;
            this.dgProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgProductos.RowHeadersVisible = false;
            this.dgProductos.RowHeadersWidth = 31;
            this.dgProductos.RowTemplate.Height = 24;
            this.dgProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductos.Size = new System.Drawing.Size(1115, 956);
            this.dgProductos.TabIndex = 0;
            //this.dgProductos.SelectionChanged += new System.EventHandler(this.dgProductos_SelectionChanged);
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.Color.Gray;
            this.txtId.Location = new System.Drawing.Point(27, 401);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(471, 34);
            this.txtId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(26, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Código";
            // 
            // txtVenta
            // 
            this.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVenta.ForeColor = System.Drawing.Color.Gray;
            this.txtVenta.Location = new System.Drawing.Point(27, 555);
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Size = new System.Drawing.Size(224, 34);
            this.txtVenta.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(26, 528);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Precio venta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(26, 593);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Estante";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.Gray;
            this.txtNombre.Location = new System.Drawing.Point(27, 466);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(471, 59);
            this.txtNombre.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(26, 439);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nombre del producto";
            // 
            // txtCosto
            // 
            this.txtCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.ForeColor = System.Drawing.Color.Gray;
            this.txtCosto.Location = new System.Drawing.Point(274, 555);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(224, 34);
            this.txtCosto.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(273, 528);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "Precio costo";
            // 
            // txtEstante
            // 
            this.txtEstante.BackColor = System.Drawing.SystemColors.Window;
            this.txtEstante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstante.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstante.ForeColor = System.Drawing.Color.Gray;
            this.txtEstante.Location = new System.Drawing.Point(27, 620);
            this.txtEstante.Name = "txtEstante";
            this.txtEstante.Size = new System.Drawing.Size(178, 34);
            this.txtEstante.TabIndex = 13;
            this.txtEstante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(273, 593);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "Categoría";
            // 
            // txtCategoria
            // 
            this.txtCategoria.BackColor = System.Drawing.SystemColors.Window;
            this.txtCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoria.ForeColor = System.Drawing.Color.Gray;
            this.txtCategoria.Location = new System.Drawing.Point(274, 620);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(178, 34);
            this.txtCategoria.TabIndex = 13;
            this.txtCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCategoria
            // 
            this.btnCategoria.BackColor = System.Drawing.Color.White;
            this.btnCategoria.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCategoria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCategoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(220)))), ((int)(((byte)(244)))));
            this.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoria.Location = new System.Drawing.Point(458, 620);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(40, 34);
            this.btnCategoria.TabIndex = 28;
            this.btnCategoria.Text = "▪▪▪";
            this.btnCategoria.UseVisualStyleBackColor = false;
            // 
            // btnEstante
            // 
            this.btnEstante.BackColor = System.Drawing.Color.White;
            this.btnEstante.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnEstante.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEstante.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(220)))), ((int)(((byte)(244)))));
            this.btnEstante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstante.Location = new System.Drawing.Point(211, 620);
            this.btnEstante.Name = "btnEstante";
            this.btnEstante.Size = new System.Drawing.Size(40, 34);
            this.btnEstante.TabIndex = 28;
            this.btnEstante.Text = "▪▪▪";
            this.btnEstante.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Gray;
            this.btnEliminar.Location = new System.Drawing.Point(194, 994);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(140, 35);
            this.btnEliminar.TabIndex = 31;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            //this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnEstante);
            this.panel1.Controls.Add(this.btnCategoria);
            this.panel1.Controls.Add(this.btnProveedor);
            this.panel1.Controls.Add(this.logo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCategoria);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtEstante);
            this.panel1.Controls.Add(this.txtProveedor);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCosto);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtVenta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.dgProductos);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(-1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1655, 1042);
            this.panel1.TabIndex = 0;
            // 
            // btnProveedor
            // 
            this.btnProveedor.BackColor = System.Drawing.Color.White;
            this.btnProveedor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(220)))), ((int)(((byte)(244)))));
            this.btnProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedor.Location = new System.Drawing.Point(211, 685);
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(40, 34);
            this.btnProveedor.TabIndex = 28;
            this.btnProveedor.Text = "▪▪▪";
            this.btnProveedor.UseVisualStyleBackColor = false;
            // 
            // logo
            // 
            this.logo.BackgroundImage = global::Punto_de_venta.Properties.Resources.lista_de_verificacion;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo.InitialImage = global::Punto_de_venta.Properties.Resources.Producto1;
            this.logo.Location = new System.Drawing.Point(112, 72);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(297, 291);
            this.logo.TabIndex = 17;
            this.logo.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(26, 658);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Proveedor";
            // 
            // txtProveedor
            // 
            this.txtProveedor.BackColor = System.Drawing.SystemColors.Window;
            this.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.ForeColor = System.Drawing.Color.Gray;
            this.txtProveedor.Location = new System.Drawing.Point(27, 685);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(178, 34);
            this.txtProveedor.TabIndex = 13;
            this.txtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Mantenimiento_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1653, 1043);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mantenimiento_Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "|";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //this.Load += new System.EventHandler(this.Mantenimiento_Productos_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgProductos;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEstante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Button btnEstante;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}