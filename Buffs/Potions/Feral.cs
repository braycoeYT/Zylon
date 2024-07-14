using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Potions
{
    public class Feral : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Feral");
            // Description.SetDefault("Melee speed increased by 10%");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
            float hpRatio = player.statLife/player.statLifeMax2;
			player.GetAttackSpeed(DamageClass.Generic) += 0.1f-0.1f*hpRatio;
        }
    }
}