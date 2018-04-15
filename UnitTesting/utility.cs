using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public static class utility
    {
        public static void Rename(this FileInfo fileInfo, string newName)
        {
            fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + newName);
        }

    }
}
