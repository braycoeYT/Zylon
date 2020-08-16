using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Cave
{
	public class FloatingPebbleStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Floating Pebble Staff");
			Tooltip.SetDefault("Summons a floating pebble to fight for you");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 17;
			item.knockBack = 3f;
			item.mana = 10;
			item.width = 38;
			item.height = 38;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.value = 50000;
			item.rare = 1;
			item.UseSound = SoundID.Item44;

			item.noMelee = true;
			item.summon = true;
			item.buffType = BuffType<Buffs.Minions.FloatingPebble>();
			item.shoot = ProjectileType<Projectiles.Cave.FloatingPebble>();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 40);
			recipe.AddIngredient(ItemID.MarbleBlock, 10);
			recipe.AddIngredient(ItemID.GraniteBlock, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}