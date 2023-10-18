using WpfFrmApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFrmApp1.Data;
using System.Diagnostics;

namespace WpfFrmApp1.ViewModels.Views
{
    public class ProvidersViewModel : BaseVM
    {   
        
        public ProvidersViewModel()
        {                        
            LoadDataTest();
        }

        // public ObservableCollection<Provider> Providers

        private ObservableCollection<Provider> providers;

        public ObservableCollection<Provider> Providers
        {
            get { return providers; }
            set 
            { 
                providers = value;
                RaisePropertyChanged(nameof(providers));
            }
        }

        public void LoadDataTest()
        {
            TestData td = new TestData();

            Providers = td.Providers;
            Debug.WriteLine($"=== === === === === === === === === === ===");
            Debug.WriteLine($"=== === === === === === === === === === ===");
            Debug.WriteLine($"=== === === === === === === === === === ===");
            Debug.WriteLine($"СalculationIndexs {Providers.Count}");
        }
    }
}
