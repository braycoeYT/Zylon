using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Minions
{
	public class GoocatStaff : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 32;
			Item.knockBack = 2f;
			Item.mana = 10;
			Item.width = 66;
			Item.height = 66;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(0, 6, 89);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item44;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;
			Item.buffType = BuffType<Buffs.Minions.Goocat>();
			Item.shoot = ProjectileType<Projectiles.Minions.Goocat>();
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			player.AddBuff(Item.buffType, 2);
			Projectile.NewProjectile(source, Main.MouseWorld, velocity, type, damage, knockback, Main.myPlayer);
			return false;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 6);
			recipe.AddIngredient(ItemType<Materials.ElementalGoop>(), 12);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.PixieDust, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}