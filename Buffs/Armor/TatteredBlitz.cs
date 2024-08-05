using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Armor
{
    public class TatteredBlitz : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
            player.manaCost -= 0.33f;
            if (player.buffTime[buffIndex] < 2)
                player.AddBuff(ModContent.BuffType<TatteredBlitzCooldown>(), 1800);
        }
    }
}