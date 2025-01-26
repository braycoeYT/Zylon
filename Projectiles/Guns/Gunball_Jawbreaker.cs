using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;
using Terraria.Audio;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zylon.Projectiles.Guns
{
	public class Gunball_Jawbreaker : ModProjectile
	{
        public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}
		public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 600;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 0;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (!target.boss && target.type != NPCID.GolemHead && target.type != NPCID.SkeletronHand) {
				if (colorBall == 0) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.GunballRed>(), Main.rand.Next(4, 8)*60);
				else if (colorBall == 1) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.GunballBlue>(), Main.rand.Next(4, 8)*60);
				else target.AddBuff(ModContent.BuffType<Buffs.Debuffs.GunballGreen>(), Main.rand.Next(4, 8)*60);
			}
			Projectile.timeLeft = 3;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP) {
				if (colorBall == 0) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.GunballRed>(), Main.rand.Next(7, 11)*60);
				else if (colorBall == 1) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.GunballBlue>(), Main.rand.Next(7, 11)*60);
				else target.AddBuff(ModContent.BuffType<Buffs.Debuffs.GunballGreen>(), Main.rand.Next(7, 11)*60);
			}
			Projectile.timeLeft = 3;
        }
		int colorBall;
		bool init;
        public override void AI() {
			if (Projectile.timeLeft == 2) {
				Projectile.width = 100;
				Projectile.height = 100;
				Projectile.usesLocalNPCImmunity = true;
				Projectile.localNPCHitCooldown = 30;
			}
			if (!init) {
				colorBall = Main.rand.Next(3);
				init = true;

				Projectile.timeLeft = Main.rand.Next(20, 36);
			}
            Projectile.rotation += 0.1f;
        }
        public override void OnKill(int timeLeft) {
			int dustType = DustID.RedTorch;
			if (colorBall == 1) dustType = DustID.BlueTorch;
			else if (colorBall == 2) dustType = DustID.GreenTorch;

			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			for (int i = 0; i < 15; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width/4, Projectile.height/4, DustID.Smoke, 0f, 0f, 100, default(Color), 2.5f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			/*for (int i = 0; i < 10; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width/4, Projectile.height/4, dustType, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width/4, Projectile.height/4, dustType, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[dustIndex].velocity *= 3f;
			}*/

			float rand = Main.rand.NextFloat(MathHelper.TwoPi);
			for (int i = 0; i < 6; i++) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 17).RotatedBy(rand+MathHelper.ToRadians(i*60)), ModContent.ProjectileType<Gunball_Proj>(), Projectile.damage/2, Projectile.knockBack/2, Projectile.owner, colorBall+1f);
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.Red;
            if (colorBall == 1f) color = Color.Blue;
            else if (colorBall == 2f) color = Color.Green;

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
                float AfterAffectScale = ((Projectile.scale - k / (float)Projectile.oldPos.Length / 3) * (k / 8f)) + Projectile.scale;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, AfterAffectScale, SpriteEffects.None, 0);
            }

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
	}   
}