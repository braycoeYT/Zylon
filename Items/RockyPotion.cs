using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items
{
	public class RockyPotion : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gives a ton of defense at the cost of attack and speed. Melee and throwing are not as affected as the other classes.");
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
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 3;
            item.value = 250;
            item.buffType = mod.BuffType("Rocky");
            item.buffTime = 21600;
        }
    }
}