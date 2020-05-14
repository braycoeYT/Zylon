using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Pets
{
	public class MarblePet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marble");
			Main.projFrames[projectile.type] = 8;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.BabySnowman);
			aiType = ProjectileID.BabySnowman;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			PlayerEdit modPlayer = player.GetModPlayer<PlayerEdit>();
			if (player.dead)
			{
				modPlayer.MarblePet = false;
			}
			if (modPlayer.MarblePet)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}