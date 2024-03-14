using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Armor
{
    public class NaturesPrayer : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.buffNoTimeDisplay[Type] = true;
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