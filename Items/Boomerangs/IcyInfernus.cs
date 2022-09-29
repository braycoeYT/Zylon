using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Boomerangs
{
	public class IcyInfernus : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Hell's frozen over!'\nStruck enemies may be inflicted with On Fire and Frostburn");
		}
		public override void SetDefaults() {
			Item.damage = 41;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 12;
			Item.useTime = 14;
			Item.shootSpeed = 15f;
			Item.knockBack = 8.5f;
			Item.width = 18;
			Item.height = 32;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(0, 3);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Boomerangs.IcyInfernus>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Flamarang);
			recipe.AddIngredient(ItemID.IceBoomerang);
			recipe.AddIngredient(ItemID.Bone, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}