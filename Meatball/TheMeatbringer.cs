using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Meatball
{
	public class TheMeatbringer : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Meatbringer");
			Tooltip.SetDefault("Bring home the bacon\n50% Chance of shooting meatballs\nMeatballs may or may not be poisoned");
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
			item.knockBack = 1f;
			item.damage = 23;
			item.rare = 3;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = 32500;
			item.shoot = ProjectileType<Projectiles.OtherYoyos.TheMeatbringer>();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int ran = Main.rand.Next(1, 3);
			
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