using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class Pukerang : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 47;
			Item.DamageType = DamageClass.Melee;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4.8f;
			Item.value = Item.sellPrice(0, 3, 56);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.Pukerang>();
			Item.shootSpeed = 13f;
			Item.noUseGraphic = true;
		}
		public override bool CanUseItem(Player player) {
			int total = 0;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				if (Main.projectile[i].type == Item.shoot && Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer) { 
					if (Main.projectile[i].ai[0] == 0f) return false;
					total++;
				}
			}
			return total < 10;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Barfarang>());
			recipe.AddIngredient(ItemID.CursedFlame, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}