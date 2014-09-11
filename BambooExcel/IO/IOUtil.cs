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

        //Give you the directory size
        public static long DirSize(DirectoryInfo d)
        {
            long Size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += DirSize(di);
            }
            return (Size);
        }

        

    }
}
