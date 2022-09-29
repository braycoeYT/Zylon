using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Misc
{
	public class FleshstabJavelin : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("On impact, explodes into multiple ichor splashes");
		}
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 26;
			Item.damage = 71;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 41;
			Item.useTime = 41;
			Item.knockBack = 5.1f;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(0, 3, 56);
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Misc.FleshstabJavelin>();
			Item.shootSpeed = 31f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CrimtaneJavelin>());
			recipe.AddIngredient(ItemID.Ichor, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.AdamantiteBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CrimtaneJavelin>());
			recipe.AddIngredient(ItemID.Ichor, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.TitaniumBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}