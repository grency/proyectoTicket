using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;

namespace proyectoTicket
{
    public partial class Form1 : Form
    {

        private string bufferIn;
        private string bufferOut;
        private string portConnected = "";
        private delegate void RefreshTextBox();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ResertForm();
        }

        public void ResertForm()
        {
            this.bufferIn = "";
            this.bufferOut = "";
            BtnConnect.Enabled = false;
            //BtnSendData.Enabled = false;
            CboPortList.Enabled = false;
            CboBaudRate.Enabled = false;
            LblError.Visible = false;
            CboPortList.Items.Clear();
            this.portConnected = "";

        }
        private void btnprint_Click_1(object sender, EventArgs e)
        {
            crearTicket ticket = new crearTicket();

            ticket.print(ticket);
        }

        private void BtnSendData_Click(object sender, EventArgs e)
        {
                if (this.portConnected == "")
                    return;

                try
                {

                    SpPorts.DiscardOutBuffer();
                    bufferOut = "Y";
                    Thread.Sleep(10000);
                    SpPorts.Write(bufferOut);

                }
                catch (Exception ex)
                {
                    ResertForm();
                    //MessageBox.Show(ex.Message);
                    Console.WriteLine("Not Send Data.", ex);
                }

        }

        private void SendY()
        {
            if (this.portConnected == "")
                return;

            try
            {

                SpPorts.DiscardOutBuffer();
                bufferOut = "Y";
                Console.WriteLine("AQUI FUE Y.");
                Thread.Sleep(10000);
                SpPorts.Write(bufferOut);

            }
            catch (Exception ex)
            {
                ResertForm();
                //MessageBox.Show(ex.Message);
                Console.WriteLine("Not Send Data.", ex);
            }
        }

        private void SendZ()
        {
            if (this.portConnected == "")
                return;

            try
            {
                Console.WriteLine("ESPERA.");
                Thread.Sleep(10000);
                SpPorts.DiscardOutBuffer();
                bufferOut = "Z";
                Console.WriteLine("AQUI FUE Z.");
                SpPorts.Write(bufferOut);

            }
            catch (Exception ex)
            {
                ResertForm();
                //MessageBox.Show(ex.Message);
                Console.WriteLine("Not Send Data.", ex);
            }
        }

        private void BtnSearchPorts_Click(object sender, EventArgs e)
        {
            if (this.portConnected != "")
                return;

            try
            {
                ResertForm();
                string[] AvailablePorts = SerialPort.GetPortNames();
                //AvailablePorts = new string[] {};

                if (AvailablePorts.Length == 0)
                {
                    LblError.Visible = true;
                    LblError.Text = "No hay puertos disponibles en este momento";
                    CboPortList.Enabled = false;
                    return;
                }

                CboPortList.Enabled = true;
                CboBaudRate.Enabled = true;

                foreach (string _port in AvailablePorts)
                {
                    CboPortList.Items.Add(_port);
                }

                CboPortList.SelectedIndex = 0;
                CboPortList.SelectedIndex = 0;
                BtnConnect.Enabled = true;


            }
            catch (Exception ex)
            {
                ResertForm();
                //MessageBox.Show(ex.Message);
                Console.WriteLine("Exception caught.", ex);
            }

        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            LblError.Visible = false;

            try
            {
                //NO HAY CONNECTADO
                if (this.portConnected == "")
                {
                    int posRate = CboBaudRate.SelectedIndex;
                    if (posRate == -1)
                    {
                        LblError.Visible = true;
                        LblError.Text = "Debe seleccionar la velocidad";
                        return;
                    }
                    int baudRate = Int32.Parse(CboBaudRate.Text);

                    // IMPORTATE: 
                    // INVESTIGAR PROPIEDADES 
                    SpPorts.BaudRate = baudRate;
                    SpPorts.DataBits = 8;
                    SpPorts.Parity = Parity.None;
                    SpPorts.StopBits = StopBits.One;
                    SpPorts.Handshake = Handshake.None;

                    SpPorts.PortName = CboPortList.Text;

                    this.portConnected = CboPortList.Text;
                    ConnectPort();
                }
                else if (this.portConnected != "")
                {
                    this.portConnected = "";
                    DisConnectPort();

                }

            }
            catch (Exception ex)
            {
                ResertForm();
                //MessageBox.Show(ex.Message);
                Console.WriteLine("Error intentar Connectar.", ex);
            }

        }

        private void DisConnectPort()
        {
            CboPortList.Enabled = true;
            CboBaudRate.Enabled = true;
            BtnSearchPorts.Enabled = true;
            BtnConnect.Text = "Conectar";
            SpPorts.Close();


        }

        private void ConnectPort()
        {
            try
            {
                SpPorts.Open();
                CboPortList.Enabled = false;
                CboBaudRate.Enabled = false;
                BtnSearchPorts.Enabled = false;
                BtnConnect.Text = "Desconectar";


            }
            catch (Exception ex)
            {
                CboPortList.Enabled = true;
                CboBaudRate.Enabled = true;
                BtnSearchPorts.Enabled = true;

                //MessageBox.Show(ex.Message);
                Console.WriteLine("Error Al Connectar PUERTO.", ex);

            }

        }

        private void GetResponse(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    RefreshTextBox dataRefresh = new RefreshTextBox(SetResponse);
                    Invoke(dataRefresh);
                }
                else
                {
                    SetResponse();
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en GetResponse", ex);

            }

        }

        private void SetResponse()
        {
            string dataIn = SpPorts.ReadExisting();
            crearTicket ticket = new crearTicket();
            ticket.print(ticket);
            Console.WriteLine("AQUI FUE PRINT.");
            //EJECUTA Y (SUBIR BARRERA)
            this.SendY();
            //EJECUTA Z (BAJAR BARRERA)
            this.SendZ();

        }

        private void CboPortList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CboBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LblBaudRate_Click(object sender, EventArgs e)
        {

        }

        private void InputData_TextChanged(object sender, EventArgs e)
        {

        }

        private void InputResponse_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblInputData_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
