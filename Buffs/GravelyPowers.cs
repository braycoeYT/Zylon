using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class GravelyPowers : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Gravely Powers");
            // Description.SetDefault("'The powers of the dead radiate within you'");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            player.lifeRegen += 2;
        }
    }
}