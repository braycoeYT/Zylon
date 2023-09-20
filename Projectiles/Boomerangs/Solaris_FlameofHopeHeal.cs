using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Boomerangs
{
	public class Solaris_FlameofHopeHeal : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.width = 28;
			Projectile.height = 52;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 360;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 5;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.Daybreak, Main.rand.Next(5, 11)*60);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP) target.AddBuff(BuffID.Daybreak, Main.rand.Next(5, 11)*60);
        }
        Vector2 spawn;
		int Timer;
		float dist;
        public override void AI() {
			if (++Projectile.frameCounter >= 5) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
					Projectile.frame = 0;
			}
			Projectile.velocity = Vector2.Zero;
			if (Timer == 0) spawn = Projectile.Center;
			Timer++;
			dist += 1.5f;
			Projectile.Center = spawn - new Vector2(0, dist).RotatedBy(MathHelper.ToRadians((Timer)+Projectile.ai[0]*45));
			if (Projectile.timeLeft < 28)
				Projectile.alpha += 10;
			Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
			if (Math.Abs(speed.X)+Math.Abs(speed.Y) < 65) {
				Projectile.Kill();
				Main.player[Projectile.owner].Heal(Main.rand.Next(2, 5));
			}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch);
				dust.noGravity = true;
				dust.scale = 0.75f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			if (Projectile.timeLeft >= 28)Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), 2f, effects, 0);
			return false;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}