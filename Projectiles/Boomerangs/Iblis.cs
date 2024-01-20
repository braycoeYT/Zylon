using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Boomerangs
{
	public class Iblis : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 50;
			Projectile.height = 50;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.extraUpdates = 1;
			Projectile.scale = 0.75f;
		}
		public override void AI() {
			Projectile.ai[0]++;
			Projectile.rotation += 0.1f;
			if (Projectile.ai[0] > 48) {
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < 60) Projectile.Kill();
				speed.Normalize();
				Projectile.velocity = speed*-11.5f;
			}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, Main.rand.Next(5, 8) * 60);
			if (Main.rand.NextBool(4)) target.AddBuff(BuffID.Confused, Main.rand.Next(10, 15) * 60);
			if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Iblis_Stick>(), Projectile.damage, Projectile.knockBack, Projectile.owner, target.whoAmI, Projectile.rotation, 0f);
			Projectile.Kill();
		}
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) {
				target.AddBuff(BuffID.OnFire, Main.rand.Next(5, 8) * 60);
				if (Main.rand.NextBool(4)) target.AddBuff(BuffID.Confused, Main.rand.Next(10, 15) * 60);
				if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Iblis_Stick>(), Projectile.damage, Projectile.knockBack, Projectile.owner, target.whoAmI, Projectile.rotation, 1f);
				Projectile.Kill();
			}
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			/*if (Projectile.ai[0] <= 48) {
				hitCount++;
				Projectile.velocity = -oldVelocity;
				if (Projectile.ai[0] > 20 || hitCount >= 3) Projectile.ai[0] = 48;
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			}*/
			if (Main.myPlayer == Projectile.owner) for (int x = 0; x < 5; x++) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-20f, -12f)), ModContent.ProjectileType<Iblis_Rock>(), (int)(Projectile.damage*0.6f), Projectile.knockBack*0.4f, Projectile.owner);
			SoundEngine.PlaySound(SoundID.Item69, Projectile.position);
			Projectile.Kill();
            return false;
        }
		public override void PostAI() {
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
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
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
    }   
}