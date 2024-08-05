using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Minions
{
	public class ArgentumOrb : ModProjectile
	{
        public override void SetStaticDefaults() {
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 25;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.minion = true;
			Projectile.minionSlots = 0f;
			Projectile.extraUpdates = 1;
		}
        public override bool MinionContactDamage() {
            return false;
        }
        int Timer;
		int minionID;
		int targetNum;
		int animTimer;
		bool init;
		Player own;
		public override void PostAI() {
			Projectile.netUpdate = true;
			if (!init) { 
				init = true;
				animTimer = (int)(Main.GameUpdateCount%720);
				return;
			}

			animTimer++;
			minionID = (int)Projectile.ai[0];
			own = Main.player[Projectile.owner];
			ZylonPlayer p = own.GetModPlayer<ZylonPlayer>();

			if (own.dead || !own.active)
				Projectile.active = false;
			if (p.argentumSetBonus)
				Projectile.timeLeft = 2;

			Projectile.Center = own.Center - new Vector2(0, 64).RotatedBy(MathHelper.ToRadians((animTimer%720)+(360*minionID/4)));

			float distanceFromTarget = 1000f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (own.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[own.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
				if (between < 2000f)
				{
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget)
			{
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 500f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
							targetNum = npc.whoAmI;
						}
					}
				}
			}
			Projectile.friendly = foundTarget;
			if (foundTarget) {
				Timer++;
				if (Timer % 120 == 0) {
					SoundEngine.PlaySound(new SoundStyle("Zylon/Sounds/Items/ArgentumOrbSFX").WithPitchOffset(Main.rand.NextFloat(3f)).WithVolumeScale(0.35f), Projectile.position);
					Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 4f;
					if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, projDir, ModContent.ProjectileType<ArgentumOrb_Laser>(), Projectile.damage, Projectile.knockBack, Projectile.owner, targetNum);
				}
			}
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + new Vector2(16, 16); //+ drawOrigin
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
    }   
}