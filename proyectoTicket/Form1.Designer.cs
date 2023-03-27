

namespace proyectoTicket
{
    partial class Form1
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
            this.CboBaudRate = new System.Windows.Forms.ComboBox();
            this.CboPortList = new System.Windows.Forms.ComboBox();
            this.LblBaudRate = new System.Windows.Forms.Label();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.BtnSearchPorts = new System.Windows.Forms.Button();
            this.SpPorts = new System.IO.Ports.SerialPort(this.components);
            this.LblError = new System.Windows.Forms.Label();
            this.LblResponse = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cBoxDevices = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // CboBaudRate
            // 
            this.CboBaudRate.FormattingEnabled = true;
            this.CboBaudRate.Items.AddRange(new object[] {
            "9600"});
            this.CboBaudRate.Location = new System.Drawing.Point(243, 91);
            this.CboBaudRate.Name = "CboBaudRate";
            this.CboBaudRate.Size = new System.Drawing.Size(126, 21);
            this.CboBaudRate.TabIndex = 6;
            this.CboBaudRate.Text = "9600";
            // 
            // CboPortList
            // 
            this.CboPortList.CausesValidation = false;
            this.CboPortList.FormattingEnabled = true;
            this.CboPortList.Location = new System.Drawing.Point(243, 35);
            this.CboPortList.Name = "CboPortList";
            this.CboPortList.Size = new System.Drawing.Size(126, 21);
            this.CboPortList.TabIndex = 5;
            this.CboPortList.Text = "Seleccione";
            // 
            // LblBaudRate
            // 
            this.LblBaudRate.AutoSize = true;
            this.LblBaudRate.Location = new System.Drawing.Point(89, 99);
            this.LblBaudRate.Name = "LblBaudRate";
            this.LblBaudRate.Size = new System.Drawing.Size(54, 13);
            this.LblBaudRate.TabIndex = 3;
            this.LblBaudRate.Text = "Velocidad";
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(153, 128);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(165, 21);
            this.BtnConnect.TabIndex = 1;
            this.BtnConnect.Text = "Conectar";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // BtnSearchPorts
            // 
            this.BtnSearchPorts.Location = new System.Drawing.Point(51, 35);
            this.BtnSearchPorts.Name = "BtnSearchPorts";
            this.BtnSearchPorts.Size = new System.Drawing.Size(165, 21);
            this.BtnSearchPorts.TabIndex = 0;
            this.BtnSearchPorts.Text = "Buscar Puertos";
            this.BtnSearchPorts.UseVisualStyleBackColor = true;
            this.BtnSearchPorts.Click += new System.EventHandler(this.BtnSearchPorts_Click);
            // 
            // SpPorts
            // 
            this.SpPorts.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.GetResponse);
            // 
            // LblError
            // 
            this.LblError.AutoSize = true;
            this.LblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblError.Location = new System.Drawing.Point(48, 25);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(0, 18);
            this.LblError.TabIndex = 9;
            this.LblError.Visible = false;
            // 
            // LblResponse
            // 
            this.LblResponse.AutoSize = true;
            this.LblResponse.Location = new System.Drawing.Point(245, 352);
            this.LblResponse.Name = "LblResponse";
            this.LblResponse.Size = new System.Drawing.Size(0, 13);
            this.LblResponse.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::proyectoTicket.Properties.Resources.GEEK;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(409, 353);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cBoxDevices
            // 
            this.cBoxDevices.CausesValidation = false;
            this.cBoxDevices.FormattingEnabled = true;
            this.cBoxDevices.Location = new System.Drawing.Point(62, 289);
            this.cBoxDevices.Name = "cBoxDevices";
            this.cBoxDevices.Size = new System.Drawing.Size(154, 21);
            this.cBoxDevices.TabIndex = 8;
            this.cBoxDevices.Text = "Seleccione";
            this.cBoxDevices.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(414, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(244, 161);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Grabar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(262, 315);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Captar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(414, 190);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(244, 161);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 386);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cBoxDevices);
            this.Controls.Add(this.CboBaudRate);
            this.Controls.Add(this.CboPortList);
            this.Controls.Add(this.LblBaudRate);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.BtnSearchPorts);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox CboBaudRate;
        private System.Windows.Forms.ComboBox CboPortList;
        private System.Windows.Forms.Label LblBaudRate;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Button BtnSearchPorts;
        private System.IO.Ports.SerialPort SpPorts;
        private System.Windows.Forms.Label LblError;
        private System.Windows.Forms.Label LblResponse;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cBoxDevices;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

