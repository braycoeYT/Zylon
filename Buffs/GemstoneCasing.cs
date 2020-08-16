using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class GemstoneCasing : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Gemstone Casing");
            Description.SetDefault("Greatly increases life regen, defense, and attack");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 3;
            player.statDefense += 25;
            player.allDamage += 0.15f;
        }
    }
}