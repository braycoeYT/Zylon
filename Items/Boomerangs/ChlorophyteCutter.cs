using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Boomerangs
{
	public class ChlorophyteCutter : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 71;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 26;
			Item.useTime = 28;
			Item.shootSpeed = 16f;
			Item.knockBack = 5.9f;
			Item.width = 64;
			Item.height = 60;
			Item.rare = ItemRarityID.Lime;
			Item.value = Item.sellPrice(0, 4, 32);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Boomerangs.ChlorophyteCutter>();
		}
		public override bool CanUseItem(Player player) {
			int total = 0;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				if (Main.projectile[i].type == Item.shoot && Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer) { 
					if (Main.projectile[i].ai[0] == 0f) return false;
					total++;
				}
			}
			return total < 15;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}