using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Microbiome
{
	public class InfectedDart : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Infected Dart");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(mod.BuffType("Sick"), 60 * Main.rand.Next(3, 7), false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(mod.BuffType("Sick"), 60 * Main.rand.Next(3, 7), false);
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++) {
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
		int Timer;
		public override void AI()
		{
			Timer++;
			if (Timer % 30 == 0)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 0), mod.ProjectileType("InfectedDartTrail"), projectile.damage, projectile.knockBack / 2, Main.myPlayer);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}