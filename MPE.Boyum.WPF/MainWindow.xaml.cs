using System;
using System.Windows;
using Microsoft.Win32;
using MPE.Boyum.Extensions;
using MPE.Boyum.Interfaces;
using MPE.Boyum.Logic.Exceptions;
using MPE.Boyum.Models;
using MPE.Boyum.Models.Data;
using MPE.Boyum.WPF.ViewModels;

namespace MPE.Boyum.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IFileObjectReader<XmlWebOrder, WebOrder> _fileReader;
        private IWebOrderCalculationService _webOrderCalculationService;
        public MainWindow(
            IFileObjectReader<XmlWebOrder, WebOrder> fileReader,
            IWebOrderCalculationService webOrderCalculationService,
            WebOrderViewModel viewModel)
        {
            _fileReader = fileReader;
            _webOrderCalculationService = webOrderCalculationService;
            InitializeComponent();

            DataContext = viewModel;
        }

        private void OpenFileDialogBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();

            dialog.DefaultExt = Configuration.DefaultExtension;
            dialog.Filter = Configuration.DefaultFilter;
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var result = dialog.ShowDialog();

            if (result == true)
            {
                FilePickerPathTxtBox.Text = dialog.FileName;
            }
        }

        private void ProcessBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = _fileReader.Read(FilePickerPathTxtBox.Text);
                if (order.HasValue)
                {
                    var orderObj = order.Value;
                    ((WebOrderViewModel) DataContext).WebOrder = orderObj;
                    
                    ObjIdValue.Content = orderObj.Id;
                    ObjCustomerValue.Content = orderObj.Customer;
                    ObjDateValue.Content = orderObj.Date.ToString("dd. MMMM. yyyy");
                    ObjPriceAverageValue.Content = _webOrderCalculationService.CalculateAverage(orderObj).Formatted();
                    ObjTotalValue.Content = _webOrderCalculationService.CalculateTotal(orderObj).Formatted();
                }
            }
            catch (ParseException ex)
            {
                DisplayError(ex);
            }
        }

        private void DisplayError(Exception ex)
        {
            MessageBox.Show("Error occured\n " + ex.Flatten());
        }
    }
}
