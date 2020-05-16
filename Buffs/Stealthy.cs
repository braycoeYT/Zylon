using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class Stealthy : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stealthy");
            Description.SetDefault("Increased movement speed, throwing damage, and you have a chance to dodge attacks");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.thrownDamage += 0.07f;
			player.maxRunSpeed += 0.07f;
			player.blackBelt = true;
        }
    }
}