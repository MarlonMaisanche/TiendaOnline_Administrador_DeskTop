
namespace AppAdminDesktop_Presentación
{
    partial class Princiapal
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
            this.lista_productos = new System.Windows.Forms.Button();
            this.crear_producto = new System.Windows.Forms.Button();
            this.pedidos = new System.Windows.Forms.Button();
            this.usuarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lista_productos
            // 
            this.lista_productos.Location = new System.Drawing.Point(36, 68);
            this.lista_productos.Name = "lista_productos";
            this.lista_productos.Size = new System.Drawing.Size(291, 129);
            this.lista_productos.TabIndex = 0;
            this.lista_productos.Text = "LISTA PRODUCTOS";
            this.lista_productos.UseVisualStyleBackColor = true;
            this.lista_productos.Click += new System.EventHandler(this.lista_productos_Click);
            // 
            // crear_producto
            // 
            this.crear_producto.Location = new System.Drawing.Point(386, 68);
            this.crear_producto.Name = "crear_producto";
            this.crear_producto.Size = new System.Drawing.Size(328, 129);
            this.crear_producto.TabIndex = 1;
            this.crear_producto.Text = "CREAR PRODUCTOS";
            this.crear_producto.UseVisualStyleBackColor = true;
            this.crear_producto.Click += new System.EventHandler(this.button2_Click);
            // 
            // pedidos
            // 
            this.pedidos.Location = new System.Drawing.Point(36, 246);
            this.pedidos.Name = "pedidos";
            this.pedidos.Size = new System.Drawing.Size(291, 159);
            this.pedidos.TabIndex = 2;
            this.pedidos.Text = "PEDIDOS";
            this.pedidos.UseVisualStyleBackColor = true;
            // 
            // usuarios
            // 
            this.usuarios.Location = new System.Drawing.Point(386, 255);
            this.usuarios.Name = "usuarios";
            this.usuarios.Size = new System.Drawing.Size(328, 150);
            this.usuarios.TabIndex = 3;
            this.usuarios.Text = "USUARIOS";
            this.usuarios.UseVisualStyleBackColor = true;
            this.usuarios.Click += new System.EventHandler(this.usuarios_Click);
            // 
            // Princiapal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usuarios);
            this.Controls.Add(this.pedidos);
            this.Controls.Add(this.crear_producto);
            this.Controls.Add(this.lista_productos);
            this.Name = "Princiapal";
            this.Text = "Princiapal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lista_productos;
        private System.Windows.Forms.Button crear_producto;
        private System.Windows.Forms.Button pedidos;
        private System.Windows.Forms.Button usuarios;
    }
}