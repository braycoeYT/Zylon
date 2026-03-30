using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Whips
{
    public class GiegueSpark : ModProjectile
    {
        public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 40;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults() {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.timeLeft = 80;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 1;
            Projectile.tileCollide = false;
        }
        int Timer;
        int type = Main.rand.Next(4);
        public override void AI() {
            if (Timer == 0) Projectile.ai[0] = Main.npc.Length-1;
            Timer++;
            //Projectile.tileCollide = Timer > 60;

            bool foundTarget = false;
            if (!Main.npc[(int)Projectile.ai[0]].active) {
				float distanceFromTarget = 1000f;
				Vector2 targetCenter = Projectile.position;

				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];

					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = false;

						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
							Projectile.ai[0] = i;
						}
					}
				}
			}
            else foundTarget = true;

            if (foundTarget && Main.npc[(int)Projectile.ai[0]].active && Main.npc[(int)Projectile.ai[0]].life > 0) {
                Vector2 temp = Projectile.velocity;
                Projectile.velocity = (temp*9f + Projectile.Center.DirectionTo(Main.npc[(int)Projectile.ai[0]].Center)*10f)/10f;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            switch (type) {
                case 0:
                    target.AddBuff(BuffID.OnFire3, Main.rand.Next(7, 9)*60); break;
                case 1:
                    target.AddBuff(BuffID.CursedInferno, Main.rand.Next(4, 6)*60); break;
                case 2:
                    target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(5, 7)*60); break;
                case 3:
                    target.AddBuff(BuffID.Frostburn2, Main.rand.Next(6, 8)*60); break;
            }
        }
        public override void PostAI() {
            Projectile.rotation += 0.05f;
            int dustType = DustID.Torch;
            switch (type) {
                case 1:
                    dustType = DustID.CursedTorch; break;
                case 2:
                    dustType = DustID.Shadowflame; break;
                case 3:
                    dustType = DustID.Frost; break;
            }
            for (int i = 0; i < 1; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, dustType);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
        }
        public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

            Color color = Color.Red;
            switch (type) {
                case 1:
                    color = Color.Lime; break;
                case 2:
                    color = Color.Purple; break;
                case 3:
                    color = Color.Cyan; break;
            }
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), color, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
            return false;
		}
    }
}