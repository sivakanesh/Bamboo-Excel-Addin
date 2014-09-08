using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;

namespace BambooExcel.IO
{
    class DirSystemEnumerable : IEnumerable<DirectoryInfo>
    {
        private readonly DirectoryInfo _root;
        private readonly IList<string> _patterns;
        private readonly SearchOption _option;
        public IList<string> PathException;

        public DirSystemEnumerable(DirectoryInfo root, string pattern, SearchOption option)
        {
            _root = root;
            _patterns = new List<string> { pattern };
            _option = option;
            PathException = new List<String>();
        }

        public DirSystemEnumerable(DirectoryInfo root, IList<string> patterns, SearchOption option)
        {
            _root = root;
            _patterns = patterns;
            _option = option;
            PathException = new List<String>();
        }

        public IEnumerator<DirectoryInfo> GetEnumerator()
        {
            if (_root == null || !_root.Exists) yield break;

            IEnumerable<DirectoryInfo> matches = new List<DirectoryInfo>();
            try
            {
                foreach (var pattern in _patterns)
                {
                    matches = matches.Concat(_root.EnumerateDirectories(pattern, SearchOption.TopDirectoryOnly));
                }
            }
            catch (UnauthorizedAccessException uauthe)
            {
                PathException.Add(string.Format("{0} - {1}", "Unauthorised Access", uauthe.Message));
                yield break;
            }
            catch (PathTooLongException ptle)
            {
                PathException.Add(string.Format("{0} - {1}", "Path too long", ptle.Message));
                yield break;
            }

            foreach (var dir in matches)
            {
                yield return dir;
            }

            if (_option == SearchOption.AllDirectories)
            {
                foreach (var dir in _root.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
                {
                    var fileSystemInfos = new DirSystemEnumerable(dir, _patterns, _option);
                    foreach (var match in fileSystemInfos)
                    {
                        yield return match;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
