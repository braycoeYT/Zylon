using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Meatball
{
	public class BleedingGun : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bleeding Gun");
			Tooltip.SetDefault("10% Chance to not consume ammo");
		}

		public override void SetDefaults() 
		{
			item.value = 500;
			item.useStyle = 5;
			item.useAnimation = 16;
			item.useTime = 10;
			item.damage = 10;
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
		}
		
		public override bool ConsumeAmmo(Player player)
        {
			if (Main.rand.NextFloat() < .1f)
            return false;
			else
			return true;
        }
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MeatShard"), 20);
			recipe.AddIngredient(mod.ItemType("PlainNoodle"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}