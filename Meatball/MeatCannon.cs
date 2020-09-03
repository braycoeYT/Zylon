using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Meatball
{
	public class MeatCannon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Uses seed shots as ammo\nMay launch a meatball along with the seedshot\nWhile in your inventory, the following enemies will drop Seeds:\nMeatball");
		}
		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 38; //9
			item.knockBack = 3.8f; //3.5
			item.shootSpeed = 12.3f; //11
			item.useTime = 36; //45
			item.useAnimation = 36; //45
			item.rare = ItemRarityID.Blue;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
            if (p.UpgradeMeatball)
			{
				if (Main.rand.Next(10) == 0)
				Projectile.NewProjectile(player.position, new Vector2((float)(speedX * 1.2), (float)(speedY * 1.2)), mod.ProjectileType("MeatballBig"), item.damage, item.knockBack, Main.myPlayer);
			}
			else
			{
				if (Main.rand.Next(10) == 0)
				Projectile.NewProjectile(player.position, new Vector2((float)(speedX * 1.2), (float)(speedY * 1.2)), mod.ProjectileType("Meatball"), item.damage, item.knockBack, Main.myPlayer);
			}
			return true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(0, -6);
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