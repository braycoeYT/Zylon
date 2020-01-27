using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Snow
{
	public class IceStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ice Staff");
			Tooltip.SetDefault("'The oppisite of the Amber Staff, cold and frosty.'");
		}

		public override void SetDefaults() 
		{
			item.damage = 17;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 4.5f;
			item.value = 1200;
			item.rare = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 118;
			item.shootSpeed = 11.5f;
			item.noMelee = true;
			item.mana = 6;
			item.stack = 1;
			item.UseSound = SoundID.Item8;
			item.crit = 7;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SnowBlock, 5);
			recipe.AddIngredient(ItemID.IceBlock, 5);
			recipe.AddIngredient(mod.ItemType("CryoCrystal"), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}