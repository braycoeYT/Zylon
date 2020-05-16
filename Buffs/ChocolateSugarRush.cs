using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class ChocolateSugarRush : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Chocolate Sugar Rush");
            Description.SetDefault("Increased max mana and magic cost");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.statManaMax2 += player.statManaMax2 / 10;
			player.manaCost -= 0.08f;
        }
    }
}