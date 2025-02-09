using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
	public class BottledLava : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;
		}
		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 26;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 0, 4);
			Item.rare = ItemRarityID.White;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 9999;
			Item.UseSound = SoundID.Item3;
			Item.noUseGraphic = true;
			Item.consumable = true;
		}
        public override bool CanUseItem(Player player) {
            return !player.HasBuff(BuffID.PotionSickness);
        }
        public override bool? UseItem(Player player) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			
			if (!player.HasBuff(BuffID.ObsidianSkin)) {
				String deathMessage = "";
				switch (Main.rand.Next(3)) {
					case 0:
						deathMessage = " is extremely stupid.";
						break;
					case 1:
						deathMessage = " melted their intestines.";
						break;
					case 2:
						deathMessage = " cured their indigestion.";
						break;
					}
				player.Hurt(PlayerDeathReason.ByCustomReason(player.name + deathMessage), 80, player.direction*-1, false, false, -1, false, 0, 0, 2f);
				player.AddBuff(BuffID.OnFire, 7*60);
			}
            return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddCondition(Condition.NearLava);
			recipe.Register();
		}
	}
}