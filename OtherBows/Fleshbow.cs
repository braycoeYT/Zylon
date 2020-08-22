using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherBows
{
	public class Fleshbow : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Has a chance to replace arrows with lasers");
		}
		public override void SetDefaults() 
		{
			item.value = 150000;
			item.useStyle = 5;
			item.useAnimation = 27;
			item.useTime = 27;
			item.damage = 36;
			item.width = 12;
			item.height = 24;
			item.knockBack = 2f;
			item.shoot = 1;
			item.shootSpeed = 9f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.rare = 4;
		}
		
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            if (Main.rand.Next(10) == 0)
			type = 20;
            return true;
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 11);
			recipe.AddIngredient(ItemID.SoulofSight, 9);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}