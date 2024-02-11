using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class CactirangOG : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
		}
		int Timer;
		float speedAcc;
		bool goBack;
		public override void AI() {
			Timer++;
			Projectile.rotation += 0.1f;
			if (Timer >= 40 || goBack) {
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.03f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-15f*speedAcc;
			}
			else if (Timer >= 25) Projectile.velocity *= 0.95f;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Vector2 SpawnLocation = target.Center;
				if (Main.rand.NextBool(2))
                {
					SpawnLocation += new Vector2(target.width * Main.rand.NextFloat(0.1f, 0.41f), 0);
                } else
                {
					SpawnLocation += new Vector2(-target.width * Main.rand.NextFloat(0.1f, 0.41f), 0);
				}

				if (Main.rand.NextBool(2))
				{
					SpawnLocation += new Vector2(0, target.height * Main.rand.NextFloat(0.1f, 0.41f));
				}
				else
				{
					SpawnLocation += new Vector2(0, -target.height * Main.rand.NextFloat(0.1f, 0.41f));
				}
            if (hit.Crit && Projectile.owner == Main.myPlayer) Projectile.NewProjectile(Projectile.GetSource_FromThis(), SpawnLocation, Vector2.Zero, ModContent.ProjectileType<CactirangPricklyPear>(), (int)(Projectile.damage * 0.45f) + (int)(target.defense * 0.5f), 0f, Projectile.owner, target.whoAmI, 0f);
			Projectile.damage = (int)(Projectile.damage*0.66f); //multihit penalty
			if (Projectile.damage < 1) Projectile.damage = 1;
		}
        public override bool OnTileCollide(Vector2 oldVelocity) {
			//goBack = true;
			Projectile.tileCollide = false;
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			Projectile.velocity *= 0.92f;
			return false;
        }
	}   
}