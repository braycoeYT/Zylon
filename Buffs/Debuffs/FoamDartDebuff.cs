using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
	public class FoamDartDebuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Defense Nerf");
			// Description.SetDefault("Defense is decreased by 15");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
		}
		public override void Update(Player player, ref int buffIndex) {
			player.statDefense -= 15;
		}
		public override void Update(NPC npc, ref int buffIndex) {
			npc.defense -= 15;
		}
	}
}