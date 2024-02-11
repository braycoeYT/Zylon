using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Boomerangs
{
	public class Mecharang : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 57;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 26;
			Item.useTime = 28;
			Item.shootSpeed = 11f;
			Item.knockBack = 7f;
			Item.width = 22;
			Item.height = 42;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 4, 46);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Boomerangs.Mecharang>();
		}
		public override bool CanUseItem(Player player) {
			for (int i = 0; i < Main.maxProjectiles; i++) {
				if (Main.projectile[i].type == Item.shoot && Main.projectile[i].ai[0] == 0f) return false;
            }
			return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.SoulofSight, 13);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}