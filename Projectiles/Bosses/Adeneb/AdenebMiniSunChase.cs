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
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 25;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
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
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 7)*60);
        }
        NPC owner;
		int Timer;
		Vector2 rand;
		public override bool PreAI() {
            owner = Main.npc[ZylonGlobalNPC.adenebBoss];
            if (owner.ai[0] == 3f) {
				Projectile.timeLeft = 2;
                Projectile.scale *= 0.99f;
                Projectile.scale -= 0.01f;
				Projectile.rotation += MathHelper.ToRadians(5);

                if (Projectile.scale < 0.01f) Projectile.Kill();
            }
            return owner.ai[0] != 3f;
        }
        public override void AI() {
			//owner = Main.npc[ZylonGlobalNPC.adenebBoss];
			Timer++;
			Projectile.rotation += MathHelper.ToRadians(5);

			if (Timer < 60) {
				Projectile.velocity *= 0.94f;
            }
			else if (Timer == 60) {
				rand = Main.player[owner.target].Center + new Vector2(Main.rand.Next(-150, 151), Main.rand.Next(-150, 151));
				Projectile.netUpdate = true;
            }
			else if (Timer < 75) {
				Projectile.velocity += Vector2.Normalize(Projectile.Center - rand) * -0.2f;
            }
			else if (Timer < 140) Projectile.velocity *= 1.03f; //1.04 og

			if (owner.life < 2) Projectile.Kill();
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
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Adeneb/AdenebMiniSunChase");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
	}   
}