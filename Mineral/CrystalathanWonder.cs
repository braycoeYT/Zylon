using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class CrystalathanWonder : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Rains pink stars");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 12, 0, 0);
			item.useStyle = 5;
			item.useAnimation = 5;
			item.useTime = 5;
			item.damage = 276;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1.5f;
			item.shoot = ProjectileID.StarWrath;
			item.shootSpeed = 27f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = 11;
			item.mana = 7;
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
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			position.X = Main.MouseWorld.X;
			position.Y = player.position.Y - 600;
			speedX = Main.rand.NextFloat(-1, 2);
			speedY = 19;
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpellTome);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 10);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}