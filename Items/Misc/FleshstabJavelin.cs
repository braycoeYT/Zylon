using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Misc
{
	public class FleshstabJavelin : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 26;
			Item.damage = 39;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 41;
			Item.useTime = 41;
			Item.knockBack = 6.3f;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 3, 56);
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Misc.FleshstabJavelin>();
			Item.shootSpeed = 16f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<CrimtaneJavelin>());
			recipe.AddIngredient(ItemID.Ichor, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}