using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class Fahrenheit : ModItem
	{
		public override void SetDefaults() { //Fun fact: I have read the book (for fun, not for school). I love Bradbury.
			Item.damage = 122;
			Item.DamageType = DamageClass.Magic;
			Item.width = 38;
			Item.height = 44;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2.75f;
			Item.value = Item.sellPrice(0, 8, 45, 10);
			Item.rare = ModContent.RarityType<PurpleModded>();
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.FahrenheitProj>();
			Item.shootSpeed = 18f;
			Item.noMelee = true;
			Item.mana = 10;
			Item.UseSound = SoundID.Item43;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Sunburn>());
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.FragmentNebula, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}