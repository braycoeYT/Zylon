using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Boomerangs
{
	public class BionicBoomer : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'Suited for a cyborg monkey's hand, but still fits!'\nHas short range, but multiple can be shot at once");
		}
		public override void SetDefaults() {
			Item.damage = 11;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 19;
			Item.useTime = 19;
			Item.shootSpeed = 11.5f;
			Item.knockBack = 5.5f;
			Item.width = 54;
			Item.height = 32;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(0, 0, 20);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Boomerangs.BionicBoomerRang>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 5;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 9);
			recipe.AddIngredient(ItemType<Materials.RustedTech>(), 12);
			recipe.AddIngredient(ItemID.WoodenBoomerang);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}