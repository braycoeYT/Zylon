using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Misc
{
	public class CrimtaneJavelin : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 26;
			Item.damage = 17;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 36;
			Item.useTime = 36;
			Item.knockBack = 4.8f;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 0, 27);
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Misc.CrimtaneJavelin>();
			Item.shootSpeed = 10f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}