﻿using System;
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
                DirectoryInfo di = Directory.CreateDirectory(@"SaklambacDb/TextDb");
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
        }

        public static void CreateForJsonDb()
        {
            if (!Directory.Exists(@"SaklambacDb/JsonDb"))
            {
                DirectoryInfo di = Directory.CreateDirectory(@"SaklambacDb/JsonDb");
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
        }

    }
}
