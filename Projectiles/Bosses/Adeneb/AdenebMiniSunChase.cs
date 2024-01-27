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
	public class AdenebMiniSunChase : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 52;
			Projectile.height = 52;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 240;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		NPC owner;
		int Timer;
		Vector2 rand;
        public override void AI() {
			owner = Main.npc[ZylonGlobalNPC.adenebBoss];
			Timer++;
			Projectile.rotation += MathHelper.ToRadians(5);

			if (Timer < 60) {
				Projectile.velocity *= 0.94f;
            }
			else if (Timer == 60) {
				rand = Main.player[owner.target].Center + new Vector2(Main.rand.Next(-150, 151), Main.rand.Next(-150, 151));
            }
			else if (Timer < 75) {
				Projectile.velocity += Vector2.Normalize(Projectile.Center - rand) * -0.2f;
            }
			else if (Timer < 140) Projectile.velocity *= 1.03f; //1.04 og
        }
        public override void OnSpawn(IEntitySource source) {
			SoundEngine.PlaySound(SoundID.NPCHit5, Projectile.position);
        }
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
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