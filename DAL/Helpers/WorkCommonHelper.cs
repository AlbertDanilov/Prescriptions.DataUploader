using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfarm.Prescriptions.DataUploader.DAL.Helpers
{
    public class WorkCommonHelper
    {
        public static void XmlZipWork(string OidLpu, string xml, string dirXml, string dirZip) 
        {
            if (!string.IsNullOrEmpty(xml))
            {
                File.Delete($"{dirXml}{OidLpu}.xml");
                File.Delete($"{dirZip}{OidLpu}.zip");
                File.AppendAllText($"{dirXml}{OidLpu}.xml", xml);
                ZipFile.CreateFromDirectory(dirXml, $"{dirZip}\\{OidLpu}.zip", CompressionLevel.Optimal, false, Encoding.UTF8);
                File.Delete($"{dirXml}{OidLpu}.xml");
            }
        }
    }
}
