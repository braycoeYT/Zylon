using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.OtherSeeds.PH
{
	public class CrimtaneSeedshot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimtane Seedshot");
			Tooltip.SetDefault("For use with blowpipes\nWhile in the crimson, each seed pierces five times, and spawns a temporary stationary crimtane heart after piercing");
        }
		public override void SetDefaults()
		{
			item.damage = 6; //3
			item.ranged = true;
			item.width = 12;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f; //0
			item.value = 10; //0
			item.rare = ItemRarityID.Blue;
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.Crimson.CrimtaneSeedshot>();
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
		}
		public override void UpdateInventory(Player player)
		{
			if (player.ZoneCrimson)
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.Crimson.CrimtaneSeedshotGood>();
			else
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.Crimson.CrimtaneSeedshot>();
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Seed, 200);
			recipe.AddIngredient(ItemID.CrimtaneBar);
			recipe.AddIngredient(ItemID.Vertebrae);
			recipe.AddIngredient(ItemID.ViciousPowder);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 200);
			recipe.AddRecipe();
		}
	}
}