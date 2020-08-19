using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Cyanix.Pills
{
	public class CyanixPill : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Gives the user 'Cyanix Boost', which increases your stats\nDefense is decreased\nThere is a 60 second cooldown between usage\nStrength: 4");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 22;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
			item.value = 200;
			item.rare = 1;
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
			player.AddBuff(mod.BuffType("CyanixBoost"), 900);
			else
			player.AddBuff(mod.BuffType("CyanixBoost"), 1200);
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("LesserCyanixPill"), 2);
			recipe.AddIngredient(mod.ItemType("BraycoeSludge"));
			recipe.AddIngredient(ItemID.Bone);
			recipe.AddTile(13);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}
}