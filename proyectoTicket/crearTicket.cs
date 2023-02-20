using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using System.IO.Ports;
using System.Net.Http.Headers;
using System.Threading;

namespace proyectoTicket
{
    public class crearTicket
    {
        //public string document { get; set; }

        //public string rif { get; set; }
        //public string corporation { get; set; }
        //public string company { get; set; }

        //public string receiptNumber { get; set; }
        //public string inputBox { get; set; }
        //public string entryDate { get; set; }
        //public string entryTime { get; set; }

        //public string codBar { get; set; }

        //public string company2 { get; set; }
        //public string address { get; set; }

        //public string phoneNumber { get; set; }


        public Image logo { get; set; }

        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog vista = new PrintPreviewDialog();
        private PrintEventArgs end = new PrintEventArgs();
        //private SerialPort SpPorts;
        //private string bufferOut;


        public void print(crearTicket p)
        {
            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;
            doc.PrintPage += new PrintPageEventHandler(printticket);
            vista.Document = doc;
            vista.Show();
            //doc.EndPrint
            //doc.Print();

            //SpPorts.DiscardOutBuffer();
            //Thread.Sleep(10000);
            //Console.WriteLine("AQUI FUE Y.");
            //bufferOut = "Y";
            //Thread.Sleep(10000);
            //SpPorts.Write(bufferOut);
        }

        public void printticket(object sender, PrintPageEventArgs e)
        {

            this.generateBarCode();

            int posX, posY;
            Font fuente = new Font("consola", 7, FontStyle.Bold);
            try
            {
                posX = 30;
                posY = 10;
                e.Graphics.DrawString("Documento : Ticket de entrada  ", fuente, Brushes.Black, posX, posY);
                posY += 12;
                e.Graphics.DrawString("Centro Comercial", fuente, Brushes.Black, posX, posY);
                posY += 12;
                e.Graphics.DrawString("Ciudad Trinitarias", fuente, Brushes.Black, posX, posY);
                posY += 12;
                e.Graphics.DrawString("RIF : J-123456789-8", fuente, Brushes.Black, posX, posY);
                posY += 12;
                e.Graphics.DrawString("Corporación : 0001", fuente, Brushes.Black, posX, posY);
                posY += 12;
                e.Graphics.DrawString("Compañia : 0001", fuente, Brushes.Black, posX, posY);
                posY += 12;
                e.Graphics.DrawString("Nro, Recibo : 0670", fuente, Brushes.Black, posX, posY);
                posY += 12;
                e.Graphics.DrawString("Caja de Entrada : 0005", fuente, Brushes.Black, posX, posY);
                posY += 12;
                e.Graphics.DrawString("Fecha de Entrada : 31-12-1969", fuente, Brushes.Black, posX, posY);
                posY += 12;
                e.Graphics.DrawString("Hora de Entrada : 10:46:46", fuente, Brushes.Black, posX, posY);
                posY += 12;
                e.Graphics.DrawImage(logo, 5, 140, 210, 80);
                posY += 110;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void generateBarCode()
        {
            Image imgCod;


            int indice = 31;
            BarcodeLib.TYPE typeCod = (BarcodeLib.TYPE)indice;


            Barcode cod = new Barcode();
            cod.IncludeLabel = true;
            cod.LabelPosition = LabelPositions.BOTTOMCENTER;

            //AQUI PASALE EL TEXTO DEL TXT  "CODIGO"
            imgCod = cod.Encode(typeCod, "000100010670", Color.Black, Color.White, 300, 100);
            Console.WriteLine("tipo de codigo indice  " + indice);

            Console.WriteLine("tipo de codigo   " + typeCod);

            //EXTRA Y AL ULTIMO
            //Bitmap imagenTitulo = convertirTextoImagen("            ", 300, Color.White);

            int alto_imagen_nuevo = imgCod.Height;

            Bitmap newImg = new Bitmap(300, alto_imagen_nuevo);
            Graphics dibujar = Graphics.FromImage(newImg);

            //dibujar.DrawImage(imagenTitulo, new Point(0, 0));
            dibujar.DrawImage(imgCod, new Point(0, 0));



            //pictureBox1.BackgroundImage = imagenCodigo;
            //pictureBox1.BackgroundImage = imagenNueva;
            this.logo = newImg;
        }

        public static Bitmap convertTextToImg(string text, int ancho, Color color)
        {
            //creamos el objeto imagen Bitmap
            Bitmap objBitmap = new Bitmap(1, 1);
            int Width = 0;
            int Height = 0;
            //formateamos la fuente (tipo de letra, tamaño)
            System.Drawing.Font objFont = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

            //creamos un objeto Graphics a partir del Bitmap
            Graphics objGraphics = Graphics.FromImage(objBitmap);

            //establecemos el tamaño según la longitud del texto
            Width = ancho;
            Height = (int)objGraphics.MeasureString(text, objFont).Height + 5;
            objBitmap = new Bitmap(objBitmap, new Size(Width, Height));

            objGraphics = Graphics.FromImage(objBitmap);

            objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            objGraphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            objGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            objGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            StringFormat drawFormat = new StringFormat();
            objGraphics.Clear(color);

            drawFormat.Alignment = StringAlignment.Center;
            objGraphics.DrawString(text, objFont, new SolidBrush(Color.Black), new RectangleF(0, (objBitmap.Height / 2) - (objBitmap.Height - 10), objBitmap.Width, objBitmap.Height), drawFormat);
            objGraphics.Flush();


            return objBitmap;
        }

    }
}
