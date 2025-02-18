using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.Audio;
using Zylon.Projectiles.Whips;
using Terraria.ModLoader.Config;

namespace Zylon.Projectiles.Swords
{
	public class SurgeonScissorsProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 80;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 8;
			Projectile.extraUpdates = 3;
		}
		public override void OnSpawn(IEntitySource source) {
            SoundEngine.PlaySound(SoundID.Item71.WithPitchOffset(1f).WithVolumeScale(0.75f), Projectile.position);
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
            modifiers.HitDirectionOverride = (int)Projectile.ai[0];
        }
        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers) {
            modifiers.HitDirectionOverride = (int)Projectile.ai[0];
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BleedingEnemy>(), Main.rand.Next(8, 13)*60);
			Projectile.damage = (int)(Projectile.damage*0.75f);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) target.AddBuff(BuffID.Bleeding, Main.rand.Next(8, 13)*60);
			Projectile.damage = (int)(Projectile.damage*0.75f);
        }
        public override void AI() {
			if (Projectile.timeLeft <= 20) {
				Projectile.velocity = Vector2.Zero;
				Projectile.friendly = false;
			}
		}
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                
				//Does not draw if at end point.
				if (Projectile.timeLeft <= 20 && Projectile.oldPos[k] == Projectile.position) continue;

				if ((k+Projectile.timeLeft) % 8 < 4) Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, Color.White, 0f, drawOrigin, 1f, SpriteEffects.None, 0);
            }
            //if (Projectile.timeLeft > 20) Main.spriteBatch.Draw(projectileTexture, drawPos, null, Color.White, 0f, drawOrigin, 1f, SpriteEffects.None, 0f);
            return false;
        }
	}   
}