using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class BloodyZombieArm : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("'It pulsates nauseatingly...'");
        }
        public override void SetDefaults() {
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.width = 34;
			Item.height = 34;
			Item.useTime = 41;
			Item.useAnimation = 41;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 8.5f;
			Item.value = Item.sellPrice(0, 0, 5);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = false;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ZombieArm);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}