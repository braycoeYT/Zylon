using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bows
{
	public class Cartilage : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 1, 89);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 36;
			Item.useTime = 36;
			Item.damage = 44;
			Item.width = 28;
			Item.height = 52;
			Item.knockBack = 3f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 10.25f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.rare = 2;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (Main.rand.NextBool(3)) type = ProjectileID.BoneArrowFromMerchant;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bone, 55);
			recipe.AddIngredient(ItemID.Cobweb, 40);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}