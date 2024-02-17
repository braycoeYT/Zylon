using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Yoyos
{
	public class Coldnea : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Shoots ice lasers around itself when thrown");
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 24;
			Item.height = 24;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 16f;
			Item.knockBack = 4.3f;
			Item.damage = 84;
			Item.rare = ItemRarityID.Lime;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(0, 6, 50, 0);
			Item.shoot = ProjectileType<Projectiles.Yoyos.Coldnea>();
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Amarok);
			recipe.AddIngredient(ItemID.IceBlock, 25);
			recipe.AddIngredient(ItemType<Materials.ElementalGoop>(), 10);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}