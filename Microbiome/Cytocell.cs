using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Microbiome
{
	public class Cytocell : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cytocell");
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
			projectile.width = 20;
			projectile.height = 20;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			ZylonPlayer modPlayer = player.GetModPlayer<ZylonPlayer>();
			if (player.dead)
			{
				modPlayer.cytocellPet = false;
			}
			if (modPlayer.cytocellPet)
			{
				projectile.timeLeft = 2;
			}
			projectile.light = 0.75f;
		}
	}
}