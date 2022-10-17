namespace Sfarm.Prescriptions.DataUploader.DAL.Helpers
{
    public class WorkTovZapHelper
    {
        public static void UploadTovZap(string OidLpu)
        {
            string xml = DAL.Helpers.DataHelper.GetData("PrescriptionsOwnerTovZapByNsiLpuCodeGet", OidLpu);
            string dirXml = $"E:\\UploadedData\\PrescriptionsProject\\OwnersTovZap\\xml\\";
            string dirZip = $"E:\\UploadedData\\PrescriptionsProject\\OwnersTovZap\\zip\\";

            DAL.Helpers.WorkCommonHelper.XmlZipWork(OidLpu, xml, dirXml, dirZip);
        }
    }
}
