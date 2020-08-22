using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class SquargeSpitStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Squarge Spit Staff");
			Tooltip.SetDefault("Shoots venomous spit");
			Item.staff[item.type] = true;
		}
		public override void SetDefaults() 
		{
			item.damage = 87;
			item.magic = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 5;
			item.knockBack = 4.5f;
			item.value = 1200;
			item.rare = 7;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("SquargeSpitPassive");
			item.shootSpeed = 11.5f;
			item.noMelee = true;
			item.mana = 8;
			item.stack = 1;
			item.UseSound = SoundID.Item8;
		}
	}
}