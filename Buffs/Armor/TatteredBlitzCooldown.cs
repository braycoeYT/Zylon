using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Armor
{
    public class TatteredBlitzCooldown : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Tattered Blitz Cooldown");
            // Description.SetDefault("You can't use tattered blitz right now!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
    }
}