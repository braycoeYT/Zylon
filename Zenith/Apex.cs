using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Zenith
{
	public class Apex : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Apex");
			Tooltip.SetDefault("Throws three yoyos that can inflict cursed flames on enemies\nLetting go causes them to fire lots of lasers\nRight click to stop the laser barrage");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 5.1f;
			item.damage = 211; //192
			item.rare = 10;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = 1000000;
			item.shoot = ProjectileType<Projectiles.OtherYoyos.Apex>();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX * -1, speedY * -1, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY * -1, type, damage, knockBack, player.whoAmI);
			return false;
		}
		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Terrarian);
			recipe.AddIngredient(mod.ItemType("EyeOfOblivion"));
			recipe.AddIngredient(ItemID.Kraken);
			recipe.AddIngredient(mod.ItemType("Code3"));
			recipe.AddIngredient(mod.ItemType("Coldnea"));
			recipe.AddIngredient(ItemID.Yelets);
			recipe.AddIngredient(ItemID.FormatC);
			recipe.AddIngredient(ItemID.JungleYoyo);
			recipe.AddIngredient(ItemID.Rally);
			recipe.AddIngredient(ItemID.WoodYoyo);
			recipe.AddIngredient(mod.ItemType("XenicCore"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}