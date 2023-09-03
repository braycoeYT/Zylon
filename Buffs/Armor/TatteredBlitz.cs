using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Armor
{
    public class TatteredBlitz : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Tattered Blitz");
            // Description.SetDefault("Mana usage is reduced by 33%");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            player.manaCost -= 0.33f;
            if (player.buffTime[buffIndex] < 2)
                player.AddBuff(ModContent.BuffType<TatteredBlitzCooldown>(), 1800);
        }
    }
}