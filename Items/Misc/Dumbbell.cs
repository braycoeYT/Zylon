using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Misc
{
	public class Dumbbell : ModItem //Randomly stopped working but I don't want to fix it rn
	{
		public override void SetDefaults() {
			Item.width = 58;
			Item.height = 58;
			Item.damage = 6;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 42;
			Item.useTime = 42;
			Item.knockBack = 1f;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 1, 62);
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Misc.Dumbbell>();
			Item.shootSpeed = 4f;
		}
		float potential;
		Player me = Main.player[255];
		static float potentialMax = 50;
		public void Potential(Player player) {
			potential = player.statDefense;
			if (potential < 0) potential = 0;
			if (potential > potentialMax) potential = potentialMax;
            potential /= potentialMax;
			Item.damage = 6 + (int)(21*potential);
			Item.knockBack = 1f + (8f*potential);
			Item.shootSpeed = 11f + (7f*potential);
        }
        public override void PreUpdateVanitySet(Player player) {
            //Potential(me);
        }
        public override void UpdateInventory(Player player) {
            me = player;
			//Potential(me);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips) {
			Potential(me);
            TooltipLine line = new TooltipLine(Mod, "Tooltip#0", "Potential: " + Math.Round(potential*100) + "% (" + me.statDefense + "/" + potentialMax + ")");
			tooltips.Add(line);

			foreach (var line2 in tooltips) {
				if (line2.Mod == "Terraria" && line2.Name == "Damage") {
					//float test = me.get
					line2.Text = (Item.damage) + " ranged damage";
				}
			}
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Potential(player);
			velocity.Normalize();
			Projectile.NewProjectile(source, position, velocity*Item.shootSpeed, type, Item.damage, Item.knockBack, Main.myPlayer, potential);
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(ItemID.Chain, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}