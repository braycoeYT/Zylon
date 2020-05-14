using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class SugarRush : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sugar Rush");
            Description.SetDefault("Increased max health and max run speed");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.statLifeMax2 += player.statLifeMax2 / 10;
			player.maxRunSpeed += 0.2f;
        }
    }
}