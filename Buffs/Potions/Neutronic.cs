using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Potions
{
    public class Neutronic : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Neutronic");
            // Description.SetDefault("Modifies your damage and defense based on your current health");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        int def;
        int dam;
        public override void Update(Player player, ref int buffIndex) {
            if (player.HasBuff(BuffID.Ironskin)) def = 1;
            else def = 2;
            if (player.HasBuff(BuffID.Wrath) || player.HasBuff(BuffID.Rage)) dam = 1;
            else dam = 2;
			if (player.statLife >= player.statLifeMax2 / 2) {
                player.statDefense -= 10;
                player.GetDamage(DamageClass.Generic) += 0.05f*dam;
            }
            else {
                player.statDefense += 5*def;
                player.GetDamage(DamageClass.Generic) -= 0.1f;
            }
        }
    }
}