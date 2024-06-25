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
			Item.potion = true;
		}
        public override bool CanUseItem(Player player) {
            return !player.HasBuff(BuffID.PotionSickness);
        }
        public override bool? UseItem(Player player) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			//player.AddBuff(BuffID.ManaSickness, 150);
			p.fixCooldownIgnore = true;
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