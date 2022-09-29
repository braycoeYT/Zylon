using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class Crumblegun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires bullets at high velocity");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 25);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 27;
			Item.useTime = 27;
			Item.damage = 16;
			Item.width = 40;
			Item.height = 16;
			Item.knockBack = 3.6f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 30f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Blue;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.DiskiteCrumbles>(), 9);
			recipe.AddIngredient(ModContent.ItemType<Materials.RustedTech>(), 11);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}