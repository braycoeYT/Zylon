using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class Gale : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Gale's Blessing");
            Description.SetDefault("You have been blessed by the winds!");
            Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = false;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ZylonPlayer>().blowpipeMaxInc += 50;
            player.GetModPlayer<ZylonPlayer>().blowpipeChargeInc += 1f;
		}
    }
}