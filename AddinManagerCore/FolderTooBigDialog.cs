﻿using System.Text;

namespace AddinManagerCore
{
    internal static class FolderTooBigDialog
    {
        /// <summary>
        /// Show a waring if file dll too large
        /// </summary>
        /// <param name="folderPath">folder contains file resource</param>
        /// <param name="sizeInMB">limit of dll size</param>
        /// <returns></returns>
        public static DialogResult Show(string folderPath, long sizeInMB)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Folder [" + folderPath + "]");
            stringBuilder.AppendLine("is " + sizeInMB + "MB large.");
            stringBuilder.AppendLine("AddinManager will attempt to copy all the files to temp folder");
            stringBuilder.AppendLine("Select [Yes] to copy all the files to temp folder");
            stringBuilder.AppendLine("Select [No] to only copy test script DLL");
            string text = stringBuilder.ToString();
            return MessageBox.Show(text, DefaultSetting.AppName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }
    }
}
