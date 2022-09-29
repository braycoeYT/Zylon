using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class DiskiteOffense : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Diskbringer: Offense");
            Description.SetDefault("Increases your damage by 10%, critical strike chance by 5, and weapon speed by 8%");
            Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = false;
            Main.buffDoubleApply[Type] = false;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.GetDamage(DamageClass.Generic) += 0.1f;
            player.GetCritChance(DamageClass.Generic) += 5;
            player.GetAttackSpeed(DamageClass.Generic) += 0.08f;
		}
    }
}