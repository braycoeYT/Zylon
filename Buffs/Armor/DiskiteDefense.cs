using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Armor
{
    public class DiskiteDefense : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Diskbringer: Defense");
            // Description.SetDefault("Increases your defense by 10 and damage reduction by 5%");
            Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = false;
            Main.buffDoubleApply[Type] = false;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.statDefense += 10;
            player.endurance += 0.05f;
		}
    }
}