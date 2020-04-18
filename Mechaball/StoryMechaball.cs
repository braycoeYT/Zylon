using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mechaball
{
	public class StoryMechaball: ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mechaball Story");
			Tooltip.SetDefault("'After being defeated again, the eye was abducted by a Martian Probe.\nHis friends were left behind.\nThe martians gave it loads of knowledge on everything they knew, from battle strategies to mechanical construction.\nIt tried to rebuild everything it had from Terraria, from its body to its friends.\nSadly, it was held back by the fact it only had metal avalible.\nHis body was a lot stronger now, and his friends were now mechadripplers.\nThe martians were happy to receive new weapons.\nwhen it heard that the martians discovered Terraria, it was ready to fight the Terrarian.'");
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = 0;
			item.rare = 12;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.expert = true;
		}
	}
}