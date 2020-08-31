using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Buffs.Minions
{
	public class Ubercabochon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Ubercabochon");
			Description.SetDefault("The Ubercabochon will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.gemstoneSummon)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Gemstone.Ubercabochon>()] < 1)
			{
				Projectile.NewProjectile(player.Center, new Vector2(0, 0), mod.ProjectileType("Ubercabochon"), 360, 3f, Main.myPlayer);
			}
		}
	}
}