using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Minions
{
	public class GlowingMushtopStaff : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Summons a glowing mushtop to fight for you");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}

		public override void SetDefaults() {
			Item.damage = 11;
			Item.knockBack = 3f;
			Item.mana = 10;
			Item.width = 46;
			Item.height = 46;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(0, 0, 18);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item44;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;
			Item.buffType = BuffType<Buffs.Minions.GlowingMushtop>();
			Item.shoot = ProjectileType<Projectiles.Minions.GlowingMushtop>();
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			player.AddBuff(Item.buffType, 2);
			Projectile.NewProjectile(source, Main.MouseWorld, velocity, type, damage, knockback, Main.myPlayer);
			return false;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<MushtopStaff>());
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar");
			recipe.AddIngredient(ItemID.GlowingMushroom, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}