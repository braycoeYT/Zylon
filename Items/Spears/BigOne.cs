using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class BigOne : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.Spears[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.damage = 56;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.knockBack = 4.5f;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(0, 4, 60);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.BigOneSpear>();
			Item.shootSpeed = 5f;
		}
		int shootCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			if (shootCount % 3 == 2) Item.reuseDelay = 15;
			else Item.reuseDelay = 0;

			return true;
        }
        public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot) {
                    return false;
                }
            }
            return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Bars.DarkronBar>(), 9);
			recipe.AddIngredient(ItemType<Materials.SoulofByte>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}