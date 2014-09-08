using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BambooExcel.IO
{
    static class IOUtil
    {

        public static IEnumerable<FileSystemInfo> GetFileList(string path, string fileFilter, SearchOption searchOption)
        {

            var root = new DirectoryInfo(path);
            var enumerable = new DirSystemEnumerable(root, fileFilter, searchOption);
            enumerable.GetEnumerator();
            return enumerable;

            //DirectoryInfo d = new DirectoryInfo(path);
            //FileInfo[] files = d.GetFiles(fileFilter, searchOption);
            //return files;
        }

        public static IEnumerable<DirectoryInfo> GetDirList(string path, string fileFilter, SearchOption searchOption)
        {

            var root = new DirectoryInfo(path);
            var enumerable = new DirSystemEnumerable(root, fileFilter, searchOption);
            enumerable.GetEnumerator();
            return enumerable;

            //DirectoryInfo d = new DirectoryInfo(path);
            //FileInfo[] files = d.GetFiles(fileFilter, searchOption);
            //return files;
        }

        

    }
}
