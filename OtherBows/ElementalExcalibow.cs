using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherBows
{
	public class ElementalExcalibow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Elemental Excalibow");
			Tooltip.SetDefault("'Exoexoexoexoe...PLING!'\n25% Chance to not consume ammo\nLeft click to shoot current arrow\nRight click to shoot a random elemental arrow");
		}

		public override void SetDefaults() 
		{
			item.value = 119565;
			item.useStyle = 5;
			item.useAnimation = 9;
			item.useTime = 9;
			item.damage = 71;
			item.width = 12;
			item.height = 24;
			item.knockBack = 2.5f;
			item.shoot = 1;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.crit = 14;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.rare = 5;
		}
		
		public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            if (player.altFunctionUse == 2)
            {
				int ran = Main.rand.Next(1, 6);
                if (ran == 1) type = 91;
				if (ran == 2) type = 103;
				if (ran == 3) type = 172;
				if (ran == 4) type = 278;
				if (ran == 5) type = 282;
				if (ran == 6) type = 469;
            }
            else
            {
                item.shoot = 1;
            }
            return true;
        }
		
		public override bool ConsumeAmmo(Player player)
        {
			if (Main.rand.NextFloat() < .25f)
            return false;
			else
			return true;
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3029);
			recipe.AddIngredient(3019);
			recipe.AddIngredient(3052);
			recipe.AddIngredient(725);
			recipe.AddIngredient(2888);
			recipe.AddIngredient(ItemID.HallowedBar, 25);
			recipe.AddIngredient(ItemID.SoulofSight, 12);
			recipe.AddIngredient(mod.ItemType("SoulOfByte"), 6);
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"), 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}