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
        public string Name { get; }

        // Category Lists
        private FeatList featList;

        public Compendium(string name)
        {
            this.Name = name;

            featList = new FeatList();
        }
    }
}
