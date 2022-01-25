﻿using System.Windows;
using System.Windows.Input;
using ACadAddinManager.ViewModel;

namespace ACadAddinManager.View
{
    /// <summary>
    /// Interaction logic for FrmAddInManager.xaml
    /// </summary>
    public partial class FrmAddInManager : Window
    {
        private readonly AddInManagerViewModel viewModel;
        public FrmAddInManager(AddInManagerViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            this.viewModel = vm;
            vm.FrmAddInManager = this;
        }

        private void TbxDescription_OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (viewModel.MAddinManagerBase.ActiveCmdItem != null && TabControl.SelectedIndex==0)
            {
                viewModel.MAddinManagerBase.ActiveCmdItem.Description = TbxDescription.Text;
            }
            if (viewModel.MAddinManagerBase.ActiveAppItem != null && TabControl.SelectedIndex==1)
            {
                viewModel.MAddinManagerBase.ActiveAppItem.Description = TbxDescription.Text;
            }
            viewModel.MAddinManagerBase.AddinManager.SaveToAimIni();
        }
    }
}