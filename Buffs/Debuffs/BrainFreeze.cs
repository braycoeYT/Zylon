using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
    public class BrainFreeze : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Brain Freeze");
            // Description.SetDefault("A terrible headache, but cold");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            player.velocity *= 0.93f;
        }
        public override void Update(NPC npc, ref int buffIndex) {
            npc.GetGlobalNPC<NPCs.ZylonGlobalNPCDebuff>().brainFreeze = true;
        }
    }
}