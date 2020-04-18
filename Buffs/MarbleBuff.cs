using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Buffs
{
	public class MarbleBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Marble");
			Description.SetDefault("\"It wants to follow you... it seems to hate bowling balls\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<PlayerEdit>().MarblePet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Projectiles.Pets.MarblePet>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<Projectiles.Pets.MarblePet>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}