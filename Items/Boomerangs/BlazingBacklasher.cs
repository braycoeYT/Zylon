using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class BlazingBacklasher : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 212;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.width = 30;
			Item.height = 42;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 8f;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.BlazingBacklasher>();
			Item.shootSpeed = 18f;
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
			recipe.AddIngredient(ItemID.FragmentSolar, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}