using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Empress
{
	public class Eggspray : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Eggspray");
			Tooltip.SetDefault("Shoots slow moving eggs which shoot venomous orbs");
			//Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 67;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 31;
			item.useAnimation = 31;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 2.5f;
			item.value = 500000;
			item.rare = ItemRarityID.Lime;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("TelomireEgg");
			item.shootSpeed = 4f;
			item.noMelee = true;
			item.mana = 9;
			item.stack = 1;
			item.UseSound = SoundID.Item1;
		}
	}
}