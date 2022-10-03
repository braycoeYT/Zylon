using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class GraveBuster : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Grave robbing for morons'\nHitting enemies will give you the 'Gravely Powers' buff, which increases your life regen");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 1);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 26;
			Item.useTime = 26;
			Item.damage = 28;
			Item.width = 22;
			Item.height = 54;
			Item.knockBack = 2.8f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Blue;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.ObeliskShard>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Recipe.Condition.InGraveyardBiome);
			recipe.Register();
		}
	}
}