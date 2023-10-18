using WpfFrmApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFrmApp1.Data;
using System.Diagnostics;
using System.Windows.Data;
using System.ComponentModel;

namespace WpfFrmApp1.ViewModels.Views
{
    public class IndexesProvidersViewModel : BaseVM
    {       

        public IndexesProvidersViewModel()
        {            
            

            LoadDataTest();
        }

        // public ObservableCollection<Provider> Providers

        private ObservableCollection<IndexProvider> indexProviders;

        public ObservableCollection<IndexProvider> IndexProviders
        {
            get { return indexProviders; }
            set 
            {
                indexProviders = value;

                // RaisePropertyChanged(nameof(indexProviders));
                _IndexProvidersViewSource = new CollectionViewSource();
                _IndexProvidersViewSource.Source = value;
                _IndexProvidersViewSource.Filter += OnIndexProvidersFilter;
                _IndexProvidersViewSource.View.Refresh(); // System.NullReferenceException: "Ссылка на объект не указывает на экземпляр объекта."

                RaisePropertyChanged(nameof(IndexProvidersView));
            }
        }

        private void OnIndexProvidersFilter(object sender, FilterEventArgs e)
        {
            // throw new NotImplementedException();
            if (!(e.Item is IndexProvider indexProvider)) return;

        }

        #region CollectionView

        private CollectionViewSource _IndexProvidersViewSource;

        public ICollectionView IndexProvidersView => _IndexProvidersViewSource?.View;
        #endregion

        #region SelectedIndexCalculation
        private IndexCalculation _selectedIndexCalculation;

        public IndexCalculation SelectedIndexCalculation
        {
            get { return _selectedIndexCalculation; }
            set 
            { 
                _selectedIndexCalculation = value;
                
                Debug.WriteLine($"IndexesProvidersViewModel -- _selectedIndexCalculation.Name -- {_selectedIndexCalculation.Name}");

                // RaisePropertyChanged(nameof(SelectedIndexCalculation));
            }
        }


        #endregion


        public void LoadDataTest()
        {
            TestData td = new TestData();

            IndexProviders = td.IndexProviders;
            Debug.WriteLine($"=== === === === === === === === === === ===");
            Debug.WriteLine($"=== === === === === === === === === === ===");
            Debug.WriteLine($"=== === === === === === === === === === ===");
            Debug.WriteLine($"IndexesProvidersViewModel -- LoadData2() -- IndexProviders {IndexProviders.Count}");
        }
    }
}
