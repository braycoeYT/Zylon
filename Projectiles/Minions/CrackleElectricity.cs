using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Zylon.Projectiles.Minions
{
	public class CrackleElectricity : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 20;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.hide = true;
		}
		int totalRot;
		int Timer;
		public override void AI() {
			Projectile owner = Main.projectile[(int)Projectile.ai[0]];
			Timer++;

			Lighting.AddLight(Projectile.Center, 1f, 1f, 0f);
			Projectile.Center = owner.Center + new Vector2(0, Timer*2).RotatedBy(MathHelper.ToRadians(Projectile.ai[1]+Timer)*3);
			Projectile.rotation = MathHelper.ToRadians(totalRot*90);
		}
		public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI) {
            behindProjectiles.Add(index);
        }
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }   
}