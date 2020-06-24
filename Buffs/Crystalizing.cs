using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class Crystalizing : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Crystalizing");
            Description.SetDefault("Your body is freezing by the power of the crystals");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.velocity.Y += 1;
            player.statDefense += 30;
            player.allDamage /= 10;
            player.maxFallSpeed *= 10;
            player.maxRunSpeed /= 2;
            player.accRunSpeed /= 2;
        }
    }
}