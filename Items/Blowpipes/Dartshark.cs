using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class Dartshark : ModItem
	{
        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            if (DateTime.Now.Month == 4 && DateTime.Now.Day == 1 && ModContent.GetInstance<ZylonConfig>().aprilFoolsChanges) {
				foreach (var line3 in tooltips) {
					if (line3.Mod == "Terraria" && line3.Name == "ItemName") {
						line3.Text = "Dartshart";
					}
				}
				TooltipLine line = new TooltipLine(Mod, "Tooltip0", "Barrages enemies with taco bell");
				TooltipLine line2 = new TooltipLine(Mod, "Tooltip1", "The seeds as ammo symbolize the seeds of intestinal damage sown by the taco bell");
				tooltips.Add(line);
				tooltips.Add(line2);
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
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            if (DateTime.Now.Month == 4 && DateTime.Now.Day == 1 && ModContent.GetInstance<ZylonConfig>().aprilFoolsChanges) {
				Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Blowpipes.PoopFriendly>(), damage, knockback, Main.myPlayer);
				return false;
			}
			return true;
        }
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return Main.rand.NextBool(3);
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