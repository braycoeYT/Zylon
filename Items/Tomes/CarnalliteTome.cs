using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class CarnalliteTome : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Casts a slow moving orb that quickly shoots leaves above itself");
		}
		public override void SetDefaults() {
			Item.damage = 23;
			Item.width = 44;
			Item.height = 42;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.6f;
			Item.value = Item.sellPrice(0, 0, 56, 0);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.CarnalliteOrb>();
			Item.shootSpeed = 5.6f;
			Item.noMelee = true;
			Item.mana = 13;
			Item.stack = 1;
			Item.UseSound = SoundID.Item8;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}