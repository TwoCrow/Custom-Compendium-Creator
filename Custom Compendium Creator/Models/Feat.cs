using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Compendium_Creator.Models
{
    // Base level of Feats
    public class Feat
    {
        public string Name { get; }
        public string Description { get; }

        public Feat(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
