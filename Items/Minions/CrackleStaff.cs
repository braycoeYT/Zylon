using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Minions
{
	public class CrackleStaff : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 28;
			Item.knockBack = 4f;
			Item.mana = 10;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(0, 4, 37);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item44;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;
			Item.buffType = BuffType<Buffs.Minions.Crackle>();
			Item.shoot = ProjectileType<Projectiles.Minions.Crackle>();
			Item.autoReuse = true;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			player.AddBuff(Item.buffType, 2);
			Projectile.NewProjectile(source, Main.MouseWorld, velocity, type, damage, knockback, Main.myPlayer);
			return false;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyCobaltBar", 8);
			recipe.AddIngredient(ItemID.Cloud, 20);
			recipe.AddIngredient(ItemID.RainCloud, 10);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpectralFairyDust>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}