using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Contagional
{
	public class HiveVirus : ContagionalItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("HIV(E) Virus");
			Tooltip.SetDefault("'Most monsters don't have a cure for this'\n~~~50% chance of inflicting poison for 4 seconds\n~~~10% chance of inflicting venom for 3 seconds");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 11;
			item.width = 33;
			item.height = 33;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 5753;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("HiveVirus");
			item.shootSpeed = 10;
			item.crit = 4;
			ContagionalResourceCost = 5;
			item.noUseGraphic = true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}