using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class ZincBroadsword : ModItem
	{
		public override void SetDefaults() 
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.1f;
			Item.value = Item.sellPrice(0, 0, 5, 80);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.ZincBar>(), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}