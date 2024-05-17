using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bows
{
	public class RubyBow : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 1);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 31;
			Item.useTime = 31;
			Item.damage = 19;
			Item.width = 22;
			Item.height = 38;
			Item.knockBack = 0.75f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 7f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.rare = ItemRarityID.Blue;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (Main.rand.NextBool(4)) type = ModContent.ProjectileType<Projectiles.Bows.RubyArrow>();
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Cerussite>(), 15);
			recipe.AddIngredient(ItemID.Ruby, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}