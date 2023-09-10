using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Buffs.Minions
{
	public class DirtBlock : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Dirt Block Army");
			// Description.SetDefault("The Dirt Block Army will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.DirtBlockExp>()] > 0 && player.GetModPlayer<ZylonPlayer>().dirtballExpert){
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}