using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;
using Terraria.ID;

namespace Zylon.Projectiles.Accessories
{
	public class TribalCharmProjSpin : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.alpha = 255;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 20;
		}
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
            if (target.Center.X < Main.player[Projectile.owner].Center.X) modifiers.HitDirectionOverride = -1;
            else modifiers.HitDirectionOverride = 1;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Venom, Main.rand.Next(3, 8)*60);
            die = true;
        }
        Projectile main;
		bool die;
		int dieTimer;
        public override void AI() {
			Projectile.netUpdate = true;
			main = Main.projectile[(int)Projectile.ai[1]];
			float offset = (float)Math.Sin(Main.GameUpdateCount/25f)*5f;
			Projectile.Center = main.Center - new Vector2(0, 20+offset+(Projectile.width+Projectile.height)/2).RotatedBy(MathHelper.ToRadians(Main.GameUpdateCount*1.5f+Projectile.ai[0]*120));
			Projectile.rotation = MathHelper.ToRadians(Main.GameUpdateCount*1.5f+Projectile.ai[0]*120);
			if (Projectile.alpha > 0 && !die) Projectile.alpha -= 17;
			else if (die) {
				Projectile.alpha += 17;
				if (Projectile.alpha >= 255) dieTimer++;
				if (dieTimer > 420) {
					dieTimer = 0;
					die = false;
				}
			}

			Projectile.friendly = Projectile.alpha <= 0;

			Projectile.timeLeft = 9999;
			Player owner = Main.player[Projectile.owner];
            ZylonPlayer p = owner.GetModPlayer<ZylonPlayer>();
			if (!p.tribalCharm || !main.active) Projectile.Kill();
        }
        public override void PostAI() { //This projectile doesn't know if its owner has been replaced by an impostor or not
            if (Projectile.ai[2] == 0f) Projectile.Kill();
			Projectile.ai[2] = 0f;
        }
        public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*((255f-Projectile.alpha)/255f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}