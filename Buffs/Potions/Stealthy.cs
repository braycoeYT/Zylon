using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Potions
{
    public class Stealthy : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Stealthy");
            Description.SetDefault("Gives a small chance to dodge attacks");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
            p.stealthPotion = true;
        }
    }
}