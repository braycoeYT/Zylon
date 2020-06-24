using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Shields
{
	public class LifeFruitShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Life Fruit Shield");
			Tooltip.SetDefault("Increases life regen by 3\nIncreases max life by 50\nYou gain life every time you take damage");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 750000;
			item.rare = 1;
			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 50;
			player.lifeRegen += 3;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.hurtHeal = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("LifeCrystalShield"));
			recipe.AddIngredient(mod.ItemType("FruitOfLife"));
			recipe.AddIngredient(ItemID.ChlorophyteBar, 14);
			recipe.AddIngredient(mod.ItemType("PlanteraTooth"), 3);
			recipe.AddIngredient(ItemID.LifeFruit, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}