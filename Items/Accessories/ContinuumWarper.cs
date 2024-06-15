using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Zylon.Items.Accessories
{
	public class ContinuumWarper : ModItem
	{
		public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 4)); //first is speed, second is amount of frames
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		public override void SetDefaults() {
			Item.width = 16;
			Item.height = 38;
			Item.value = Item.sellPrice(0, 4);
			Item.rare = ItemRarityID.Lime;
			Item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetDamage(DamageClass.Generic) -= 0.15f;
            p.continuumWarper = true;
        }
	}
}