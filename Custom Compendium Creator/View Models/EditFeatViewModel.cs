using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Custom_Compendium_Creator.Commands;
using Custom_Compendium_Creator.Models;
using Custom_Compendium_Creator.Services;
using Custom_Compendium_Creator.Stores;

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
            SaveFeatCommand = new SaveFeatCommand(featListNavigationService, compendium, this);
            CancelFeatCommand = new CancelFeatCommand(featListNavigationService);

            // Load feat from Feat Storage
            LoadFeat(FeatStore.featVM);
        }

        public void LoadFeat(FeatViewModel featVM)
        {
            if (featVM != null && FeatStore.IsExistingFeat)
            {
                this.name = featVM.Name;
                this.prerequisite = featVM.Prerequisite;
                this.summary = featVM.Summary;
                this.description = featVM.Description;
            }
        }
    }
}
