using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Accessories
{
    public class ManaRechargeCooldown : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
    }
}