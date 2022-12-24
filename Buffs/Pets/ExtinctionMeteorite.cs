using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Buffs.Pets
{
	public class ExtinctionMeteorite : ModBuff
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Extinction Meteorite");
			Description.SetDefault("It COULD cause another extinction, but it chooses not to...");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			int projType = ProjectileType<Projectiles.Pets.ExtinctionMeteorite>();
			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0) {
				var entitySource = player.GetSource_Buff(buffIndex);
				Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
			}
		}
	}
}