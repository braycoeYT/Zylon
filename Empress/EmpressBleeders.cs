using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Empress
{
	public class EmpressBleeders : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Empress Bleeders");
			Tooltip.SetDefault("Each bleeder can steal life\nHitting an enemy will ricochet in the oppisite direction for less damage\nThis can continue until the bleeder does less than 1 damage");
		}

		public override void SetDefaults() 
		{
			item.damage = 54;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 2.4f;
			item.value = 500000;
			item.rare = ItemRarityID.Lime;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("EmpressBleeders");
			item.shootSpeed = 8f;
			item.noMelee = true;
			item.maxStack = 1;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
	}
}