using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Zylon.NPCs;
using System.Collections.Generic;

namespace Zylon.Projectiles.Bosses.Adeneb
{
	public class AdenebSunShield : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 128;
			Projectile.height = 128;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.hide = true;
		}
		int Timer;
		float ihatescale = 0f;
		bool init;
		NPC owner;
        public override void AI() {
			owner = Main.npc[ZylonGlobalNPC.adenebBoss];

			if (!init) {
				if (Projectile.ai[0] == 1f) ihatescale = Main.getGoodWorld ? 1.5f : 1f;
				init = true;
            }

			if (!(owner.life < 1 || !owner.active)) Projectile.timeLeft = 2; //Active check

			//Init scale
			if (ihatescale < 1f || (ihatescale < 1.5f && Main.getGoodWorld)) ihatescale += 0.02f;
			if (ihatescale < 1.5f && Main.getGoodWorld) ihatescale += 0.01f;

			//Pos fix
            Projectile.Center = owner.Center;
			Projectile.rotation += MathHelper.ToRadians(5);

			//Split attack
			if (owner.ai[1] == 1) {
				if (ihatescale < 1.5f || (ihatescale < 2f && Main.getGoodWorld)) ihatescale += 0.01f;
				else {
					for (int x = 0; x < 2; x++) {
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<AdenebSunShieldSplit>(), Projectile.damage, 0f, -1, x);
                    }
					Projectile.Kill();
                }
            }
        }
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Adeneb/AdenebSunShield");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, ihatescale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, ihatescale, SpriteEffects.None, 0f);

            return false;
        }
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI) {
            behindNPCs.Add(index);
        }
    }   
}