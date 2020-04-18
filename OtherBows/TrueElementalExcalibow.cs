using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherBows
{
	public class TrueElementalExcalibow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("True Elemental Excalibow");
			Tooltip.SetDefault("'Pew pew pew pew pew!'\n35% Chance to not consume ammo\nLeft click to shoot current arrow\nRight click to shoot a high quality random elemental arrow");
		}

		public override void SetDefaults() 
		{
			item.value = 219584;
			item.useStyle = 5;
			item.useAnimation = 5;
			item.useTime = 5;
			item.damage = 117;
			item.width = 12;
			item.height = 24;
			item.knockBack = 2f;
			item.shoot = 1;
			item.shootSpeed = 14f;
			item.noMelee = true;
			item.ranged = true;
			item.crit = 16;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.rare = 11;
		}
		
		public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            if (player.altFunctionUse == 2)
            {
				int ran = Main.rand.Next(1, 8);
                if (ran == 1) type = 357;
				if (ran == 2) type = 706;
				if (ran == 3) type = 631;
				if (ran == 4) type = 639;
				if (ran == 5) type = 278;
				if (ran == 6) type = 282;
				if (ran == 7) type = mod.ProjectileType("DreamsdayArrow");
				if (ran == 8) type = 225;
				if (ran == 8) type = 710;
			}
            else
            {
                item.shoot = 1;
            }
            return true;
        }
		
		public override bool ConsumeAmmo(Player player)
        {
			if (Main.rand.NextFloat() < .35f)
            return false;
			else
			return true;
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ElementalExcalibow"));
			recipe.AddIngredient(2223);
			recipe.AddIngredient(1229);
			recipe.AddIngredient(3854);
			recipe.AddIngredient(3540);
			recipe.AddIngredient(2624);
			recipe.AddIngredient(3859);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 4);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 6);
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"), 10);
			recipe.AddIngredient(ItemID.FragmentVortex, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}