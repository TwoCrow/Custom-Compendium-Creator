using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Compendium_Creator.View_Models;

namespace Custom_Compendium_Creator.Stores
{
    public static class FeatStore
    {
        public static FeatViewModel featVM { get; set; }
        public static bool IsExistingFeat { get; set; }
    }
}
