﻿using System.IO;
using AddinManagerCore;
using RevitAddinManager.Model;

namespace ACadAddinManager.Model
{
    public class RevitAddin : ViewModelBase
    {
        public VisibleModel State { get; set; }
        public string FilePath { get; set; }
        public string Assembly { get; set; }
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string NameNotEx { get; set; }
        public string FullClassName { get; set; }
        public string Text { get; set; }
        public string VisibilityMode { get; set; }
        public string LanguageType { get; set; }
        public string VendorId { get; set; }
        public string VendorDescription { get; set; }
        public AddinType AddinType { get; set; }

        private bool _IsChecked;
        public bool IsChecked
        {
            get => _IsChecked;
            set => OnPropertyChanged(ref _IsChecked, value);
        }

        public void SetToggleState()
        {
            try
            {
                RenamePath();
            }
            catch (UnauthorizedAccessException e)
            {
                //TODO : Resource.NeedAdmin : Access Denied
                throw new System.ArgumentException("Need Adin", e);
            }
        }
        private bool RenamePath()
        {
            if (!File.Exists(FilePath)) return false;
            string dir = Path.GetDirectoryName(FilePath);
            string FileName = Path.GetFileName(FilePath);
            string newFilePath;
            string newName;
            switch (State)
            {
                case VisibleModel.Enable:
                    newName = FileName.Insert(FileName.Length, DefaultSetting.FormatDisable);
                    newFilePath = Path.Combine(dir, newName);
                    break;
                case VisibleModel.Disable:
                    newName = FileName.Replace(DefaultSetting.FormatDisable,"");
                    newFilePath = Path.Combine(dir, newName);
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
            if(File.Exists(newFilePath))File.Delete(newFilePath);
            if (FilePath != null)
            {
                File.Move(FilePath, newFilePath);
                Path.ChangeExtension(FilePath, DefaultSetting.FormatDisable);
            }

            return true;
        }

        public void GetRelativePath()
        {

        }

    }



}
