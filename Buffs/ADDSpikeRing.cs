using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Buffs
{
	public class ADDSpikeRing : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Spike Ring");
			// Description.SetDefault("The spike ring will push enemies away from you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.ADDExpert) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}