using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Compendium_Creator.Models
{
    // Compendium contains lists of all homebrew categories.
    public class Compendium
    {
        // Compendium Save File Fields
        public string Name { get; } // Name of the Compendium

        // Category Lists
        public FeatList FeatList { get; }

        public Compendium()
        {
            FeatList = new FeatList();
        }
    }
}
