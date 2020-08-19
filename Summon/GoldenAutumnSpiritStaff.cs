using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Summon
{
	public class GoldenAutumnSpiritStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Autumn Staff");
			Tooltip.SetDefault("Summons a golden autumn spirit to fight for you\nTesting item, may not work correctly");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 78;
			item.knockBack = 2.9f;
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
			item.buffType = BuffType<Buffs.Minions.GoldenAutumnSpirit>();
			item.shoot = ProjectileType<Projectiles.Minions.GoldenAutumn.GoldenAutumnSpirit>();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
		/*public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GlowingMushtopStaff"));
			recipe.AddIngredient(mod.ItemType("DreamString"), 12);
			recipe.AddIngredient(ItemID.Wood, 100);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}