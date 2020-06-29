using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Buffs.Pets
{
	public class BraycoeSlimeBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Braycoe's Favorite Slime");
			Description.SetDefault("\"This is Braycoe's favorite slime to morph into.\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<ZylonPlayer>().BraycoeSlimePet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Projectiles.Pets.BraycoeSlime>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<Projectiles.Pets.BraycoeSlime>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}