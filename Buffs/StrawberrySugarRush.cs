using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class StrawberrySugarRush : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Strawberry Sugar Rush");
            Description.SetDefault("Increased max minions and wing time");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.endurance += 0.05f;
			player.wingTimeMax += 30;
        }
    }
}