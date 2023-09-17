using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Misc
{
	public class BombRock : ModItem
	{
		public override void SetDefaults() { //Reference: Pikmin
			Item.width = 42;
			Item.height = 42;
			Item.damage = 28;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 60;
			Item.useTime = 60;
			Item.knockBack = 6f;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(0, 2);
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Misc.BombRock>();
			Item.shootSpeed = 7.5f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Grenade, 250);
			recipe.AddIngredient(ItemID.MeteoriteBar, 8);
			recipe.AddIngredient(ItemType<Materials.SearedStone>(), 30);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}