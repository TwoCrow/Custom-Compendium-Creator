using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Compendium_Creator.Models;
using Custom_Compendium_Creator.Services;
using Custom_Compendium_Creator.View_Models;

namespace Custom_Compendium_Creator.Commands
{
    public class SaveFeatCommand : CommandBase
    {
        private NavigationService featListNavigationService;
        private Compendium compendium;
        private EditFeatViewModel featVM;

        public SaveFeatCommand(NavigationService featListNavigationService, Compendium compendium, EditFeatViewModel editFeatViewModel)
        {
            this.featListNavigationService = featListNavigationService;
            this.compendium = compendium;
            this.featVM = editFeatViewModel;
        }

        public override void Execute(object parameter)
        {
            Feat feat = ConvertFeat(featVM);
            // Save the changes to the Feat List
            compendium.FeatList.AddFeat(feat);

            // Go back to the Feat List
            featListNavigationService.Navigate();
        }

        public Feat ConvertFeat(EditFeatViewModel featVM)
        {
            return new Feat(featVM.Name, featVM.Prerequisite, featVM.Summary, featVM.Description);
        }
    }
}
