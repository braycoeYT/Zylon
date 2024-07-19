using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
    public class Ectoburn : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ZylonPlayer>().ectoburn = true;
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.DungeonSpirit, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
				dust.noGravity = true;
				dust.scale = 2.5f;
			}
		}
  		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCs.ZylonGlobalNPCDebuff>().ectoburn = true;
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.DungeonSpirit, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
				dust.noGravity = true;
				dust.scale = 2.5f;
			}
		}
    }
}