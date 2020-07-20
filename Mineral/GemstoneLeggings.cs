using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	[AutoloadEquip(EquipType.Legs)]
	public class GemstoneLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The boots are surprisingly light\nDamage reduction increased by 4%\nIncreases movement speed by 20%\nWhen not moving horizontally, you do a lot more damage\nIf you are moving quickly horizontally, you do slightly less damage\nThe negative effects seem worse because of the positive ones happening when you stand still");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 750000;
			item.rare = 11;
			item.defense = 30;
		}
		
		public override void UpdateEquip(Player player)
		{
			if (player.velocity.X != 0)
			{
				if (player.velocity.X > 0)
				player.allDamage -= player.velocity.X / 100f;
				else
				player.allDamage -= player.velocity.X / -100f;
			}
			else
			player.allDamage += 0.4f;
			player.maxRunSpeed += 0.2f;
			player.endurance += 0.04f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 20);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 16);
			recipe.AddIngredient(ItemID.Amethyst, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}