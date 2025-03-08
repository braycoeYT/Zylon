using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
    public class PotionFatigue : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
		}
    }
}