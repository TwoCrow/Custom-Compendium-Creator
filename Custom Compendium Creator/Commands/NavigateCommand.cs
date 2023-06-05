using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Compendium_Creator.Services;
using Custom_Compendium_Creator.Stores;
using Custom_Compendium_Creator.View_Models;

namespace Custom_Compendium_Creator.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            navigationService.Navigate();
        }
    }
}
