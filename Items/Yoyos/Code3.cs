using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Yoyos
{
	public class Code3 : ModItem
	{
		public override void SetStaticDefaults() {

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
			Item.knockBack = 4f;
			Item.damage = 96;
			Item.rare = ItemRarityID.Lime;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(0, 8, 0, 0);
			Item.shoot = ProjectileType<Projectiles.Yoyos.Code3>();
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            for (int i = 0; i < 3; i++)
				Projectile.NewProjectile(source, position, velocity * (i - 1), type, damage, knockback, player.whoAmI);
			return false;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Code1);
			recipe.AddIngredient(ItemID.Code2);
			recipe.AddIngredient(ItemType<Materials.ElementalGoop>(), 10);
			recipe.AddIngredient(ItemID.BeetleHusk, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}