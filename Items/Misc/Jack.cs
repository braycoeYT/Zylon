using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Misc
{
	public class Jack : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 26;
			Item.damage = 18;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.knockBack = 1f;
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(0, 0, 0, 19);
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Misc.Jack>();
			Item.shootSpeed = 19f;
			Item.maxStack = 9999;
			Item.consumable = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Shuriken);
			recipe.AddIngredient(ItemID.SpikyBall);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}