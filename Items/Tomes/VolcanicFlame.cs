using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class VolcanicFlame : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Casts down a psychokinetic flame wall");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 54, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 34;
			Item.useTime = 34;
			Item.damage = 19;
			Item.width = 30;
			Item.height = 36;
			Item.knockBack = 0.5f;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.PKFire1>();
			Item.shootSpeed = 16f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Orange;
			Item.mana = 14;
			Item.UseSound = SoundID.Item116;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Book);
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}