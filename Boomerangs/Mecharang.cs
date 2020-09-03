using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class Mecharang : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Pew pew pew");
		}

		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 49;
			item.width = 45;
			item.height = 45;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 1.5f;
			item.value = 72000;
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Mecharang");
			item.shootSpeed = 17;
			item.crit = 6;
			item.noUseGraphic = true;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot) {
                    return false;
                }
            }
            return true;
        }
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 13);
			recipe.AddIngredient(ItemID.SoulofMight, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}