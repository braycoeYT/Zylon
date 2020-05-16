using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class Floater : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Floater");
            Description.SetDefault("Increased max wingtime");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.wingTimeMax += 60;
        }
    }
}