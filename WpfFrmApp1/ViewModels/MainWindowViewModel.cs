using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFrmApp1.Models;
using WpfFrmApp1.ViewModels.Views;

namespace WpfFrmApp1.ViewModels
{
    internal class MainWindowViewModel : BaseVM
    {
        
        public MainWindowViewModel()
        {   
            LoadItemMainMenu();
            SelectedMainMenuItem = MainMenuItems[1]; // default 
        }

        #region Title
        private string title = "App `WpfFrmApp1`. Prop title";
        
        public string Title 
        {
            get { return title; }
            set { title = value; }
        }
        #endregion

        #region MainMenuItems        
        private ObservableCollection<MainMenuItemMainWindow> mainMenuItems;

        public ObservableCollection<MainMenuItemMainWindow> MainMenuItems
        {
            get { return mainMenuItems; }
            set
            {
                mainMenuItems = value;
                RaisePropertyChanged(nameof(MainMenuItemMainWindow));
            }
        }
        #endregion

        #region SelectedItem
        private MainMenuItemMainWindow selectedMainMenuItem;

        public MainMenuItemMainWindow SelectedMainMenuItem
        {
            get { return selectedMainMenuItem; }
            set 
            {                 
                selectedMainMenuItem = value;
                Debug.WriteLine($"MainWindowViewModel -- selectedMainMenuItem.Alias -- {selectedMainMenuItem.Alias}");

                TitleDetail = selectedMainMenuItem.Name;
                SwitchView(selectedMainMenuItem.Alias);

                RaisePropertyChanged(nameof(CurrentView));
            }
        }
        #endregion

        private BaseVM currentView;
        public BaseVM CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                RaisePropertyChanged(nameof(CurrentView));
            }
        }

        #region Title
        private string titleDetail = "TitleDetail";

        public string TitleDetail
        {
            get { return titleDetail; }
            set 
            { 
                titleDetail = value;
                Debug.WriteLine($"titleDetail -- {titleDetail}");
                RaisePropertyChanged(nameof(TitleDetail));
            }
        }
        #endregion

        

        public void LoadItemMainMenu()
        {
            MainMenuItems = new ObservableCollection<MainMenuItemMainWindow>()
            {
                new MainMenuItemMainWindow(){ Name = "Управление коэффициентами", Alias ="ManagerIndexes" },
                new MainMenuItemMainWindow(){ Name = "Коэффициенты", Alias ="Indexes"  },
                new MainMenuItemMainWindow(){ Name = "Поставщки", Alias ="Provider"  }
            };
        }

        public void SwitchView(string nameView)
        {
            /*"ManagerIndexes" },
                new MainMenuItemMainWindow(){ Name = "Коэффициенты", Alias ="Indexes"  },
                new MainMenuItemMainWindow(){ Name = "Поставщки", Alias ="Provider"  }
             
             */

            switch (nameView)
            {
                case "ManagerIndexes":
                    ManagerIndexesViewModel managerIndexesViewModel = new ManagerIndexesViewModel();
                    CurrentView = managerIndexesViewModel;
                    // mainWindowViewModel.CurrentView = ManagerIndexesViewModel2;
                    break;

                case "Indexes":
                    IndexesViewModel indexesViewModel = new IndexesViewModel();
                    CurrentView = indexesViewModel;
                    break;
                
                case "Provider":
                    ProvidersViewModel providersViewModel = new ProvidersViewModel();
                    CurrentView = providersViewModel;
                    break;

                    // default: Debug.WriteLine(" ");
            }


        }

    }
}
