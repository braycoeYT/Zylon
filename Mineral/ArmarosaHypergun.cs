using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class ArmarosaHypergun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("En...en...enchanted...\nShoots a crystal every four shots\n20% chance to not consume ammo");
		}

		public override void SetDefaults()  {
			item.value = Item.sellPrice(0, 12, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 5;
			item.useTime = 5;
			item.damage = 89;
			item.width = 12;
			item.height = 24;
			item.knockBack = 2.2f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = ItemRarityID.Purple;
			item.noMelee = true;
		}
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override Vector2? HoldoutOffset() {
			return new Vector2(-3, 0);
		}
		int swingCount;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			swingCount++;
			if (swingCount % 4 == 0)
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("GemstoneSpike"), damage, knockBack, player.whoAmI);
			return true;
		}
		public override bool ConsumeAmmo(Player player) {
			if (Main.rand.NextFloat() < .2f)
            return false;
			else
			return true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ArmagrisFirearms"));
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 10);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}