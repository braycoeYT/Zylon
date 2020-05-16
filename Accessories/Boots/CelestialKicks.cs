using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Boots
{
	public class CelestialKicks : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Kicks");
			Tooltip.SetDefault("Allows flight, warpspeed running, and extra mobility on ice\nProvides the ability to walk on water and lava\nGrants immunity to fire blocks and 12 seconds of immunity to lava\nGrants the ability to swim and greatly extends underwater breathing\nProvides extreme light underwater and some light on land\nEffects of holder turning into a werewolf at night and a merfolk when entering water\nVisual transformations are always hidden\nMajor increases to all stats\n+3/4 seconds of wingtime\n20% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 675000;
			item.rare = 10;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.accRunSpeed = 20f;
			player.rocketBoots = 3;
			player.moveSpeed += 0.2f;
			player.iceSkate = true;
			
			player.waterWalk = true;
			player.fireWalk = true;
			player.lavaMax += 720;
			
			player.arcticDivingGear = true;
			player.accFlipper = true;
			player.accDivingHelm = true;
			player.iceSkate = true;
			if (player.wet)
			{
				Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, 0.4f, 1.6f, 1.8f);
			}
			else
			Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, 0.2f, 0.8f, 0.9f);
		
			player.wingTimeMax += 45;
			
			player.accMerman = true;
			player.wolfAcc = true;
			player.hideMerman = true;
			player.hideWolf = true;
			player.meleeSpeed += 0.08f;
			player.meleeDamage += 0.08f;
			player.meleeCrit += 4;
			player.rangedDamage += 0.08f;
			player.rangedCrit += 4;
			player.magicDamage += 0.08f;
			player.magicCrit += 4;
			player.pickSpeed -= 0.12f;
			player.minionDamage += 0.08f;
			player.minionKB += 1.2f;
			player.thrownDamage += 0.08f;
			player.thrownCrit += 4;
			
			player.maxRunSpeed += 1f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SunStompers"));
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentStardust);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(mod.ItemType("DreamString"), 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}