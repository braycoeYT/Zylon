using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class StickWand2 : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("True Wand of Sparking");
			Tooltip.SetDefault("'A mighty blaze can be unleashed within this UPGRADED tree branch.'");
		}

		public override void SetDefaults() 
		{
			item.damage = 29;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 0;
			item.value = 50000;
			item.rare = ItemRarityID.Orange;
			item.autoReuse = true;
			item.useTurn = false;
			item.shoot = ProjectileID.Spark;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.mana = 9;
			item.stack = 1;
			item.UseSound = SoundID.Item8;
			item.crit = 7;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WandofSparking);
			recipe.AddIngredient(ItemID.Obsidian, 12);
			recipe.AddIngredient(ItemID.Bone, 20);
			recipe.AddIngredient(ItemID.MeteoriteBar, 7);
			recipe.AddIngredient(ItemID.Wood, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}