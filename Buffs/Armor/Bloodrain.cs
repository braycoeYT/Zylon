using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Armor
{
    public class Bloodrain : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
            player.GetModPlayer<ZylonPlayer>().bloodrain = true;
            if (player.buffTime[buffIndex] < 2)
                player.AddBuff(ModContent.BuffType<BloodrainCooldown>(), 2700);
        }
    }
}