using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
    public class BrokenCode : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
        }
        public override void Update(NPC npc, ref int buffIndex) {
            if (!npc.boss) npc.Center += new Vector2(Main.rand.Next(-2, 3), Main.rand.Next(-2, 3));
            npc.GetGlobalNPC<NPCs.ZylonGlobalNPCDebuff>().brokenCode = true;
        }
    }
}