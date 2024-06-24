using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Items.Accessories
{
	public class FriendshipBracelet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 4, 92);
			Item.rare = ItemRarityID.Pink;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.friendshipBracelet = true;
			bool protecc = true;
			bool canProtecc = false;
			for (int x = 0; x < Main.maxPlayers; x++) {
				if (Main.player[x] == null || !Main.player[x].active) break;
				ZylonPlayer q = Main.player[x].GetModPlayer<ZylonPlayer>();
				bool cond1 = Vector2.Distance(player.Center, Main.player[x].Center) < 75*16 && q.friendshipBracelet;
				bool cond2 = Vector2.Distance(player.Center, Main.player[x].Center) < 150*16 && q.ultimaBand;
				if (x != player.whoAmI && (cond1 || cond2)) {
					if (Main.player[x].statLife / Main.player[x].statLifeMax2 <= player.statLife / player.statLifeMax2) protecc = false;
					canProtecc = player.statLife < player.statLifeMax2;
				}
            }
			if (protecc && canProtecc) {
				player.statDefense += 20;
				player.lifeRegen += 3;
				if (Main.GameUpdateCount % 20 == 0) {
					for (int x = 0; x < 8; x++) {
						int dustID = DustID.PinkTorch;
						if (x % 2 == 0) dustID = DustID.PurpleTorch;

						int dustIndex = Dust.NewDust(player.position, player.width, player.height, dustID);
						Dust dust = Main.dust[dustIndex];
						dust.velocity = new Vector2(0, 5).RotatedBy(MathHelper.ToRadians(Main.GameUpdateCount/5+(x*45)));
						dust.scale *= 2f;
						dust.noGravity = true;
                    }
                }
            }
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.WhiteString);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}