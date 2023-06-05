using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Custom_Compendium_Creator.Services;

namespace Custom_Compendium_Creator.Commands
{
    public class CancelFeatCommand : CommandBase
    {
        private NavigationService featListNavigationService;

        public CancelFeatCommand(NavigationService featListNavigationService)
        {
            this.featListNavigationService = featListNavigationService;
        }

        public override void Execute(object parameter)
        {
            string warning = "Are you sure you want to return? All unsaved changes will be lost!";
            string title = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(warning, title, buttons);

            if (result == DialogResult.Yes)
            {
                featListNavigationService.Navigate();
            }
        }
    }
}
