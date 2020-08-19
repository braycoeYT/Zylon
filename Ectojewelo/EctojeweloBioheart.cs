using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Ectojewelo
{
	public class EctojeweloBioheart : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ectojewelo Bioheart");
			Tooltip.SetDefault("Use this to increase max health by 25\nOne time use\nFighters of the Calamity need not apply\nAwakeners of the Elements need not apply");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = 6500000;
			item.rare = ItemRarityID.Purple;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			Mod CalamityMod = ModLoader.GetMod("CalamityMod");
			if (CalamityMod == null)
			{
				Mod EA = ModLoader.GetMod("EA");
				if (EA == null)
				{
					return player.statLifeMax == 500 && player.GetModPlayer<ZylonPlayer>().upgradeHearts < 1;
				}
			}
			return false;
		}

		public override bool UseItem(Player player)
		{
			player.statLifeMax2 += 25;
			player.statLife += 25;
			if (Main.myPlayer == player.whoAmI)
			{
				player.HealEffect(25, true);
			}
			player.GetModPlayer<ZylonPlayer>().upgradeHearts += 1;
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 20);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 10);
			recipe.AddIngredient(ItemID.LifeFruit, 3);
			recipe.AddIngredient(mod.ItemType("XenicCore"));
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}