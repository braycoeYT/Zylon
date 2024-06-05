using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.Graphics.Effects;

namespace Zylon.Projectiles.Minions
{
	public class SwordigamSword : ModProjectile
	{
        public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			//Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.scale = 0f;
			Projectile.hide = true;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
		int Timer;
		float offset;
		bool init;
		bool launch;
		int launchTimer;
		Projectile owner;
		public override void AI() { //ai0 - owner, ai1 - position in array, ai2 - offset | owner: ai0 is launch, ai1 is total rotation, ai2 is if topSword + 1 is active (allows for correct animation)
			owner = Main.projectile[(int)Projectile.ai[0]];

			if ((!owner.active && !launch)) Projectile.Kill();

			Timer++;
			if (!init) { //offset to look cooler
				if (Timer > (int)Projectile.ai[2]) {
					init = true;
					Timer = 0;
				}
				return;
			}

			if (Projectile.scale < 1f) { //Grow and show
				Projectile.scale += 0.05f;
				if (Projectile.scale > 1f) Projectile.scale = 1f;
			}
			else launchTimer++; //Don't launch immediately

			offset = MathHelper.ToRadians(Projectile.ai[1]*12f) + owner.ai[1];

			if (!launch) {
				Projectile.velocity = Vector2.Zero;
				Projectile.timeLeft = 9999;
				Projectile.Center = owner.Center;// + new Vector2(0, 1).RotatedBy();
				Projectile.rotation = offset;

				if (owner.ai[0] == 1f && Projectile.scale >= 1f && launchTimer > 15) {
					launch = true;
					Projectile.velocity = new Vector2(0, 16).RotatedBy(Projectile.rotation);
					Projectile.friendly = true;
				}
			}
			else {
				if (Projectile.timeLeft > 60) Projectile.timeLeft = 60;
			}
		}
		public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI) {
            behindProjectiles.Add(index);
        }
        public override void OnKill(int timeLeft) {
            Projectile.ai[0] = -1f; //Hello DADDY I AM DEAD PLEASE ACKNOWLEDGE MY PASSING
        }
        public override bool PreDraw(ref Color lightColor) {
			Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

			//Please god don't let this lag the game...
			float lookfor = Projectile.ai[1] + 1f;
			if (lookfor == 30f) lookfor = 0f; //There is no sword30
			bool hideStuff = false;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				Projectile test = Main.projectile[i];
				if (test.active && test.owner == Projectile.owner && test.type == Projectile.type && test.ai[1] == lookfor && test.scale >= 0.5f && test.velocity.Length() < 0.1f) {
					if (Projectile.whoAmI > test.whoAmI) { //If this sword appear above the next sword,
						hideStuff = true;
					}
					break; //Please don't lag the game?
				}
			}

			if (hideStuff && !launch) //If it is supposed to use the special sprite, do so.
            projectileTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Minions/SwordigamSword_Special");
			//old
			//if ((int)Projectile.ai[1] == 29f && !launch && owner.ai[2] == 1f) projectileTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Minions/SwordigamSword_Special");
            
			//Texture2D projText2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Minions/SwordigamSword_SpecialTransparent");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            
			/*float helper = 1f;
			if ((int)Projectile.ai[1] == 29f) helper = 0.8f;*/
			Color color = Color.White;//*helper;

			

			

            if (launch) for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY) - new Vector2(18, 0);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

			Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            
			//if ((int)Projectile.ai[1] == 29f && !launch && owner.ai[2] == 1f) Main.spriteBatch.Draw(projText2, drawPos, null, color*0.5f, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
    }   
}