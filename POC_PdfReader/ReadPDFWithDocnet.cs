using Docnet.Core;
using Docnet.Core.Exceptions;

namespace POC_PdfReader
{
    public class ReadPDFWithDocnet
    {
        public static string ReadAllPagesFromPDF(string directory)
        {
            try
            {
                string resultado = string.Empty;
                var docReader = DocLib.Instance.GetDocReader(directory, new Docnet.Core.Models.PageDimensions());
                for (var i = 0; i < docReader.GetPageCount(); i++)
                {
                    using (var pageReader = docReader.GetPageReader(i))
                    {
                        resultado += pageReader.GetText();
                    }
                }
                return resultado;
            }
            catch (DocnetException)
            {
                return string.Empty;
            }

        }
    }
}
