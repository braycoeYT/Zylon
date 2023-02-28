using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class Cactirang : BoomerangProj
	{
		public Cactirang() : base(50, 7, 2, 42.5f, 420f, 70, ArcCenter_Input: 0.65f, MaxPredictionDots_Input: 150, BoomerangRotationSpeed_Input: 0.13f) { }
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cactirang");
        }
		public override void BoomerangDefaultsSafe()
		{
			Projectile.width = 20;
			Projectile.height = 38;
		}

        public override void OnHitNPCSafe(NPC target, int damage, float knockback, bool crit)
        {
            if (crit && Main.myPlayer == Projectile.owner)
            {
				Vector2 SpawnLocation = target.Center;
				if (Main.rand.NextBool(2))
                {
					SpawnLocation += new Vector2(target.width * Main.rand.NextFloat(0.1f, 0.41f), 0);
                } else
                {
					SpawnLocation += new Vector2(-target.width * Main.rand.NextFloat(0.1f, 0.41f), 0);
				}

				if (Main.rand.NextBool(2))
				{
					SpawnLocation += new Vector2(0, target.height * Main.rand.NextFloat(0.1f, 0.41f));
				}
				else
				{
					SpawnLocation += new Vector2(0, -target.height * Main.rand.NextFloat(0.1f, 0.41f));
				}

				Projectile.NewProjectile(Projectile.GetSource_FromThis(), SpawnLocation, Vector2.Zero, ModContent.ProjectileType<CactirangPricklyPear>(), (int)(damage * 0.45f) + (int)(target.defense * 0.5f), 0f, Projectile.owner, target.whoAmI, 0f);
            }
        }

    }   
}