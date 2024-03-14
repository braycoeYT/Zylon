using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class Dartshark : ModItem
	{
		public override void SetStaticDefaults() {
			if (DateTime.Now.Month == 4 && DateTime.Now.Day == 1 && ModContent.GetInstance<ZylonConfig>().aprilFoolsChanges) {
				// DisplayName.SetDefault("Dartshart");
				// Tooltip.SetDefault("Barrages enemies with taco bell\nUses seeds as ammo (symbolizes the seeds of intestinal damage sown by the taco bell)");
            }
		}
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 11;
			Item.knockBack = 1f;
			Item.shootSpeed = 11f;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.UseSound = SoundID.Item64;
			Item.value = Item.sellPrice(0, 2);
			Item.autoReuse = true;
			if (DateTime.Now.Month == 4 && DateTime.Now.Day == 1 && ModContent.GetInstance<ZylonConfig>().aprilFoolsChanges) {
				Item.damage = 1;
			}
			Item.rare = ItemRarityID.Orange;
		}
		public override bool AltFunctionUse(Player player) {
			return true;
		}
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return Main.rand.Next(3) < 2;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -4);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.EerieBell>(), 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.OtherworldlyFang>(), 14);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}