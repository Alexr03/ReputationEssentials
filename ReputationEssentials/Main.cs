using Rocket.Core.Plugins;
using SDG.Unturned;
using System.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReputationEssentials
{
    public class Main : RocketPlugin<ReputationEssentialsConfiguration>
    {
        public static Main Instance;
        public Timer myTimer;

        protected override void Load()
        {
            Instance = this;
            myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(callFunc);
            myTimer.Interval = Configuration.Instance.CheckEvery * 10000;
            myTimer.Enabled = true;
        }

        protected override void Unload()
        {
            Rocket.Core.Logging.Logger.Log("ReputationEssentials has been unloaded!");
            myTimer.Enabled = false;
        }

        private void FixedUpdate()
        {
        }

        private void callFunc(object sender, ElapsedEventArgs e)
        {
            Rocket.Core.Logging.Logger.Log("CallFunc has been activated");
            foreach (SteamPlayer v in Provider.clients)
            {
                Rocket.Core.Logging.Logger.Log(v.SteamPlayerID.CharacterName + " reputation is: " + v.player.skills.reputation);
                if (v.player.skills.reputation >= Configuration.Instance.MaxPositiveRep)
                {
                    v.player.skills.askRep(-v.player.skills.reputation);
                    v.player.skills.askRep(-Configuration.Instance.MaxPositiveRep);
                    SDG.Unturned.SaveManager.save();
                }

                else if (v.player.skills.reputation >= -Configuration.Instance.MaxNegativeRep)
                {
                    v.player.skills.askRep(v.player.skills.reputation);
                    v.player.skills.askRep(Configuration.Instance.MaxNegativeRep);
                    SDG.Unturned.SaveManager.save();
                }
            }
        }
    }
}
