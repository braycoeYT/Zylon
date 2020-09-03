using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Empress
{
	public class EmpressTears : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Empress Tears");
			Tooltip.SetDefault("Shoots tears that confuse enemies\nTears can change direction randomly");
			//Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 79;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1.9f;
			item.value = 500000;
			item.rare = ItemRarityID.Lime;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("EmpressTear");
			item.shootSpeed = 6f;
			item.noMelee = true;
			item.mana = 8;
			item.maxStack = 1;
			item.UseSound = SoundID.Item1;
		}
	}
}