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
	public class AdenebFinaleWall : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 64;
			Projectile.height = 400;
			Projectile.aiStyle = -1;
			Projectile.hostile = false; //just for show, this is a placeholder
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		int Timer;
        float dist;
        float rot;
        float ihatescale;
		NPC owner;
        public override void AI() {
            Timer++;
			Projectile.alpha = Timer < 60 ? 127 : 0;
			owner = Main.npc[ZylonGlobalNPC.adenebBoss];

			if (!(owner.life < 1 || !owner.active)) Projectile.timeLeft = 2; //Active check
        }
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Adeneb/AdenebFinaleWall");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
    }   
}