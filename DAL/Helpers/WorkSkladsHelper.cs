namespace Sfarm.Prescriptions.DataUploader.DAL.Helpers
{
    public class WorkSkladsHelper
    {
        public static void UploadSklads(string OidLpu)
        {
            string xml = DAL.Helpers.DataHelper.GetData("PrescriptionsOwnerSkladsByNsiLpuCodeGet", OidLpu);
            string dirXml = $"E:\\UploadedData\\PrescriptionsProject\\OwnersSklads\\xml\\";
            string dirZip = $"E:\\UploadedData\\PrescriptionsProject\\OwnersSklads\\zip\\";

            DAL.Helpers.WorkCommonHelper.XmlZipWork(OidLpu, xml, dirXml, dirZip);
        }
    }
}
