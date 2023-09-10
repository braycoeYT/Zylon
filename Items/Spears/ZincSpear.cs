using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class ZincSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.Spears[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 11;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 22;
			Item.useTime = 28;
			Item.shootSpeed = 3f;
			Item.knockBack = 6.1f;
			Item.width = 32;
			Item.height = 32;
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(0, 0, 5, 40);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.ZincSpear>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Bars.ZincBar>(), 9);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}