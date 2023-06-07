using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Custom_Compendium_Creator.Commands;
using Custom_Compendium_Creator.Models;
using Custom_Compendium_Creator.Services;
using Custom_Compendium_Creator.Stores;
using Custom_Compendium_Creator.Views;

namespace Custom_Compendium_Creator.View_Models
{
    public class EditFeatViewModel : ViewModelBase
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string prerequisite;
        public string Prerequisite
        {
            get
            {
                return prerequisite;
            }
            set
            {
                prerequisite = value;
                OnPropertyChanged(nameof(Prerequisite));
            }
        }

        private string summary;
        public string Summary
        {
            get
            {
                return summary;
            }
            set
            {
                summary = value;
                OnPropertyChanged(nameof(Summary));
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ICommand SaveFeatCommand { get; }
        public ICommand CancelFeatCommand { get; }

        public EditFeatViewModel(NavigationService featListNavigationService, Compendium compendium)
        {
            SaveFeatCommand = new SaveFeatCommand(featListNavigationService, compendium, this, FeatStore.featVM);
            CancelFeatCommand = new CancelFeatCommand(featListNavigationService);

            // Load feat from Feat Storage
            LoadFeat(FeatStore.featVM);
        }

        // When the user clicks edit on the feat list, this method will load that feat into the edit feat view.
        public void LoadFeat(FeatViewModel featVM)
        {
            // Only load the feat's information if the feat already exists. 
            if (featVM != null && FeatStore.IsExistingFeat)
            {
                this.name = featVM.Name;
                this.prerequisite = featVM.Prerequisite;
                this.summary = featVM.Summary;
                this.description = featVM.Description;
                // We have to set the FeatDescriptionStore here too so that the xaml.cs knows to display the correct text.
                // I am not a fan of this solution.
                FeatDescriptionStore.Description = featVM.Description;
            }
        }
    }
}
