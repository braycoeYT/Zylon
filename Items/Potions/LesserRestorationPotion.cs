using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
	public class LesserRestorationPotion : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;
		}
		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 26;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 1);
			Item.rare = ItemRarityID.White;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 9999;
			Item.UseSound = SoundID.Item3;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.healLife = 45;
			Item.healMana = 45;
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
			Recipe recipe = CreateRecipe(2);
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(ItemID.PinkGel);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpeckledStardust>());
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}