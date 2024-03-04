using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
	public class SuperRestorationPotion : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;
		}
		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 30;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 50);
			Item.rare = ItemRarityID.Lime;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 9999;
			Item.UseSound = SoundID.Item3;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.healLife = 180;
			Item.healMana = 180;
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
			Recipe recipe = CreateRecipe(4);
			recipe.AddIngredient(ModContent.ItemType<GreaterRestorationPotion>(), 4);
			recipe.AddIngredient(ModContent.ItemType<Materials.NeutronFragment>());
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>());
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}