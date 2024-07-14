using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Accessories
{
	public class Possessed : ModBuff
	{
		public override void SetStaticDefaults() {
			Main.buffNoSave[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			
			//for (int i = 0; i < 2; i++) {
			    Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.DungeonSpirit);
			   	dust.noGravity = false;
			    dust.scale = 1.5f;
			//}
		}
	}
}