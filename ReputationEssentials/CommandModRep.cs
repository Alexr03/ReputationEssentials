using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReputationEssentials
{

    class CommandAddRep : IRocketCommand
    {
        public string Help
        {
            get { return ""; }
        }

        public string Name
        {
            get { return "addrep"; }
        }

        public string Syntax
        {
            get { return "<player> <rep>"; }
        }

        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public AllowedCaller AllowedCaller
        {
            get { return AllowedCaller.Both; }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string>() { "reputation.add" };
            }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {

            UnturnedPlayer player = (UnturnedPlayer)caller;
            UnturnedPlayer victim = UnturnedPlayer.FromName(command[0]);
            string x = command[1];
            int rep = Int32.Parse(x);

            if (victim.Player.skills.reputation < 0)
            {
                victim.Player.skills.askRep(victim.Player.skills.reputation);
                victim.Player.skills.askRep(rep);
                Rocket.Core.Logging.Logger.Log(victim.CharacterName + " reputation has been added: " + x);
            }
            else
            {
                victim.Player.skills.askRep(-victim.Player.skills.reputation);
                victim.Player.skills.askRep(rep);
                Rocket.Core.Logging.Logger.Log(victim.CharacterName + " reputation has been added: " + x);
            }
        }
    }
}