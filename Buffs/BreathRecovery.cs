using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class BreathRecovery : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Breath Recovery");
            Description.SetDefault("All this blowing takes a while to recover from!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            if (player.HasBuff(ModContent.BuffType<OutofBreath>()) || player.breath == player.breathMax)
				player.buffTime[buffIndex] = 0;
            else
                player.buffTime[buffIndex] = 60;
            int loss = 2;
            if (Main.GameUpdateCount % 3 == 0) loss = 3;
            if (!player.wet)
            player.breath -= loss;
        }
    }
}