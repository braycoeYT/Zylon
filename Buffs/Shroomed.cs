using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class Shroomed : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Shroomed");
            Description.SetDefault("You have been infected by bioluminescent fungi");
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ZylonPlayer>().shroomed = true;
            player.confused = true;
		}
        bool safe = true;
        Color safeColor;
  		public override void Update(NPC npc, ref int buffIndex) {
            if (safe) {
                safeColor = npc.color;
                safe = false;
            }
			npc.GetGlobalNPC<NPCs.ZylonGlobalNPC>().shroomed = true;
            npc.color = Color.DarkBlue;
            if (npc.buffTime[buffIndex] < 5)
                npc.color = safeColor;
            if (!npc.buffImmune[BuffID.Confused])
                npc.confused = true;
		}
    }
}