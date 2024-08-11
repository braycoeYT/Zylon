using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Boomerangs
{
	public class Cogwheel : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 56;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 20;
			Item.useTime = 22;
			Item.shootSpeed = 18f;
			Item.knockBack = 5f;
			Item.width = 56;
			Item.height = 56;
			Item.rare = ItemRarityID.Lime;
			Item.value = Item.sellPrice(0, 4, 17);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Boomerangs.CogwheelProj>();
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
			recipe.AddIngredient(ItemID.Cog, 50);
			recipe.AddIngredient(ItemType<Materials.ElementalGoop>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}