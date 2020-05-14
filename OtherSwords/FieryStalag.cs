using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSwords
{
	public class FieryStalag : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Burns enemies on crits");
		}

		public override void SetDefaults() 
		{
			item.damage = 28;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = 3;
			item.knockBack = 4.5f;
			item.value = 28005;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.crit = 2;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (crit)
			{
				target.AddBuff(BuffID.OnFire, 200, false);
			}
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Stalagmite"));
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}