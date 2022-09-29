using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Potions
{
    public class BloodiedVial : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bloodied Vial");
            Description.SetDefault("Small chance to lifesteal from enemies");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
            p.bloodVial = true;
        }
    }
}