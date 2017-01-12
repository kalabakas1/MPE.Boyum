using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MPE.Boyum.Interfaces;
using MPE.Boyum.Models;
using MPE.Boyum.WPF.Annotations;

namespace MPE.Boyum.WPF.ViewModels
{
    public class WebOrderViewModel : INotifyPropertyChanged
    {
        private IWebOrderCalculationService _calculationService;
        public WebOrderViewModel(
            IWebOrderCalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public WebOrder WebOrder { get; set; }

        public string FilePath { get; set; }
        public int Id { get { return WebOrder?.Id ?? 0; } }
        public string Customer { get { return WebOrder?.Customer ?? ""; } }
        public string Date { get { return WebOrder?.Date.ToString("dd. MMMM. yyyy") ?? "-"; } }

        public decimal PriceAverage
        {
            get { return _calculationService.CalculateAverage(WebOrder); }
        }

        public decimal Total
        {
            get
            {
                return _calculationService.CalculateTotal(WebOrder);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
