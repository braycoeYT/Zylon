using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Cyanix
{
	public class CyanixGun : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cyanix Pistol");
			Tooltip.SetDefault("50% Chance to not consume ammo");
		}

		public override void SetDefaults() 
		{
			item.value = 500;
			item.useStyle = 5;
			item.useAnimation = 6;
			item.useTime = 6;
			item.damage = 2;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1.5f;
			item.shoot = 14;
			item.shootSpeed = 30f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.crit = 6;
		}
		
		public override bool ConsumeAmmo(Player player)
        {
			if (Main.rand.NextFloat() < .5f)
            return false;
			else
			return true;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CyanixBar"), 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}