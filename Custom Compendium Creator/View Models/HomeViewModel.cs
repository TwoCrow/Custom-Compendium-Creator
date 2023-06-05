using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Custom_Compendium_Creator.Commands;
using Custom_Compendium_Creator.Services;
using Custom_Compendium_Creator.Stores;

namespace Custom_Compendium_Creator.View_Models
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateCommand { get; } // Takes user to Compendium View

        public HomeViewModel(NavigationService compendiumNavigationService)
        {
            NavigateCommand = new NavigateCommand(compendiumNavigationService);
        }
    }
}
