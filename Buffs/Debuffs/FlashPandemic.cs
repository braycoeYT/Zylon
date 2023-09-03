using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
    public class FlashPandemic : ModBuff
    {
        public override void SetStaticDefaults() {
            // Description.SetDefault("The plague is upon you");
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
  		public override void Update(NPC npc, ref int buffIndex) {
            if (npc.buffTime[buffIndex] <= 16) return;
			npc.GetGlobalNPC<NPCs.ZylonGlobalNPCDebuff>().flashPandemic = true;
            for (int i = 0; i < 2; i++) {
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.FlashPandemicDust>());
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
            }
		}
    }
}