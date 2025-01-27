using System.IO;
using System;

namespace Acknex
{
    public static class PathUtils
    {
        public static void Remove<T>(ref T[] arr, T item)
        {
            var index = Array.IndexOf(arr, item);
            if (index < 0)
            {
                return;
            }
            for (var a = index; a < arr.Length - 1; a++)
            {
                arr[a] = arr[a + 1];
            }
            Array.Resize(ref arr, arr.Length - 1);
        }

        public static string SanitizePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }
            var invalids = Path.GetInvalidFileNameChars();
            Remove(ref invalids, Path.AltDirectorySeparatorChar);
            Remove(ref invalids, Path.DirectorySeparatorChar);
            Remove(ref invalids, Path.PathSeparator);
            Remove(ref invalids, Path.VolumeSeparatorChar);
            var split = path.Split(invalids, StringSplitOptions.RemoveEmptyEntries);
            path = string.Join("_", split);
            path = path.Replace('\\', '/');
            return path;
        }

        public static string GetFileExtension(string path, bool includeDot = true)
        {
            path = SanitizePath(path);
            var lastDot = path.LastIndexOf('.');
            if (lastDot < 0)
            {
                return null;
            }

            return path.Substring(includeDot ? lastDot : lastDot + 1).ToLowerInvariant();
        }

        public static string GetFileDirectory(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return null;
            }

            filename = SanitizePath(filename);
            var indexOfSlash = filename.LastIndexOf("/");
            if (indexOfSlash >= 0)
            {
                return filename.Substring(0, indexOfSlash);
            }

            return null;
        }
    }
}