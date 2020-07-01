using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class CellBoost : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("ATP Boost");
            Description.SetDefault("The hypercharged nucleolus increases your ATP, which increases your life regen greatly");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 1;
        }
    }
}