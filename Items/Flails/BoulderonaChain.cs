using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Flails
{
	public class BoulderonaChain : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Boulder on a Chain");
			// Tooltip.SetDefault("'Pinky may cry'\nStriking the ground produces a shockwave");
		}
		public override void SetDefaults() {
			Item.width = 42;
			Item.height = 38;
			Item.value = Item.sellPrice(0, 0, 5);
			Item.rare = ItemRarityID.Blue;
			Item.noMelee = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.knockBack = 9f;
			Item.damage = 32;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Flails.BoulderonaChain>();
			Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GrapplingHook);
			recipe.AddIngredient(ItemID.Boulder);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}