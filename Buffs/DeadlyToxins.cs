using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class DeadlyToxins : ModBuff
    {
        public override void SetStaticDefaults() {
            Description.SetDefault("Deadly toxins are rapidly draining your life!");
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ZylonPlayer>().deadlyToxins = true;
		}
        bool safe = true;
        Color safeColor;
  		public override void Update(NPC npc, ref int buffIndex) {
            if (safe) {
                safeColor = npc.color;
                safe = false;
            }
			npc.GetGlobalNPC<NPCs.ZylonGlobalNPC>().deadlyToxins = true;
            npc.color = Color.Purple;
            if (npc.buffTime[buffIndex] < 5)
                npc.color = safeColor;
		}
    }
}