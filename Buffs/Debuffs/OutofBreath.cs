using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
    public class OutofBreath : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Out of Breath");
            Description.SetDefault("You can't breathe!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            if (player.wet)
            player.breath -= 1;
            else
            if (Main.GameUpdateCount % 2 == 0)
            player.breath -= 3;
            else
            player.breath -= 4;
            if (player.breath <= 0) {
                player.breath = 0;
                player.GetModPlayer<ZylonPlayer>().outofBreath = true;
            }
            if (player.buffTime[buffIndex] < 2)
                player.AddBuff(ModContent.BuffType<BreathRecovery>(), 60);
        }
    }
}