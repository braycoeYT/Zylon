using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Shortswords
{
	public class ZincShortsword : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 7;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 2.9f;
			Item.value = Item.sellPrice(0, 0, 5);
			Item.rare = 0;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.shoot = ProjectileType<Projectiles.Shortswords.ZincShortsword>();
			Item.shootSpeed = 4.6f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Bars.ZincBar>(), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}