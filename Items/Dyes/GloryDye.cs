using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Zylon.Items.Materials;

namespace Zylon.Items.Dyes
{
	public class GloryDye : ModItem
	{
		public override void SetStaticDefaults() {
			if (!Main.dedServ)
			{
				GameShaders.Armor.BindShader(
					Item.type,
					new ArmorShaderData(new Ref<Effect>(Mod.Assets.Request<Effect>("Assets/Effects/GloryDye", AssetRequestMode.ImmediateLoad).Value), "GloryDyePass").UseColor(248f / 255f, 108f / 255f, 88f / 255f).UseSecondaryColor(159f / 255f, 22f / 255f, 22f / 255f)
				);
			}

			Item.ResearchUnlockCount = 3;
		}
		public override void SetDefaults() {
			int dye = Item.dye;

			Item.CloneDefaults(ItemID.GelDye);

			Item.rare = ItemRarityID.Green;
			Item.dye = dye;
			Item.sellPrice(0, 0, 5, 20);
		}

        public override void AddRecipes()
        {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GloryPetals>(), 6);
			recipe.AddTile(TileID.DyeVat);
			recipe.Register();
        }
    }
}