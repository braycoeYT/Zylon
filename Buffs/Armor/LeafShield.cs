using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Armor
{
    public class LeafShield : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            if (player.statLife != player.statLifeMax)
				player.buffTime[buffIndex] = 0;
            else
                player.buffTime[buffIndex] = 60;
            player.statDefense += 10;
            player.GetDamage(DamageClass.Generic) += 0.12f;
        }
    }
}