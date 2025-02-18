using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
    public class BleedingEnemy : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
  		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCs.ZylonGlobalNPCDebuff>().bleeding = true;
            if (Main.rand.NextBool()) {
                int dustType = DustID.Blood;
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1.1f + Main.rand.Next(-30, 31) * 0.01f;
            }
		}
    }
}