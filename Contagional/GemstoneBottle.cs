using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Contagional
{
	public class GemstoneBottle : ContagionalItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemstone Bottle");
			Tooltip.SetDefault("'The jar hasn't been cleaned for aeons'\n~~~90% chance of inflicting venom for 5 seconds\n~~~10% chance of inflicting ichor for 3 seconds\n~~~10% chance of inflicting cursed inferno for 3 seconds\n~~~20% chance of inflicting frostburn for 4 seconds\n~~~4% chance of inflicting daybroken for 3 seconds");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 209;
			item.width = 33;
			item.height = 33;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 120050;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("GemstoneMinivirus");
			item.shootSpeed = 10;
			item.crit = 12;
			ContagionalResourceCost = 36;
			item.noMelee = true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 13);
			recipe.AddIngredient(ItemID.VilePowder, 5);
			recipe.AddIngredient(ItemID.RottenChunk, 5);
			recipe.AddIngredient(ItemID.CursedFlame, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 13);
			recipe.AddIngredient(ItemID.ViciousPowder, 5);
			recipe.AddIngredient(ItemID.Vertebrae, 5);
			recipe.AddIngredient(ItemID.Ichor, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}