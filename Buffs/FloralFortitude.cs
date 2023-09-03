using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class FloralFortitude : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Floral Fortitude");
            // Description.SetDefault("Increases your defense by 8");
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;
            Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = false;
            Main.buffDoubleApply[Type] = false;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.statDefense += 8;
		}
    }
}