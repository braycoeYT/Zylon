using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class EyeCandy : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Eye Candy");
            Description.SetDefault("Who reads the wrapper anyway?\nMana cost is halved");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.manaCost -= 0.5f;
        }
    }
}