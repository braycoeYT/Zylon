using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class Archived : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Archived");
            Description.SetDefault("Your soul has been archived into a virtual database");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.endurance += 0.25f;
        }
    }
}