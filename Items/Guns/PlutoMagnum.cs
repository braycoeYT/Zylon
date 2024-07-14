using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Guns
{
	public class PlutoMagnum : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 13);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 13;
			Item.useTime = 13;
			Item.damage = 161;
			Item.width = 62;
			Item.height = 28;
			Item.knockBack = 4.25f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 15f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item38;
			Item.autoReuse = true;
			Item.rare = ModContent.RarityType<PurpleModded>();
		}
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return Main.rand.NextBool();
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (type == ProjectileID.Bullet) type = ModContent.ProjectileType<Projectiles.Guns.UltraHighVelocityBullet>();
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.VenusMagnum);
			recipe.AddIngredient(ItemID.LunarBar, 12);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}