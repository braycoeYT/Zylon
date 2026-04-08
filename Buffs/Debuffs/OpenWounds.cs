using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
    public class OpenWounds : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
  		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCs.ZylonGlobalNPCDebuff>().openWounds = true;
            for (int i = 0; i < 3; i++) if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Blood, Main.rand.NextFloat(-1.25f, 1.25f), Main.rand.NextFloat(-1.5f, 0f));
				dust.noGravity = true;
				dust.scale = Main.rand.NextFloat(0.5f, 1.5f);
			}
		}
        public override void Update(Player player, ref int buffIndex) {
            player.GetModPlayer<ZylonPlayer>().openWounds = true;
            for (int i = 0; i < 3; i++) if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.Blood, Main.rand.NextFloat(-1.25f, 1.25f), Main.rand.NextFloat(-1.5f, 0f));
				dust.noGravity = true;
				dust.scale = Main.rand.NextFloat(0.5f, 1.5f);
			}
        }
    }
}