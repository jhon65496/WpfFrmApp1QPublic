using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFrmApp1.Models;
using WpfFrmApp1.Views.Views;

namespace WpfFrmApp1.ViewModels.Views
{
    public class ManagerIndexesViewModel : BaseVM
    {  
        IndexesViewModel indexesViewModel;
        ProvidersViewModel providersViewModel;

        IndexesProvidersViewModel indexesProvidersViewModel;


        public ManagerIndexesViewModel()
        {
            // ViewModel
            this.indexesViewModel = new IndexesViewModel(this);
            this.providersViewModel = new ProvidersViewModel();                        
            this.indexesProvidersViewModel = new IndexesProvidersViewModel();

            // View+ViewModel
            IndexesView indexesV = new IndexesView();
            indexesV.DataContext = indexesViewModel;

            ProvidersView providersView = new ProvidersView();
            providersView.DataContext = providersViewModel;


            IndexesProvidersView indexesProvidersView = new IndexesProvidersView();
            indexesProvidersView.DataContext = indexesProvidersViewModel;


            // View -> ContentControl
            IndexesView = this.indexesViewModel;
            ProvidersView = this.providersViewModel;
            IndexesProvidersView = this.indexesProvidersViewModel;


            SelectedIndexCalculation = indexesViewModel.SelectedIndexCalculation;
        }

        private IndexCalculation selectedIndexCalculation;

        public IndexCalculation SelectedIndexCalculation
        {
            get { return selectedIndexCalculation; }
            set 
            {
                selectedIndexCalculation = value;

                if (selectedIndexCalculation == null) return;                
                Debug.WriteLine($"ManagerIndexesViewModel--indexCalculation.Name -- {selectedIndexCalculation.Name}");
                


                if (indexesProvidersViewModel == null) return;
                // indexesProvidersViewModel.SelectedIndexCalculation = selectedIndexCalculation;
                this.indexesProvidersViewModel.SelectedIndexCalculation = selectedIndexCalculation;
                RaisePropertyChanged(nameof(IndexCalculation));            
            }
        }



        /// <summary>
        /// View
        /// </summary>
        #region View
        // IndexesView
        private BaseVM indexesView;

        public BaseVM IndexesView
        {
            get { return indexesView; }
            set 
            { 
                indexesView = value;
                RaisePropertyChanged(nameof(IndexesView));            
            }
        }

        // ProvidersView
        private BaseVM providersView;

        public BaseVM ProvidersView
        {
            get { return providersView; }
            set
            { 
                providersView = value;
                RaisePropertyChanged(nameof(ProvidersView));
            }
        }

        // IndexesProvidersView
        private BaseVM indexesProvidersView;

        public BaseVM IndexesProvidersView
        {
            get { return indexesProvidersView; }
            set
            { 
                indexesProvidersView = value;
                RaisePropertyChanged(nameof(IndexesProvidersView));
            }
        }
        #endregion


    }
}
