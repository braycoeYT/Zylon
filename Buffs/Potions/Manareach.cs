using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Potions
{
    public class Manareach : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Manareach");
            // Description.SetDefault("Increases mana star pickup range");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.manaMagnet = true;
        }
    }
}