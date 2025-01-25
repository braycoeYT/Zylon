using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class FrostRing : ModItem
	{
        public override void SetDefaults() {
			Item.damage = 9;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.75f;
			Item.value = Item.sellPrice(0, 0, 5, 12);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.FrostRing>();
			Item.shootSpeed = 11f;
			Item.noUseGraphic = true;
			Item.channel = true;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            int mult = 1;
			if (Main.rand.NextBool()) mult = -1;
			velocity = velocity.RotatedBy(MathHelper.ToRadians(mult*Main.rand.NextFloat(5, 25)));
        }
        int total;
		public override bool CanUseItem(Player player) {
			total = 0;
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot && Main.projectile[i].ai[0] == 0f) {
                    total++;
                }
            }
            return total < 3;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.EnchantedIceCube>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}