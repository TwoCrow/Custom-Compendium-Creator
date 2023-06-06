using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Compendium_Creator.Services;
using Custom_Compendium_Creator.Stores;

namespace Custom_Compendium_Creator.Commands
{
    public class AddFeatCommand : CommandBase
    {
        private readonly NavigationService navigationService;

        public AddFeatCommand(NavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            FeatStore.IsExistingFeat = false;
            navigationService.Navigate();
        }
    }
}
