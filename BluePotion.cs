using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items
{
	public class BluePotion : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Only for those who are wor- just kidding. Gives a random vanilla buff/debuff");
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 14;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 9999;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = 250;
            item.buffType = 1 + Main.rand.Next(205);
            item.buffTime = 600;
        }
		
		public override bool UseItem(Player player)
		{
			item.buffType = 1 + Main.rand.Next(205);
			return true;
		}
    }
}