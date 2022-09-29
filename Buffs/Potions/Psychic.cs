using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Potions
{
    public class Psychic : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Psychic");
            Description.SetDefault("You are focused on your psychic ability");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.statLifeMax2 = (int)(player.statLifeMax2 * 0.95f);
            player.manaRegen += 5;
        }
    }
}