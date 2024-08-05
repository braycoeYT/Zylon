using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Armor
{
    public class ShadowstitchedBlitz : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
            player.manaCost -= 0.42f;
            player.GetCritChance(DamageClass.Magic) += 10;
            player.GetModPlayer<ZylonPlayer>().shadowflameMagic = true;
            if (player.buffTime[buffIndex] < 2)
                player.AddBuff(ModContent.BuffType<ShadowstitchedBlitzCooldown>(), 2400);
        }
    }
}