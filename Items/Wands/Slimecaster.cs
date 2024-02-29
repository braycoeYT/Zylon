using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class Slimecaster : ModItem
	{
        public override void SetStaticDefaults() {
			Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 23;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 44;
			Item.useAnimation = 44;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5.6f;
			Item.value = Item.sellPrice(0, 0, 30, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.SlimecasterProj>();
			Item.shootSpeed = 16f;
			Item.mana = 12;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnySilverBar", 8);
			recipe.AddIngredient(ModContent.ItemType<Materials.SlimyCore>(), 5);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
    }
}