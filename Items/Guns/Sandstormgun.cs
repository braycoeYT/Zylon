using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class Sandstormgun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Spread the sand!'");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 6);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 14;
			Item.useTime = 14;
			Item.damage = 65;
			Item.width = 36;
			Item.height = 22;
			Item.knockBack = 2.6f;
			Item.shoot = ProjectileID.SandBallGun;
			Item.shootSpeed = 13f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Sand;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Lime;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Sandgun);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 12);
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}