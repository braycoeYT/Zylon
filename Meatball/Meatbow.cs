using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Meatball
{
	public class Meatbow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Has a chance to replace arrows with meatballs\nMeatballs may or may not be poisoned...");
		}

		public override void SetDefaults() 
		{
			item.value = 32500;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 14;
			item.useTime = 14;
			item.damage = 19;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1.2f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 6.1f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.useTurn = true;
			item.rare = ItemRarityID.LightRed;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int ran = Main.rand.Next(1, 10);
			
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			
			if (p.UpgradeMeatball)
			{
				if (ran == 1) type = mod.ProjectileType("MeatballBig");
			}
			else
			{
				if (ran == 1) type = mod.ProjectileType("Meatball");
			}
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