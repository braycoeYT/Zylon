using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	[AutoloadEquip(EquipType.Body)]
	public class GemstoneChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The eyes inside are glad you freed them...\nThe eyes are happier when you are doing something\n+3% damage reduction\nHealth and mana are increased by 20\n+5% all crit\nWhen not moving vertically, your defense is heavily increased\nWhen moving quickly vertically, your defense is slightly decreased\nThe negative effects seem worse because of the positive ones happening when you stand still");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 750000;
			item.rare = 11;
			item.defense = 45;
		}
		
		public override void UpdateEquip(Player player)
		{
			if (player.velocity.Y != 0)
			{
				if (player.velocity.Y > 0)
				player.statDefense -= (int)player.velocity.Y;
				else
				player.statDefense -= ((int)player.velocity.Y * -1);
			}
			else
			player.statDefense += 30;
		
			player.allDamage += 0.04f;
			player.statLifeMax2 += 20;
			player.statManaMax2 += 20;
			player.endurance += 0.03f;
			player.meleeCrit += 5;
			player.rangedCrit += 5;
			player.magicCrit += 5;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 25);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 20);
			recipe.AddIngredient(ItemID.Amethyst, 6);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}