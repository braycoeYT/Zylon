using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.MushroomGlow
{
	public class BookofGlowingShrooms : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Book of Glowing Shrooms");
		}

		public override void SetDefaults() 
		{
			item.value = 50000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 10;
			item.useTime = 10;
			item.damage = 11;
			item.width = 12;
			item.height = 24;
			item.knockBack = 4.6f;
			item.shoot = mod.ProjectileType("GlowingMushroomBolt");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = ItemRarityID.Blue;
			item.mana = 3;
			item.UseSound = SoundID.Item43;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BookofShrooms"));
			recipe.AddIngredient(mod.ItemType("GlazedLens"));
			recipe.AddIngredient(ItemID.GlowingMushroom, 18);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}