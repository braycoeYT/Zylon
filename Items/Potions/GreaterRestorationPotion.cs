using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
	public class GreaterRestorationPotion : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;
		}
		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 28;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 10);
			Item.rare = ItemRarityID.Orange;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 9999;
			Item.UseSound = SoundID.Item3;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.healLife = 135;
			Item.healMana = 135;
		}
        public override bool CanUseItem(Player player) {
            return !player.HasBuff(BuffID.PotionSickness);
        }
        public override bool? UseItem(Player player) {
			if (player.pStone) player.AddBuff(BuffID.PotionSickness, 2025);
			else player.AddBuff(BuffID.PotionSickness, 2700);
			//player.AddBuff(BuffID.ManaSickness, 300);
            return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe(3);
			recipe.AddIngredient(ItemID.RestorationPotion, 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.TabooEssence>());
			recipe.AddIngredient(ModContent.ItemType<Materials.SpectralFairyDust>());
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}