using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Tomes
{
	public class ChaosBallFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Chaos Ball");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 7;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 1200;
		}
		public override void AI() {
			for (int i = 0; i < 2; i++) {
				int dustType = 27;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
			Projectile.rotation += 0.1f;
			

		}

		private void NetworkHex(NPC target)
        {
			// The only reason I don't just call OnHitNPC is because it is more efficent to run a seperate one that doesn't check the HP because it already gets checked. Really small efficency difference that doesn't mean much but I will do it anyways.
			var HexNPC = target.GetGlobalNPC<HexNPC>();

			if (HexNPC.Hexes < 4)
			{
				HexNPC.FadeIn = 0.05f;
				HexNPC.Hexes++;
			}
			HexNPC.HexesPlayer = Projectile.owner;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			// Literally no point in trying to apply the effect to (should be) dead NPCs, so we don't.
			if (target.life > 0)
            {
				var HexNPC = target.GetGlobalNPC<HexNPC>();
				if (HexNPC.Hexes < 4)
                {
					HexNPC.FadeIn = 0.05f;
					HexNPC.Hexes++;
				}
				HexNPC.HexesPlayer = Projectile.owner;
			}
        }

        public override bool PreDraw(ref Color lightColor)
        {
			Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D trail = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/ChaosBallFriendly_trail");

			Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Color.White;

			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
				float AfterAffectScale = (Projectile.scale * 1.3f) - k / (float)Projectile.oldPos.Length / 3;
				Main.spriteBatch.Draw(trail, drawPosEffect, null, colorAfterEffect, Projectile.rotation, drawOrigin, AfterAffectScale, SpriteEffects.None, 0);
			}

			Main.spriteBatch.Draw(trail, drawPos, null, color * 0.2f, Projectile.rotation, drawOrigin, Projectile.scale * 1.8f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(trail, drawPos, null, color * 0.2f, Projectile.rotation, drawOrigin, Projectile.scale * 1.6f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(trail, drawPos, null, color * 0.2f, Projectile.rotation, drawOrigin, Projectile.scale * 1.4f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(trail, drawPos, null, color * 0.2f, Projectile.rotation, drawOrigin, Projectile.scale * 1.2f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

			return false;
        }

        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int d = 0; d < 6; d++)
			{
				Dust.NewDust(Projectile.Center, 0, 0, DustID.Shadowflame, Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-3, 3), 0, Color.White, 1.3f);
			}
			if (Main.myPlayer != Projectile.owner)
            {
				for (int npcnum = 0; npcnum < Main.maxNPCs; npcnum++)
				{
					NPC npc = Main.npc[npcnum];
					if (npc.life > 0 && npc.Hitbox.Intersects(Projectile.Hitbox) && npc.active && !npc.dontTakeDamage)
					{
						NetworkHex(npc);
					}
				}
			}
		}

	}   
}