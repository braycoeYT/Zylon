using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class SpectreScythe : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 76;
			Item.DamageType = DamageClass.Melee;
			Item.width = 66;
			Item.height = 62;
			Item.useTime = 27;
			Item.useAnimation = 27;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6.5f;
			Item.value = Item.sellPrice(0, 10);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item71;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.SpectreScytheProj>();
			Item.shootSpeed = 10f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DeathSickle);
			recipe.AddIngredient(ItemID.SpectreBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}