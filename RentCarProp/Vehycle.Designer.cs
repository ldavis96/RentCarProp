namespace RentCarProp
{
    partial class Vehycle
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
            this.btn_search = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_ok_update = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_eliminate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.cbx_TipoVehiculo = new System.Windows.Forms.ComboBox();
            this.txtNoPlaca = new System.Windows.Forms.TextBox();
            this.txtNoMotor = new System.Windows.Forms.TextBox();
            this.txtNoChasis = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_Marca = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_Modelo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbx_TipoCombustible = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(545, 90);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(56, 23);
            this.btn_search.TabIndex = 75;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(365, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 74;
            this.label10.Text = "Búsqueda:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(368, 93);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 20);
            this.textBox1.TabIndex = 73;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_ok_update
            // 
            this.btn_ok_update.Location = new System.Drawing.Point(236, 330);
            this.btn_ok_update.Name = "btn_ok_update";
            this.btn_ok_update.Size = new System.Drawing.Size(74, 23);
            this.btn_ok_update.TabIndex = 72;
            this.btn_ok_update.Text = "OK";
            this.btn_ok_update.UseVisualStyleBackColor = true;
            this.btn_ok_update.Visible = false;
            this.btn_ok_update.Click += new System.EventHandler(this.btn_ok_update_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(634, 331);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(42, 23);
            this.btn_update.TabIndex = 71;
            this.btn_update.Text = "( )";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_eliminate
            // 
            this.btn_eliminate.Location = new System.Drawing.Point(682, 331);
            this.btn_eliminate.Name = "btn_eliminate";
            this.btn_eliminate.Size = new System.Drawing.Size(42, 23);
            this.btn_eliminate.TabIndex = 70;
            this.btn_eliminate.Text = "X";
            this.btn_eliminate.UseVisualStyleBackColor = true;
            this.btn_eliminate.Click += new System.EventHandler(this.btn_eliminate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(353, 119);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(380, 206);
            this.dataGridView1.TabIndex = 69;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(365, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 68;
            this.label9.Text = "Estado";
            // 
            // comboEstado
            // 
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.FormattingEnabled = true;
            this.comboEstado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.comboEstado.Location = new System.Drawing.Point(418, 40);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(121, 21);
            this.comboEstado.TabIndex = 67;
            // 
            // cbx_TipoVehiculo
            // 
            this.cbx_TipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_TipoVehiculo.FormattingEnabled = true;
            this.cbx_TipoVehiculo.Location = new System.Drawing.Point(123, 177);
            this.cbx_TipoVehiculo.Name = "cbx_TipoVehiculo";
            this.cbx_TipoVehiculo.Size = new System.Drawing.Size(173, 21);
            this.cbx_TipoVehiculo.TabIndex = 66;
            // 
            // txtNoPlaca
            // 
            this.txtNoPlaca.Location = new System.Drawing.Point(110, 141);
            this.txtNoPlaca.MaxLength = 50;
            this.txtNoPlaca.Name = "txtNoPlaca";
            this.txtNoPlaca.Size = new System.Drawing.Size(186, 20);
            this.txtNoPlaca.TabIndex = 63;
            // 
            // txtNoMotor
            // 
            this.txtNoMotor.Location = new System.Drawing.Point(110, 105);
            this.txtNoMotor.MaxLength = 10;
            this.txtNoMotor.Name = "txtNoMotor";
            this.txtNoMotor.Size = new System.Drawing.Size(186, 20);
            this.txtNoMotor.TabIndex = 62;
            this.txtNoMotor.TextChanged += new System.EventHandler(this.txtNoMotor_TextChanged);
            // 
            // txtNoChasis
            // 
            this.txtNoChasis.Location = new System.Drawing.Point(110, 74);
            this.txtNoChasis.MaxLength = 50;
            this.txtNoChasis.Name = "txtNoChasis";
            this.txtNoChasis.Size = new System.Drawing.Size(186, 20);
            this.txtNoChasis.TabIndex = 61;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(110, 40);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(186, 20);
            this.txtDescription.TabIndex = 60;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(155, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 58;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(236, 331);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 57;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Tipo Vehículo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "No. Placa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "No. Motor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "No. Chasis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Descripción";
            // 
            // cbx_Marca
            // 
            this.cbx_Marca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Marca.FormattingEnabled = true;
            this.cbx_Marca.Location = new System.Drawing.Point(123, 213);
            this.cbx_Marca.Name = "cbx_Marca";
            this.cbx_Marca.Size = new System.Drawing.Size(173, 21);
            this.cbx_Marca.TabIndex = 77;
            this.cbx_Marca.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 76;
            this.label5.Text = "Marca";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cbx_Modelo
            // 
            this.cbx_Modelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Modelo.FormattingEnabled = true;
            this.cbx_Modelo.Location = new System.Drawing.Point(123, 249);
            this.cbx_Modelo.Name = "cbx_Modelo";
            this.cbx_Modelo.Size = new System.Drawing.Size(173, 21);
            this.cbx_Modelo.TabIndex = 79;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 78;
            this.label7.Text = "Modelo";
            // 
            // cbx_TipoCombustible
            // 
            this.cbx_TipoCombustible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_TipoCombustible.FormattingEnabled = true;
            this.cbx_TipoCombustible.Location = new System.Drawing.Point(137, 287);
            this.cbx_TipoCombustible.Name = "cbx_TipoCombustible";
            this.cbx_TipoCombustible.Size = new System.Drawing.Size(159, 21);
            this.cbx_TipoCombustible.TabIndex = 81;
            this.cbx_TipoCombustible.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "Tipo Combustible";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Vehycle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 399);
            this.Controls.Add(this.cbx_TipoCombustible);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbx_Modelo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbx_Marca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_ok_update);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_eliminate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboEstado);
            this.Controls.Add(this.cbx_TipoVehiculo);
            this.Controls.Add(this.txtNoPlaca);
            this.Controls.Add(this.txtNoMotor);
            this.Controls.Add(this.txtNoChasis);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Vehycle";
            this.Text = "Vehículos";
            this.Load += new System.EventHandler(this.Vehycle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_ok_update;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_eliminate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboEstado;
        private System.Windows.Forms.ComboBox cbx_TipoVehiculo;
        private System.Windows.Forms.TextBox txtNoPlaca;
        private System.Windows.Forms.TextBox txtNoMotor;
        private System.Windows.Forms.TextBox txtNoChasis;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_Marca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_Modelo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbx_TipoCombustible;
        private System.Windows.Forms.Label label8;
    }
}