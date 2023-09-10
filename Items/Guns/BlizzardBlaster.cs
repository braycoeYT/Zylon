using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class BlizzardBlaster : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("33% chance not to consume ammo\nRapidly blasts snowballs");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 6);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 23;
			Item.useTime = 23;
			Item.damage = 98;
			Item.width = 36;
			Item.height = 22;
			Item.knockBack = 4.7f;
			Item.shoot = ProjectileID.SnowBallFriendly;
			Item.shootSpeed = 15f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Snowball;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Lime;
		}
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return !Main.rand.NextBool(3);
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SnowballCannon);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 12);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}