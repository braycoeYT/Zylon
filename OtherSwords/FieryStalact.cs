using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSwords
{
	public class FieryStalact : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Burns enemies on crits");
		}

		public override void SetDefaults() 
		{
			item.damage = 30;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = 31540;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (crit)
		    target.AddBuff(BuffID.OnFire, 200, false);
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Stalactite"));
			recipe.AddIngredient(ItemID.HellstoneBar, 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}