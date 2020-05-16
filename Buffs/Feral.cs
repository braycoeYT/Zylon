using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class Feral : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Feral");
            Description.SetDefault("+10% Melee Speed");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.meleeSpeed += 0.1f;
        }
    }
}