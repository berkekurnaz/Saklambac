using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saklambac.NetFramework.Helpers
{
    public class CreateFolder
    {

        public static void CreateForTextDb()
        {
            if (!Directory.Exists(@"SaklambacDb/TextDb"))
            {
                Directory.CreateDirectory(@"SaklambacDb/TextDb");
            }
        }

        public static void CreateForJsonDb()
        {
            if (!Directory.Exists(@"SaklambacDb/JsonDb"))
            {
                Directory.CreateDirectory(@"SaklambacDb/JsonDb");
            }
        }

    }
}
