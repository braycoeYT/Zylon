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
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
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
			Projectile.damage = (int)(Projectile.damage*0.8f);
			if (Projectile.damage < 1) Projectile.damage = 1;
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
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
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
            SpriteEffects spriteEffects = SpriteEffects.None;

            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
				Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, spriteEffects, 0);
            }
			Main.spriteBatch.Draw(projectileTexture, drawPos, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0f);
            return false;
        }
    }   
}