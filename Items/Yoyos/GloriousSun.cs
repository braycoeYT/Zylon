using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Yoyos
{
	public class GloriousSun : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Creates explosions nearby itself");
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 30;
			Item.height = 26;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 16f;
			Item.knockBack = 4.2f;
			Item.damage = 178;
			Item.rare = ItemRarityID.Red;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.shoot = ProjectileType<Projectiles.Yoyos.GloriousSun>();
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentSolar, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}