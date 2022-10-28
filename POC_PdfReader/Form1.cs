using iText.Kernel.Pdf;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace POC_PdfReader
{
    public partial class Form1 : Form
    {
        private static readonly string basedir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public Form1()
        {
            InitializeComponent();
            //txtDiretorio.Text = basedir + @"\resources\cli187-id177845857.pdf";
            //txtDiretorio.Text = basedir + @"\resources\cli212-id177375737.pdf";
            //txtDiretorio.Text = basedir + @"\resources\cli212-id177382163.pdf";
            txtDiretorio.Text = basedir + @"\resources\10840.pdf";
            //txtDiretorio.Text = basedir + @"\resources\pdfToText.pdf";
            //txtDiretorio.Text = basedir + @"\resources\pdfToText_protected.pdf";
            //txtDiretorio.Text = basedir + @"\resources\sample-pdf-download-10-mb.pdf";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtResultado.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            string resultado;
            PdfDocument pdfDoc;
            pdfDoc = new PdfDocument(new PdfReader(txtDiretorio.Text));
            var fileBytes = File.ReadAllBytes(txtDiretorio.Text);

            resultado = ReadPFDWithPdfPig.Process(fileBytes);

            if (resultado == "")
            {
                MessageBox.Show("A biblioteca PdfPig não pôde abrir o arquivo informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = ReadPDFWithiText.ReadAllPagesFromPDF(out pdfDoc, txtDiretorio.Text);
            }
            if (resultado == "")
            {
                MessageBox.Show("A biblioteca iText não pôde abrir o arquivo informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = ReadPDFWithDocnet.ReadAllPagesFromPDF(txtDiretorio.Text);
            }
            if (resultado == "")
            {
                MessageBox.Show("A biblioteca Docnet não pôde abrir o arquivo informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                txtResultado.Text = resultado;

            //pdfDoc.Close();

            MessageBox.Show("Processo concluído!");
        }


    }
}
