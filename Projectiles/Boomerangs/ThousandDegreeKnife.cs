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
	public class ThousandDegreeKnife : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
			Projectile.usesLocalNPCImmunity = false;
			Projectile.localNPCHitCooldown = 10;
			Projectile.rotation = Main.rand.NextFloat(MathHelper.TwoPi);
		}
		int Timer;
		float speedAcc;
		float burn = 1f;
		bool goBack;
		bool stick;
		NPC stickTarget;
		Vector2 safe;
		bool canStick = true;
		public override void AI() {
			Timer++;

			if (Timer > 25 && burn > 0f) burn -= 0.05f;

			if (stick && burn > 0f) {
				if (burn > 0.20f) {
					Projectile.usesLocalNPCImmunity = true;
					Projectile.localNPCHitCooldown = 5;
				}
				else {
					Projectile.usesLocalNPCImmunity = false;
					Projectile.localNPCHitCooldown = 10;
				}
				Projectile.width = 60;
				Projectile.height = 60;
				Projectile.Center = stickTarget.Center - safe;
				if (!stickTarget.active) burn = 0f;
				return;
			}
			if (!canStick) goBack = true; //Please go back, sticking complete
			Projectile.usesLocalNPCImmunity = false;
			Projectile.localNPCHitCooldown = 10;
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.tileCollide = true;

			Projectile.rotation += 0.1f;

			if (Projectile.ai[0] > 48) {
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < 60) Projectile.Kill();
				speed.Normalize();
				Projectile.velocity = speed*-10.5f;
			}
			if (Timer >= 40 || goBack) {
				Projectile.ai[0] = 1f; //Allows boomerang to be rethrown while still active
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.05f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-15f*speedAcc;
			}
			else if (Timer >= 25) Projectile.velocity *= 0.95f;
		}
        /*public override bool? CanHitNPC(NPC target) { //DON'T USE, EXTREMELY BUGGY
            if (stick)
				return stickTarget.whoAmI == target.whoAmI;
			return true;
        }*/
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
			if (stick && burn > 0f) { modifiers.FinalDamage *= 0.1f; modifiers.DisableKnockback(); }
            modifiers.Knockback += 3f*burn;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			if (stick) {
				if (Main.rand.NextFloat() < burn) target.AddBuff(BuffID.OnFire, 60);
				return;
			}

			if (Main.rand.NextFloat() < burn) target.AddBuff(BuffID.OnFire, Main.rand.Next(10, 16) * 60);
			Projectile.damage = (int)(Projectile.damage*0.7f);
			if (Projectile.damage < 1) Projectile.damage = 1;

			if (canStick && burn > 0f) { //Don't stick if there is no burn.
				stick = true;
				safe = target.Center - Projectile.Center;
				stickTarget = target;
				canStick = false; //Can't stick twice.
				Projectile.rotation = (Projectile.Center-target.Center).ToRotation() + MathHelper.Pi + MathHelper.PiOver4;
				Projectile.tileCollide = false;
			}
		}
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) {
				if (Main.rand.NextFloat() < burn) target.AddBuff(BuffID.OnFire, Main.rand.Next(9, 13) * 60);
			}
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			if (Timer <= 48) {
				Projectile.velocity = -oldVelocity;
				if (Timer > 20) Timer = 48;
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			}
			if (burn > 0.5f) SoundEngine.PlaySound(SoundID.Item69, Projectile.position);
            return false;
        }
		public override void PostAI() {
            for (int i = 0; i < 2; i++) if (Main.rand.NextFloat() < burn) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.FlameBurst);
				dust.noGravity = true;
				dust.scale = 1.5f*burn;
				if (stick) dust.velocity = new Vector2(0, -12*burn).RotatedBy(MathHelper.PiOver2+Projectile.rotation);
				else dust.velocity = new Vector2(0, -12*burn).RotatedBy(MathHelper.PiOver2+Projectile.rotation) + Projectile.velocity;
			}
        }
		public override bool PreDraw(ref Color lightColor) {
            SpriteEffects spriteEffects = SpriteEffects.None;

            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Boomerangs/ThousandDegreeKnife_Glow");
			Color glowColor = Color.White*burn;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

			Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0f);
			Main.spriteBatch.Draw(glow, drawPos, null, glowColor, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0f);
            return false;
        }
    }   
}