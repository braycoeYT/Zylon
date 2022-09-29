using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class NaturesPrayer : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Nature's Prayer");
            Description.SetDefault("'Nature cares for all'");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            if (player.statLife > player.statLifeMax2 / 4)
				player.buffTime[buffIndex] = 0;
            else
                player.buffTime[buffIndex] = 60;
            player.lifeRegen += 3;
        }
    }
}