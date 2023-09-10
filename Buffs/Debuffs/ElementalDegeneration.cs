using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
    public class ElementalDegeneration : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Elemental Degeneration");
            // Description.SetDefault("Burning, freezing, dizziness, weakness... you feel it all!");
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ZylonPlayer>().elemDegen = true;
            if (!player.buffImmune[BuffID.Confused]) player.confused = true;
            player.statDefense *= 0.8f;
            if (Main.rand.NextBool(3)) {
				Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, ModContent.DustType<Dusts.ElemDust>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
				dust.noGravity = true;
			}
		}
  		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCs.ZylonGlobalNPCDebuff>().elemDegen = true;
            //if (!npc.buffImmune[BuffID.Confused])
            //    npc.confused = true;
            npc.defense = (int)(npc.defense*0.8f);
            if (Main.rand.NextBool(3)) {
				Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.ElemDust>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
				dust.noGravity = true;
			}
		}
    }
}