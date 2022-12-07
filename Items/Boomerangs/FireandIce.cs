using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Boomerangs
{
	public class FireandIce : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Fire and Ice");
			Tooltip.SetDefault("'Hell's frozen over!'\nStruck enemies are inflicted with On Fire and Frostburn\nBefore returning, releases several ice and fire balls");
		}
		public override void SetDefaults() {
			Item.damage = 41;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 12;
			Item.useTime = 14;
			Item.shootSpeed = 15f;
			Item.knockBack = 6.3f;
			Item.width = 18;
			Item.height = 32;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(0, 0, 80);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Boomerangs.FireandIce>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AshBlock, 50);
			recipe.AddIngredient(ItemID.IceBlock, 50);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddRecipeGroup("Zylon:AnyGem", 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}