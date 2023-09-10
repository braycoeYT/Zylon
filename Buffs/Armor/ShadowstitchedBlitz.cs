using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Armor
{
    public class ShadowstitchedBlitz : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Shadowstitched Blitz");
            // Description.SetDefault("Mana usage is reduced by 42%, magic attacks inflict shadowflame, and magic critical strike chance is increased by 10");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
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