using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class XenicAcid : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Xenic Acid");
            Description.SetDefault("Your blood runs green. That can't be good.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        int hpHurt;
        public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ZylonPlayer>().xenicAcid = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCs.ZylonGlobalNPC>().xenicAcid = true;
		}
    }
}