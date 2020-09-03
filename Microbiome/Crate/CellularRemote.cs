using Zylon.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome.Crate
{
	public class CellularRemote : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Hacks a cell's nucleus so it will follow you\nThis item can't help you save money on your mobile phone plan");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ProjectileType<Projectiles.Microbiome.Cytocell>();
			item.buffType = BuffType<Buffs.Pets.CytocellBuff>();
			item.mana = 0;
			item.damage = 0;
			item.value = 75000;
			item.rare = ItemRarityID.Green;
			item.width = 28;
			item.height = 40;
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 600, true);
			}
		}
	}
}