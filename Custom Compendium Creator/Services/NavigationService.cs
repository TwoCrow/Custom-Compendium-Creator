using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Compendium_Creator.Stores;
using Custom_Compendium_Creator.View_Models;

namespace Custom_Compendium_Creator.Services
{
    public class NavigationService
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<ViewModelBase> createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }

        public void Navigate()
        {
            navigationStore.CurrentViewModel = createViewModel();
        }
    }
}
