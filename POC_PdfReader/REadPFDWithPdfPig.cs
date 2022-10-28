using System;
using System.Linq;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Exceptions;

namespace POC_PdfReader
{
    public class ReadPFDWithPdfPig
    {
        public static string Process(byte[] attachment)
        {
            try
            {
                // Abrindo o PDF
                using (var document = PdfDocument.Open(attachment))
                {
                    return string.Join(" ", document.GetPages().ToList().SelectMany(p => p.GetWords().Select(t => t.Text)) ?? new string[0]);
                }
            }
            catch (PdfDocumentEncryptedException)
            {
                return string.Empty;
            }
            catch (PdfDocumentFormatException)
            {
                return string.Empty;
            }
            catch (InvalidOperationException)
            {
                return string.Empty;
            }            
        }
    }
}
