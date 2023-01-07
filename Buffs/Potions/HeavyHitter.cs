using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Potions
{
    public class HeavyHitter : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Heavy Hitter");
            Description.SetDefault("Critical strike damage increased by 20%");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
            p.critExtraDmg += 0.2f;
        }
    }
}