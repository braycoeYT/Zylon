using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
	public class Cabin : ModItem
	{
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			Tooltip.SetDefault("'Sit by the fire as you melt away your worries...'\nCan only be used if there are no bosses alive, and you have not damaged anything for 30 seconds");
=======
			// Tooltip.SetDefault("'Sit by the fire as you melt away your worries...'\nCan only be used if there are no bosses alive, and you have not damaged anything for 30 seconds");
>>>>>>> ProjectClash
		}
		public override void SetDefaults() {
			Item.width = 38;
			Item.height = 32;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 50);
			Item.rare = ItemRarityID.Lime;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 99;
			Item.UseSound = SoundID.Item2;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.potion = true;
			Item.healLife = 250;
		}
        public override bool CanUseItem(Player player) {
            for (int x = 0; x < Main.maxNPCs; x++)
				if (Main.npc[x].boss == true) return false;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			//if (p.hitTimer30 > 0) CombatText.NewText(player.getRect(), Color.Red, "Wait " + (p.hitTimer30/60) + " seconds!");
			return p.hitTimer30 < 1;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe(3);
			recipe.AddIngredient(ModContent.ItemType<Tent>(), 3);
			recipe.AddRecipeGroup("Wood", 8);
			recipe.AddIngredient(ItemID.Torch);
			recipe.AddIngredient(ItemID.GlowingMushroom, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}