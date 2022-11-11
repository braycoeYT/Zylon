using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
	public class SevereBleeding : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Severe Bleeding");
			Description.SetDefault("It's getting everywhere!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
		}
		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ZylonPlayer>().severeBleeding = true;
		}
		bool safe = true;
        Color safeColor;
		public override void Update(NPC npc, ref int buffIndex) {
            if (safe) {
                safeColor = npc.color;
                safe = false;
            }
			npc.GetGlobalNPC<NPCs.ZylonGlobalNPC>().severeBleeding = true;
            npc.color = Color.Red;
            if (npc.buffTime[buffIndex] < 5) {
				npc.color = safeColor;
				npc.GetGlobalNPC<NPCs.ZylonGlobalNPC>().severeBleeding = false;
			}
			if (npc.buffTime[buffIndex] > 180)
                npc.buffTime[buffIndex] = 180;
		}
		/*public override bool ReApply(Player player, int time, int buffIndex) {
			return true;
		}
		public override bool ReApply(NPC npc, int time, int buffIndex) {
			return true;
		}*/
	}
}