using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Guns
{
	public class TimewarpAssaultRifle : ModItem
	{

		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 5, 75, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 16;
			Item.useTime = 4;
			Item.damage = 31;
			Item.width = 56;
			Item.height = 20;
			Item.knockBack = 1f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 10.5f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			//Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Lime;
			Item.reuseDelay = 12;
			Item.consumeAmmoOnLastShotOnly = true;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            type = ModContent.ProjectileType<Projectiles.Guns.ClockworkBit>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			SoundEngine.PlaySound(SoundID.Item41, position);
            return true;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
			recipe.AddIngredient(ItemID.HallowedBar, 16);
			recipe.AddIngredient(ItemID.Cog, 100);
			recipe.AddIngredient(ItemID.GoldWatch);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
			recipe.AddIngredient(ItemID.HallowedBar, 16);
			recipe.AddIngredient(ItemID.Cog, 100);
			recipe.AddIngredient(ItemID.PlatinumWatch);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}