using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReputationEssentials
{
    public class ReputationEssentialsConfiguration : IRocketPluginConfiguration
    {
        public int CheckEvery;
        public int MaxPositiveRep;
        public int MaxNegativeRep;

        public void LoadDefaults()
        {
            CheckEvery = 2;
            MaxPositiveRep = 1000;
            MaxNegativeRep = 1000;
        }
    }
}
