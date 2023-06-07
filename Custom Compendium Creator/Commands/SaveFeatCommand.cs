using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Compendium_Creator.Models;
using Custom_Compendium_Creator.Services;
using Custom_Compendium_Creator.Stores;
using Custom_Compendium_Creator.View_Models;

namespace Custom_Compendium_Creator.Commands
{
    public class SaveFeatCommand : CommandBase
    {
        private NavigationService featListNavigationService;
        private Compendium compendium;
        private EditFeatViewModel featVM;
        private FeatViewModel oldFeat;

        public SaveFeatCommand(NavigationService featListNavigationService, Compendium compendium, EditFeatViewModel editFeatViewModel, FeatViewModel oldFeat)
        {
            this.featListNavigationService = featListNavigationService;
            this.compendium = compendium;
            this.featVM = editFeatViewModel;
            this.oldFeat = oldFeat;
        }

        public override void Execute(object parameter)
        {
            // Set the description string since C# hates the idea of allowing RichTextBox data binding
            featVM.Description = FeatDescriptionStore.Description;

            // If the Feat doesn't already exist, add the Feat to the list.
            if (!FeatStore.IsExistingFeat)
            {
                Feat feat = ConvertFeat(featVM);
                compendium.FeatList.AddFeat(feat);
            }
            // Otherwise, update the Feat so we're not adding the user's changes as a whole new Feat.
            else
            {
                compendium.FeatList.UpdateFeat(oldFeat.Feat, ConvertFeat(featVM));
            }

            // Go back to the Feat List
            featListNavigationService.Navigate();
        }

        public Feat ConvertFeat(EditFeatViewModel featVM)
        {
            return new Feat(featVM.Name, featVM.Prerequisite, featVM.Summary, featVM.Description);
        }
    }
}
