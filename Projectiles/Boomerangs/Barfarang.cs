using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class Barfarang : BoomerangProj
	{
		public Barfarang() : base(40, 7, 14, 20f, 300f, 45) { }
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Barfarang");
        }
		public override void BoomerangDefaultsSafe()
		{
			Projectile.width = 22;
			Projectile.height = 36;
		}
	}   
}