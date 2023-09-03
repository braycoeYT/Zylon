using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Buffs.Pets
{
	public class SpookyJellyfish : ModBuff
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Spooky Jellyfish");
			// Description.SetDefault("It flashes in and out of visibility, trying to scare something...");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			int projType = ProjectileType<Projectiles.Pets.SpookyJellyfish>();
			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0) {
				var entitySource = player.GetSource_Buff(buffIndex);
				Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
			}
		}
	}
}