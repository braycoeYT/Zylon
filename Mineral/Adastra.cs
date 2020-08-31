using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class Adastra : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("To the stars");
		}
		public override void SetDefaults() 
		{
			item.damage = 186;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 4.3f;
			item.value = Item.sellPrice(0, 12, 0, 0);
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("StarryOrb");
			item.shootSpeed = 20f;
			item.noMelee = true;
			item.mana = 9;
			item.stack = 1;
			item.UseSound = SoundID.Item12;
			item.rare = 12;
		}
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpaceGun);
			recipe.AddIngredient(mod.ItemType("PhoenixDriver"));
			recipe.AddIngredient(ItemID.FallenStar, 20);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 10);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}