using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Tomes
{
	public class FahrenheitProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 38;
			Projectile.height = 38;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.timeLeft = 60;
			Projectile.ignoreWater = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
		float lightAlpha;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, Main.rand.Next(4, 10)*60);
            if (Projectile.ai[0] == 1f) Projectile.damage = (int)(Projectile.damage*0.6f);
        }
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP) {
				target.AddBuff(BuffID.OnFire, Main.rand.Next(4, 10)*60);
			}
        }
        public override void AI() {
			if (Projectile.ai[0] == 0f) Projectile.velocity *= 1.03f;
			else {
				Projectile.penetrate = -1;
				Projectile.tileCollide = false;
				Projectile.velocity *= 0.94f;
				//if (Projectile.timeLeft > 60) Projectile.timeLeft = 60;
			}
			
            int count1 = (int)Main.GameUpdateCount % 15;
			int count2 = (int)Main.GameUpdateCount % 30;
			if (count2 > 14) lightAlpha = 1f - count1/15f;
			else lightAlpha = count1/15f;
        }
        public override void PostAI() {
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
		}
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 5; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch);
				dust.noGravity = true;
				dust.scale = Main.rand.NextFloat(1f, 1.5f);
				dust.velocity = new Vector2(0, -8).RotatedByRandom(MathHelper.TwoPi)*dust.scale;
			}
			if (Projectile.owner == Main.myPlayer && Projectile.ai[0] == 0f) {
				float rand = Main.rand.NextFloat(MathHelper.TwoPi);
				for (int i = 0; i < 6; i++) {
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(25, 0).RotatedBy(MathHelper.ToRadians(i*60)+rand), ModContent.ProjectileType<FahrenheitProj>(), (int)(Projectile.damage*0.66f), Projectile.knockBack/2, Projectile.owner, 1f);
				}
			}
			else if (Projectile.owner == Main.myPlayer) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<FahrenheitFlame>(), (int)(Projectile.damage*0.75f), Projectile.knockBack/3, Main.myPlayer);
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D altTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/FahrenheitProj_Light");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 drawOrigin = new Vector2(texture.Width / 2f, frameHeight / 2f);

			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(altTexture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*lightAlpha, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}