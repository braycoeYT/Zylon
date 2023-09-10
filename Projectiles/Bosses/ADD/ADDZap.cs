using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class ADDZap : ModProjectile
	{
        public override void SetStaticDefaults() { //SCRAPPED ATTACK
			// DisplayName.SetDefault("Electric Orb");
        }
		public override void SetDefaults() {
			Projectile.width = 36;
			Projectile.height = 36;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 600;
			Projectile.scale = 1.5f;
			Projectile.tileCollide = false;
		}
        public override void AI() {
            if (Projectile.Center.Y < Main.player[Main.npc[ZylonGlobalNPC.diskiteBoss].target].Center.Y && Projectile.alpha == 0) {
				//Projectile.NewProjectile();
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)	{
			target.AddBuff(BuffID.Electrified, Main.rand.Next(1, 4)*60);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}