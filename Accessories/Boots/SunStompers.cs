using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Boots
{
	public class SunStompers : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sun Stompers");
			Tooltip.SetDefault("Allows flight, insanely fast running, and extra mobility on ice\nProvides the ability to walk on water and lava\nGrants immunity to fire blocks and 10 seconds of immunity to lava\nGrants the ability to swim and greatly extends underwater breathing\nProvides extreme light underwater and some light on land\nTurns the holder into a werewolf at night and a merfolk when entering water\nHide accessory to disable visual transformations\nMinor increases to all stats\n+2/3 seconds of wingtime\n15% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 675000;
			item.rare = 9;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			player.accRunSpeed = 11f;
			player.rocketBoots = 3;
			player.moveSpeed += 0.15f;
			player.iceSkate = true;
			
			player.waterWalk = true;
			player.fireWalk = true;
			player.lavaMax += 600;
			
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
		
			player.wingTimeMax += 40;
			
			player.accMerman = true;
			player.wolfAcc = true;
			if (player.hideVisual[3])
			{
				player.hideMerman = true;
				player.hideWolf = true;
			}
			player.meleeSpeed += 0.1f;
			player.meleeDamage += 0.1f;
			player.meleeCrit += 2;
			player.rangedDamage += 0.1f;
			player.rangedCrit += 2;
			player.magicDamage += 0.1f;
			player.magicCrit += 2;
			player.pickSpeed -= 0.15f;
			player.minionDamage += 0.1f;
			player.minionKB += 0.5f;
			player.thrownDamage += 0.1f;
			player.thrownCrit += 2;
			modPlayer.ContagionalDamageMult += 0.1f;
			modPlayer.ContagionalCrit += 2;
			
			player.maxRunSpeed += 0.5f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MaelstromBoots"));
			recipe.AddIngredient(3110);
			recipe.AddIngredient(ItemID.SoulofFlight, 40);
			recipe.AddIngredient(2766, 10);
			recipe.AddIngredient(1101, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}