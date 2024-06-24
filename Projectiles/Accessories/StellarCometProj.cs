using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Accessories
{
	public class StellarCometProj : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.FallingStar);
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.width = 34;
			Projectile.height = 34;
			//AIType = 1;
		}
        public override void OnSpawn(IEntitySource source) {
            SoundEngine.PlaySound(SoundID.Item9, Projectile.position);
        }
        public override void AI() {
			Projectile.rotation += 0.08f;
			Projectile.tileCollide = Projectile.Center.Y > Main.player[Projectile.owner].Center.Y - 64;
        }
        public override void PostAI() {
			Lighting.AddLight(Projectile.Center, 0.15f, 0.35f, 0.5f);
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch);
				dust.noGravity = false;
				dust.scale = 1f;
			}
        }
        public override void OnKill(int timeLeft) {
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch);
				dust.noGravity = false;
				dust.scale = 1.5f;
			}
			if (Main.rand.NextFloat() < .15f) Item.NewItem(Projectile.GetSource_FromThis(), Projectile.getRect(), ModContent.ItemType<Items.Misc.StellarCometStar>());
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY) + Projectile.velocity*k*0.5f;
				Color colorAfterEffect = Color.White * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.EntitySpriteDraw(texture, drawPos, null, colorAfterEffect*((float)(255-Projectile.alpha)/255f), Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
			}
            return false;
        }
	}   
}