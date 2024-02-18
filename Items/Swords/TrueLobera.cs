using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class TrueLobera : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 79;
			Item.DamageType = DamageClass.Melee;
			Item.width = 34;
			Item.height = 60;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5f;
			Item.value = Item.sellPrice(0, 7, 19);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item93;
			Item.autoReuse = true;
		}
        public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, ModContent.DustType<Dusts.LoberaDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void AddRecipes()  {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Lobera>());
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(ItemID.PixieDust, 23);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}