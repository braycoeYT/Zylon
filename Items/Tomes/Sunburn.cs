using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class Sunburn : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 24;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1.8f;
			Item.value = Item.sellPrice(0, 1, 60);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.Sunburn_Spark>();
			Item.shootSpeed = 7f;
			Item.noMelee = true;
			Item.mana = 9;
			Item.stack = 1;
			Item.UseSound = SoundID.Item20;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.SearedStone>(), 30);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}