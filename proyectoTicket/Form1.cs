using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Drawing;
using System.Drawing.Imaging;

namespace proyectoTicket
{
    public partial class Form1 : Form
    {
        public string Path = @"C:\\Users\\DELL\\Desktop\\proyectoTicket\\proyectoTicket\\images";
        private bool devices = false; //cargar dispositivos
        private FilterInfoCollection myDevices; //dispositivos de video
        private VideoCaptureDevice webCam;

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
            this.SearchDevices();
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
        private void SendToPrint()
        {
            crearTicket ticket = new crearTicket();

            ticket.print(ticket);
            Thread.Sleep(15000);
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
                Thread.Sleep(5000);
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
            this.SendToPrint();
            Console.WriteLine("AQUI FUE PRINT.");
            //EJECUTA Y (SUBIR BARRERA)
            this.SendY();            

        }
        public void SearchDevices()
        {
            //buscar dispositivos installados en el aquipo

            myDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (myDevices.Count > 0)
            {
                devices = true;
                for (int i = 0; i < myDevices.Count; i++)
                    cBoxDevices.Items.Add(myDevices[i].Name.ToString());

                cBoxDevices.Text = myDevices[0].Name.ToString();
            }
            else
            {
                devices = false;
            }
        }
        public void ClosedWebCam()
        {
            if (webCam != null && webCam.IsRunning)
            {
                webCam.SignalToStop();
                webCam = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //captar video deberia ir el metodo donde capta la i 
            this.ClosedWebCam();
            int i = cBoxDevices.SelectedIndex;
            string nameVideo = myDevices[i].MonikerString;
            webCam = new VideoCaptureDevice(nameVideo);
            webCam.NewFrame += new NewFrameEventHandler(CapPhoto);
            webCam.Start();
        }
        private void CapPhoto(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Img = (Bitmap)eventArgs.Frame.Clone();
            pictureBox2.Image = Img;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ClosedWebCam();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (webCam != null && webCam.IsRunning)
            {
                pictureBox3.Image = pictureBox2.Image;
                pictureBox3.Image.Save(Path+"image.jpg", ImageFormat.Jpeg);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
