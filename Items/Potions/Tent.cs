using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
	public class Tent : ModItem
	{
		public override void SetStaticDefaults() { //j our next step is to add 13 tents, with all of them being carbon copies of each other but they all heal slightly more than the last
<<<<<<< HEAD
			Tooltip.SetDefault("'Does not keep the mosquitoes out...'\nCan only be used if there are no bosses alive, and you have not damaged anything for 30 seconds");
=======
			// Tooltip.SetDefault("'Does not keep the mosquitoes out...'\nCan only be used if there are no bosses alive, and you have not damaged anything for 30 seconds");
>>>>>>> ProjectClash
		}
		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 24;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 50);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 99;
			Item.UseSound = SoundID.Item2;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.potion = true;
			Item.healLife = 125;
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
			recipe.AddIngredient(ItemID.Silk, 8);
			recipe.AddIngredient(ItemID.Mushroom, 2);
			recipe.AddIngredient(ItemID.Gel);
			recipe.AddTile(TileID.Loom);
			recipe.Register();

			recipe = CreateRecipe(3);
			recipe.AddIngredient(ItemID.TatteredCloth, 8);
			recipe.AddIngredient(ItemID.Mushroom, 2);
			recipe.AddIngredient(ItemID.Gel);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
	}
}