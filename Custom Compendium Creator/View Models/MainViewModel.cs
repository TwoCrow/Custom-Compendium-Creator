using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Custom_Compendium_Creator.Models;
using Custom_Compendium_Creator.Stores;

namespace Custom_Compendium_Creator.View_Models
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;

        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;

            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
