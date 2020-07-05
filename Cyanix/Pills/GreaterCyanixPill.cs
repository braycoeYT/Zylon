using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Cyanix.Pills
{
	public class GreaterCyanixPill : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Gives the user 'Greater Cyanix Boost', which increases your stats\nDefense is decreased a lot\nThere is a 60 second cooldown between usage\nStrength: 7");
		}

		public override void SetDefaults() 
		{
			item.width = 33;
			item.height = 33;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
			item.value = 1000;
			item.rare = 3;
			item.autoReuse = true;
			item.useTurn = true;
			item.noMelee = true;
			item.maxStack = 9999;
			item.UseSound = SoundID.Item2;
			item.noUseGraphic = true;
			item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return !Main.LocalPlayer.HasBuff(mod.BuffType("CyanixCooldown"));
		}
		
		public override bool UseItem(Player player)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.cyanixShort == true)
			player.AddBuff(mod.BuffType("CyanixCooldown"), 2700);
			else
			player.AddBuff(mod.BuffType("CyanixCooldown"), 3600);
			if (p.CyanixLong == true)
			player.AddBuff(mod.BuffType("GreaterCyanixBoost"), 900);
			else
			player.AddBuff(mod.BuffType("GreaterCyanixBoost"), 1200);
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CyanixPill"), 2);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(mod.ItemType("SoulOfByte"));
			recipe.AddTile(13);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}
}