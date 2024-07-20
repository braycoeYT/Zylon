using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Zylon.NPCs;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.ID;

namespace Zylon.Projectiles.Bosses.SaburRex
{
	public class SaburRexBoneProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 0;
		}
		float spin;
		float hpLeft;
		int badTimer;
        public override void AI() {
			NPC owner = Main.npc[ZylonGlobalNPC.saburBoss];
			if (owner.life < 2 || !owner.active) Projectile.Kill();
			if (owner.ai[0] != 1f) {
				badTimer++;
				Projectile.netUpdate = true;
				if (badTimer > 20) Projectile.Kill();
			}
			else badTimer = 0;
			hpLeft = (float)owner.life/(float)owner.lifeMax;
			spin += MathHelper.ToRadians(0.33f)-MathHelper.ToRadians(0.2f*hpLeft);
			if (spin > MathHelper.ToRadians(15f)) {
				//At max spin, head in the player's direction.
				spin = MathHelper.ToRadians(15f);
				if (Projectile.velocity == Vector2.Zero) Projectile.velocity = Projectile.DirectionTo(Main.player[owner.target].Center + new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101)));
				if (Projectile.velocity.Length() < 8f) Projectile.velocity *= 1.25f-(0.15f*hpLeft);

				if (Projectile.timeLeft > 180) Projectile.timeLeft = 180; //Stop lasting forever.
			}
			Projectile.rotation += spin;
		}
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 6; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Bone);
				dust.noGravity = true;
				dust.scale = 1.5f;
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