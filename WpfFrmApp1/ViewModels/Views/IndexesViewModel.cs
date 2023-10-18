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
    public class IndexesViewModel : BaseVM
    {
        
        public ManagerIndexesViewModel managerIndexesViewModel;
        public IndexesViewModel(ManagerIndexesViewModel managerIndexesViewModel)
        {
            this.managerIndexesViewModel = managerIndexesViewModel;

            Debug.WriteLine($"IndexesViewModel -- Конструктор -- IndexesViewModel(ManagerIndexesViewModel managerIndexesViewModel)");
            LoadDataTest();
        }


        public IndexesViewModel()
        {
            Debug.WriteLine($"IndexesViewModel -- Конструктор -- IndexesViewModel()");
            LoadDataTest();
        }

        


        private ObservableCollection<IndexCalculation> calculationIndexs;

        public ObservableCollection<IndexCalculation> СalculationIndexs
        {
            get { return calculationIndexs; }
            set 
            { 
                calculationIndexs = value;
                RaisePropertyChanged(nameof(СalculationIndexs));
            }
        }

        private IndexCalculation selectedIndexCalculation;

        public IndexCalculation SelectedIndexCalculation
        {
            get { return selectedIndexCalculation; }
            set 
            { 
                selectedIndexCalculation = value;

                Debug.WriteLine($"--- --- --- --- --- --- --- --- ---");
                Debug.WriteLine($"IndexesViewModel--selectedIndexCalculation -- Start ");
                if (this.managerIndexesViewModel == null) return;                
                this.managerIndexesViewModel.SelectedIndexCalculation = SelectedIndexCalculation;

                RaisePropertyChanged(nameof(SelectedIndexCalculation));                
                Debug.WriteLine($"IndexesViewModel--selectedIndexCalculation -- {selectedIndexCalculation.Name} -- END");
            }
        }


        public void LoadDataTest()
        {
            TestData td = new TestData();

            СalculationIndexs = td.СalculationIndexes;
            Debug.WriteLine($"=== === === === === === === === === === ===");
            Debug.WriteLine($"=== === === === === === === === === === ===");
            Debug.WriteLine($"=== === === === === === === === === === ===");
            Debug.WriteLine($"СalculationIndexs {СalculationIndexs.Count}");
        }
        // 
    }
}
