using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Compendium_Creator.Models
{
    // Contains the list of all Feats
    public class FeatList
    {
        private List<Feat> feats;

        public FeatList()
        {
            feats = new List<Feat>();
        }

        public List<Feat> GetAllFeats()
        {
            return feats;
        }

        public void AddFeat(Feat feat)
        {
            feats.Add(feat);
        }

        public void RemoveFeat(Feat feat)
        {
            feats.Remove(feat);
        }

        // When a user saves edits to a Feat, apply those changes rather than adding a new feat.
        public void UpdateFeat(Feat oldFeat, Feat newFeat)
        {
            int index = feats.IndexOf(oldFeat);

            feats[index] = newFeat;
        }
    }
}
