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
        public string Name { get; set; }
        public string Prerequisite { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        public Feat(string name, string prerequisite, string summary, string description)
        {
            this.Name = name;
            this.Prerequisite = prerequisite;
            this.Summary = summary;
            this.Description = description;
        }
    }
}
