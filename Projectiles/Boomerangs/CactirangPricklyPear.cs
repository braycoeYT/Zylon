using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class CactirangPricklyPear : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Prickly Pear");
        }
        public override void SetDefaults()
        {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;
			Projectile.penetrate = -1;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 30;
		}


		// Projectile.ai[0] is the stuck npc whoAmI.
		Vector2 LocationalOffset = Vector2.Zero;
        public override void AI()
        {
			NPC AttatchedNPC = Main.npc[(int)Projectile.ai[0]];
			if (Projectile.ai[1] == 0)
            {
				LocationalOffset = Projectile.Center - AttatchedNPC.Center;
            }
			if (!Main.npc[(int)Projectile.ai[0]].active || Main.npc[(int)Projectile.ai[0]] == null)
            {
				Projectile.Kill();
            }
			Projectile.ai[1]++;

			Projectile.rotation = (Projectile.Center - AttatchedNPC.Center).ToRotation() + MathHelper.ToRadians(45);

			Projectile.Center = AttatchedNPC.Center + LocationalOffset;

        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override bool? CanHitNPC(NPC target)
        {
            if (target.whoAmI == Projectile.ai[0])
            {
				return null;
            }
			return false;
        }

        public override bool PreDraw(ref Color lightColor)
        {
			Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

			Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Projectile.GetAlpha(lightColor);

			float FakeScale = 1f;

			if (Projectile.ai[1] <= 16)
			{
				FakeScale = MathExtras.TensionStep(0.65f, 1f, (Projectile.ai[1] / 16f), 0.9f, 0.45f);
			}
			if (Projectile.timeLeft <= 16)
            {
				FakeScale = MathHelper.SmoothStep(0.45f, 1f, (Projectile.timeLeft / 16f));
			}

			Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, FakeScale, SpriteEffects.None, 0f);

			return false;
        }
    }   
}