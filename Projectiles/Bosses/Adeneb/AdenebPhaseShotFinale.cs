using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.Adeneb
{
	public class AdenebPhaseShotFinale : ModProjectile
	{
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 72;
			Projectile.height = 72;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 7)*60);
        }
		bool init;
        public override void AI() {
			NPC owner = Main.npc[ZylonGlobalNPC.adenebBoss];
			/*if (!init) {
				Projectile.position = owner.Center + new Vector2(0, 600).RotatedBy(MathHelper.ToRadians(Projectile.ai[0]));
				init = true;
            }*/
			Projectile.alpha -= 20;
			if (Projectile.alpha < 180) Projectile.hostile = true;
			if (!owner.active || owner.life < 1) Projectile.Kill();

			Projectile.velocity = Projectile.Center - owner.Center;
			Projectile.velocity.Normalize();

			//if (Vector2.Distance(Projectile.Center, owner.Center) < 550 && Vector2.Distance(Projectile.Center, owner.Center) > 450) Projectile.velocity *= -3f;
			//else Projectile.velocity *= -12f;
			Projectile.velocity *= -12f;

			if (Main.expertMode) Projectile.velocity *= 1.03f;

			if (Vector2.Distance(Projectile.Center, owner.Center) < 30) Projectile.Kill();

			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
        public override void OnSpawn(IEntitySource source) {
			SoundEngine.PlaySound(SoundID.NPCHit5, Projectile.position);
        }
        public override void OnKill(int timeLeft) {
            for (int i = 0; i < (int)(3*Projectile.scale); i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 2.5f + Main.rand.Next(-30, 31) * 0.01f;
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