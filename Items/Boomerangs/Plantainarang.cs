using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Boomerangs
{
	public class Plantainarang : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 61;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 10;
			Item.useTime = 10;
			Item.shootSpeed = 20f;
			Item.knockBack = 7f;
			Item.width = 22;
			Item.height = 34;
			Item.rare = ItemRarityID.Lime;
			Item.value = Item.sellPrice(0, 15);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = 0;//ProjectileType<Projectiles.Boomerangs.PlantainarangProj>();
		}
		public override bool CanUseItem(Player player) {
			int total = 0;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				if (Main.projectile[i].type == Item.shoot && Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer) { 
					if (Main.projectile[i].ai[0] == 0f) return false;
					total++;
				}
			}
			return total < 12;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bananarang);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}