using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class SolChakram : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
		}
		int Timer;
		float speedAcc;
		bool goBack;
		bool done;
		public override void AI() {
			Timer++;
			Projectile.rotation += 0.12f;
			if (Timer >= 40 || goBack) {
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					for (int i = 0; i < 5; i++) {
						Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
						dust.noGravity = false;
						dust.scale = 2f;
					}
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.05f;
				if (speedAcc > 1f) speedAcc = 1f;
				//Projectile.velocity = speed*-15f*speedAcc;
				Projectile.Kill();
			}
			else if (Timer >= 25) Projectile.velocity *= 0.96f; //95
			if (Projectile.ai[0] == 1f) {
				Projectile.ai[1]++;
				if (Projectile.ai[1] > 14) Projectile.Kill();
            }
		}
        public override void PostAI() {
            if (Main.rand.NextBool(3)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				dust.noGravity = false;
				dust.scale = 1f;
			}
		}
        public override bool OnTileCollide(Vector2 oldVelocity) {
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
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(5, 9)*60);
			Projectile.ai[0] = 1f;
			Projectile.damage = (int)(Projectile.damage*0.5f); //multihit penalty
			if (Projectile.damage < 1) Projectile.damage = 1;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP) {
				target.AddBuff(BuffID.OnFire, Main.rand.Next(5, 9)*60);
			}
			Projectile.ai[0] = 1f;
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
        public override void Kill(int timeLeft) {
			Vector2 temp = Projectile.velocity;
			temp.Normalize();
			temp *= 8f;
			if (Main.myPlayer == Projectile.owner) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, temp.RotatedBy(MathHelper.ToRadians(90)), ModContent.ProjectileType<SolChakram_Mini>(), (int)(Projectile.originalDamage*0.75f), Projectile.knockBack*0.5f, Main.myPlayer);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, temp.RotatedBy(MathHelper.ToRadians(-90)), ModContent.ProjectileType<SolChakram_Mini>(), (int)(Projectile.originalDamage*0.75f), Projectile.knockBack*0.5f, Main.myPlayer);
			}
			SoundEngine.PlaySound(SoundID.Item9, Projectile.position);
		}
    }   
}