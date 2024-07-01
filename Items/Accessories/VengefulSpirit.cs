using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Zylon.Items.Accessories
{
	public class VengefulSpirit : ModItem
	{
		public override void SetStaticDefaults() {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 38;
			Item.value = Item.sellPrice(0, 1, 27);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
		}
        public override void Update(ref float gravity, ref float maxFallSpeed) {
            Lighting.AddLight(Item.Center, 0.56f, 0.28f, 1f);
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			p.vengefulSpirit = true;
        }
	}
}