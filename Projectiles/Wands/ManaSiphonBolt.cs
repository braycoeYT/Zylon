using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Zylon.Projectiles.Wands
{
	public class ManaSiphonBolt : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Mana Siphon");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 32;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 240;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.extraUpdates = 1;
		}
        public override void AI() {

			Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.ObeliskDust>(), Projectile.velocity.X, Projectile.velocity.Y, 0, default, 1.3f);

			Projectile.velocity *= 1.01f;

        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			if (target.type != NPCID.TargetDummy) {
				Siphon(Main.player[Projectile.owner], Main.rand.Next(5, 8));
			}
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				Siphon(Main.player[Projectile.owner], Main.rand.Next(5, 8));
			}
        }

        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}

		public void Siphon(Player player, int amount)
        {
			player.statMana += amount;
			player.ManaEffect(amount);

			for (int d = 0; d < 33; d++)
			{
				Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.ObeliskDust>(), Main.rand.NextFloat(-12.4f, 12.4f), Main.rand.NextFloat(-12.4f, 12.4f), 0, default, 1.2f);
			}


			return;
        }


		public override bool PreDraw(ref Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;

			Texture2D trail = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Wands/ManaSiphonBolt_backtrail");

			Vector2 drawOrigin = trail.Size() * 0.5f;

			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color colorAfterEffect = Color.Lerp(new Color(53, 48, 164), new Color(167, 223, 245), ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
				float AfterAffectScale = ((Projectile.scale - k / (float)Projectile.oldPos.Length / 1.5f) * (k / 4f)) + Projectile.scale;
				for (float j = 0; j < 0.7; j += 0.2f)
                {
					Main.spriteBatch.Draw(trail, drawPosEffect, null, colorAfterEffect * 0.75f, Projectile.rotation, drawOrigin, AfterAffectScale + j, spriteEffects, 0);
				}
			}

			return false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
        {
			for (int d = 0; d < 23; d++)
            {
				Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.ObeliskDust>(), -oldVelocity.X + Main.rand.NextFloat(-2.4f, 2.4f), -oldVelocity.Y + Main.rand.NextFloat(-2.4f, 2.4f), 0, default, 1.2f);
			}


			return true;
        }

    }   
}