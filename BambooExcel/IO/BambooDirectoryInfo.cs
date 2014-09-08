using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BambooExcel.IO
{
    class BambooDirectoryInfo : IEquatable<BambooDirectoryInfo>
    {
        public DirectoryInfo DirectoryInfo { get; set; }

        public DateTime LatestLastAccessTimeForFiles 
        {
            get
            {
                var directory = new DirectoryInfo(this.DirectoryInfo.Name);
                var myFile = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
                return myFile.LastAccessTime;
            }
        }

        public bool Equals(BambooDirectoryInfo meta)
        {
            return (this.DirectoryInfo.Name == meta.DirectoryInfo.Name && 
                    this.DirectoryInfo.LastAccessTime == meta.DirectoryInfo.LastAccessTime);
        }

    }
}
