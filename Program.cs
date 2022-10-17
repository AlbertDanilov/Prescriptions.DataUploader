using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfarm.Prescriptions.DataUploader
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PrescriptionsOwnersGetResult> lpuOids = DAL.Helpers.DataHelper.LpuOidsGet();

            foreach (PrescriptionsOwnersGetResult lpu in lpuOids)
            {
                if (!string.IsNullOrEmpty(lpu.NsiLpuCode.Trim()))
                {
                    Task.Run(() => DAL.Helpers.WorkSkladsHelper.UploadSklads(lpu.NsiLpuCode)).Wait();
                    Task.Run(() => DAL.Helpers.WorkTovZapHelper.UploadTovZap(lpu.NsiLpuCode)).Wait();
                }
            }
        }
    }
}
