using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class WingsBadToolsContagion : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Wingshattering Gaze");
            Description.SetDefault("Infinite flight is disabled, and max flight time is decreased by 50%");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.wingTimeMax > 1000 || player.wingTimeMax < 0)
                player.wingTimeMax = 1000;
            player.wingTimeMax = (int)(player.wingTimeMax * 0.5f);
        }
    }
}