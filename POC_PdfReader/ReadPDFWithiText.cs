using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.IO;
using System.Text;

namespace POC_PdfReader
{
    public class ReadPDFWithiText
    {
        public static string ReadAllPagesFromPDF(out PdfDocument pdfDoc, string directory)
        {

            try
            {
                StreamReader streamReader;
                string resultado = string.Empty;
                pdfDoc = new PdfDocument(new PdfReader(directory));
                var strategy = new LocationTextExtractionStrategy();

                PdfCanvasProcessor parser = new PdfCanvasProcessor(strategy);
                //parser.ProcessPageContent(pdfDoc.GetFirstPage());
                var numberOfPages = pdfDoc.GetNumberOfPages();
                byte[] array;
                for (int page = 1; page <= numberOfPages; page++)
                {
                    parser.ProcessPageContent(pdfDoc.GetPage(page));
                    array = Encoding.UTF8.GetBytes(strategy.GetResultantText());
                    var memoryStream = new MemoryStream(array);
                    streamReader = new StreamReader(memoryStream);
                    resultado += streamReader.ReadToEnd();
                }
                return resultado;
            }
            catch (InvalidOperationException)
            {
                pdfDoc = null;
                return string.Empty;
            }

        }
    }
}
