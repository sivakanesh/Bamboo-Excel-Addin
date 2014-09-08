using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BambooExcel
{
    static class IOUtil
    {

        public static FileInfo[] GetFileList(string path, string fileFilter, SearchOption searchOption)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles(fileFilter, searchOption);
            return files;
        }

    }
}
