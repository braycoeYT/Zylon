using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Havoc
{
	public class ThrowableFloatingPotion : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Mod Crossover Item: Havoc Mod\nEach potion can launch enemies into the air");
			Item.staff[item.type] = true;
		}
		public override void SetDefaults() 
		{
			item.damage = 30;
			item.magic = true;
			item.width = 20;
			item.height = 26;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 4.5f;
			item.value = 1200;
			item.rare = ItemRarityID.Blue;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("ThrowableFloatingPotion");
			item.shootSpeed = 8f;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.maxStack = 999;
			item.UseSound = SoundID.Item1;
			item.consumable = true;
		}
		public override void AddRecipes() 
		{
			Mod xtraarmory = ModLoader.GetMod("Xtraarmory");
			if (xtraarmory != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(mod.ItemType("FloaterPotion"));
				recipe.AddTile(TileID.Bottles);
				recipe.SetResult(this, 150);
				recipe.AddRecipe();
			}
		}
	}
}