using System.IO;

namespace TransferDataToDatabase.Common.File
{
    public static class FileHelper
    {
        // ••••••••••••
        // DEFINATIONS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ••••••••••••

        #region Const

        private const int Kbyte = 1024;

        #endregion

        // ••••••••••••
        // METHODS     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ••••••••••••

        #region public static long GetFileSizeInKb(this FileInfo value)

        public static long GetFileSizeInKb(this FileInfo value)
        {
            var fileSize = value.Length/Kbyte;
            return fileSize;
        }

        #endregion

        #region public static long GetFileSizeInKb(this byte[] value)

        public static long GetFileSizeInKb(this byte[] value)
        {
            var fileSize = value.Length/Kbyte;
            return fileSize;
        }

        #endregion
    }
}
