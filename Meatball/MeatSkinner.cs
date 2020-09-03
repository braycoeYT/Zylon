using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Meatball
{
	public class MeatSkinner : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Launches meatballs\nMeatballs may or may not be poisoned...");
		}

		public override void SetDefaults() 
		{
			item.damage = 18;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2f;
			item.value = 32500;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item17;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Meatball");
			item.shootSpeed = 10f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			
            if (p.UpgradeMeatball)
			{
				type = mod.ProjectileType("MeatballBig");
			}
			else
			{
				type = mod.ProjectileType("Meatball");
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