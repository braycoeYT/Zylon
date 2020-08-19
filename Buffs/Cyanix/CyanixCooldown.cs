using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Cyanix
{
    public class CyanixCooldown : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Cyanix Cooldown");
            Description.SetDefault("No more drugs for you. Well, cyanix drugs.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
    }
}