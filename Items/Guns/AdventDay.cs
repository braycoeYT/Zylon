using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class AdventDay : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Advent's Day");
			Tooltip.SetDefault("'Guns and violence are all I need'\nConverts regular bullets to nano bullets");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 5);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 11;
			Item.useTime = 11;
			Item.damage = 67;
			Item.width = 36;
			Item.height = 22;
			Item.knockBack = 1.6f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 12.6f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Yellow;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (type == ProjectileID.Bullet) type = ProjectileID.NanoBullet;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BeetleHusk, 6);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 20);
			recipe.AddIngredient(ItemID.Nanites, 50);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}