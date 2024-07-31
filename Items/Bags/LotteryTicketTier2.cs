using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bags
{
	public class LotteryTicketTier2 : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.BossBag[Type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
		}
		public override void SetDefaults() {
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.buyPrice(0, 12, 50);
		}
		public override bool CanRightClick() {
			return true;
		}
        public override void RightClick(Player player) { //Bought for 12.5 gold
            float rand = Main.rand.NextFloat();
			if (rand < 0.01f) { //1% chance
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.PlatinumCoin);
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.GoldCoin, 25);
				if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Vector2(0, -10), ProjectileID.RocketFireworkBlue, 0, 0f);
			}
			else if (rand < 0.1f) { //9% chance
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.GoldCoin, 25);
			}
			else if (rand < 0.3f) { //20% chance
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.GoldCoin, 12);
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.SilverCoin, 50);
			}
			else if (rand < 0.6f) { //30% chance
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.GoldCoin, 6);
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.SilverCoin, 25);
			}
			else if (rand < 0.8f) { //20% chance
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.GoldCoin, 3);
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.SilverCoin, 75);
			}
			else if (rand < 0.9f) { //10% chance
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.GoldCoin, 2);
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.SilverCoin, 50);
			}
			else if (rand < 0.95f) { //5% chance
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.GoldCoin);
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.SilverCoin, 25);
			}
			else if (rand < 0.995f) { //4.5% chance
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.SilverCoin, 50);
			}
			else { //0.5% chance
				Item.NewItem(Item.GetSource_FromThis(), player.getRect(), ItemID.CopperCoin, 1);
			}
        }
	}
}