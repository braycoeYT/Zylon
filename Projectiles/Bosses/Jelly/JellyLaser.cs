using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Bosses.Jelly
{
	public class JellyLaser : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Water Blast");
		}
		public override void SetDefaults() {
			Projectile.CloneDefaults(83);
			Projectile.aiStyle = 1;
			AIType = ProjectileID.GreenLaser;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 240;
		}
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI) {
            behindNPCs.Add(index);
        }
	}
}