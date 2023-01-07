using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class CarnalliteTrident : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.Spears[Item.type] = true;
			Tooltip.SetDefault("'Enchanted with Loyalty I'");
		}
		public override void SetDefaults() {
			Item.damage = 27;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.useAnimation = 29;
			Item.useTime = 29;
			Item.shootSpeed = 5.5f;
			Item.knockBack = 5.4f;
			Item.width = 32;
			Item.height = 32;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(0, 0, 56, 0);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.CarnalliteTrident>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}