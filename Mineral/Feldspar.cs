using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class Feldspar : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("True melee hits do 125% damage and inflict xenic acid on enemies\nShoots a giant crystal orb that splits into two smaller orbs");
		}
		public override void SetDefaults()  {
			item.damage = 444;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 44;
			item.useAnimation = 44;
			item.useStyle = 1;
			item.knockBack = 4.4f;
			item.value = 425000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("GemstoneOrbLarge");
			item.shootSpeed = 14f;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override bool UseItem(Player player) {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(item.position, item.width, item.height, 58);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
			return true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			damage += (int)(damage / 4);
			target.AddBuff(mod.BuffType("XenicAcid"), 240, false);
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			damage += (int)(damage / 4);
			target.AddBuff(mod.BuffType("XenicAcid"), 240, false);
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(item.position, item.width, item.height, 58);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PurplePhasesaber);
			recipe.AddIngredient(ItemID.OrichalcumSword);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}