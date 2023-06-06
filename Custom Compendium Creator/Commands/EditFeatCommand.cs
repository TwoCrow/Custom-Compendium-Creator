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
    public class EditFeatCommand : CommandBase
    {
        NavigationService featNavigationService;
        FeatViewModel featVM;

        public EditFeatCommand(NavigationService featNavigationService, FeatViewModel featVM)
        {
            this.featNavigationService = featNavigationService;
            this.featVM = featVM;
        }

        public override void Execute(object parameter)
        {
            // Store featVM in storage class, then navigate
            FeatStore.featVM = this.featVM;
            FeatStore.IsExistingFeat = true;

            featNavigationService.Navigate();
        }
    }
}
