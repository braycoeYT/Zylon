using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Potions
{
    public class Gale : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Gale's Blessing");
            // Description.SetDefault("You have been blessed by the winds!");
            Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = false;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ZylonPlayer>().blowpipeMaxInc += 30;
            player.GetModPlayer<ZylonPlayer>().blowpipeChargeInc += 0.333333333f;
		}
    }
}