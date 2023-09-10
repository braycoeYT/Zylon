using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Spears
{
	public class SpearofJusticeClone : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Spear of Justice Clone");
        }
		public override void SetDefaults() {
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.alpha = 255;
			Projectile.rotation = Main.rand.NextFloat(0, MathHelper.TwoPi);
			Projectile.tileCollide = false;
		}
		Player main;
		int critBoost;
		float rSpeed;
		float totalRot;
		int Timer;
		int Timer2;
		Vector2 oops;
        public override void AI() {
			if (Timer2 < Projectile.ai[0]*45) {
				Timer2++;
				return;
            }
			Timer++;
			main = Main.player[Projectile.owner];
			if (Timer == 1) {
				SoundEngine.PlaySound(SoundID.Item109, Projectile.Center);
				Projectile.Center = main.Center + new Vector2(0, 64).RotatedByRandom(MathHelper.TwoPi);
					float distanceFromTarget = 100f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (!foundTarget) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];

					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = false; //between < 100f;

						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			oops = Vector2.Normalize(targetCenter - Projectile.Center) * 11f;
			if (!foundTarget) oops = Vector2.Normalize(main.Center - Projectile.Center) * 11f;
			Projectile.rotation = oops.ToRotation() + MathHelper.PiOver4;
            }
			else if (Timer <= 52) {
				Projectile.alpha -= 5;
				Projectile.rotation += MathHelper.ToRadians(1.41176470588f*(52-Timer));
            }
			else if (Timer == 53) {
				Projectile.velocity = oops;
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
            }
			else if (Timer == 233) {
				Projectile.Kill();
			}
			/*critBoost = (int)Projectile.ai[0];
			if (critBoost < 0) critBoost = 0;
			if (critBoost > 100) critBoost = 100;
			rSpeed = 2 + (5*critBoost/100);
			totalRot += rSpeed;
			Projectile.Center = main.Center - new Vector2(0, 150).RotatedBy(MathHelper.ToRadians(totalRot));
			Projectile.rotation = MathHelper.ToRadians(totalRot);
			if (totalRot < 300) Projectile.alpha -= 10 + (15*critBoost/100);
			else Projectile.alpha += 30 + (30*critBoost/100);
			if (totalRot >= 300 && Projectile.alpha > 254) Projectile.active = false;*/
        }
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonSpirit);
				dust.noGravity = true;
				dust.scale = 1.2f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			if (Timer > 0) Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}