using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Zylon.Items.Materials;

namespace Zylon.Items.Dyes
{
	public class OnyxDye : ModItem
	{
		public override void SetStaticDefaults() {
			if (!Main.dedServ)
			{
				GameShaders.Armor.BindShader(
					Item.type,
					new ArmorShaderData(new Ref<Effect>(Mod.Assets.Request<Effect>("Assets/Effects/OnyxDye", AssetRequestMode.ImmediateLoad).Value), "OnyxDyePass").UseColor(140 / 255f, 100 / 255f, 177 / 255f).UseSecondaryColor(355 / 255f, 255 / 255f, 355 / 255f)
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
			recipe.AddIngredient(ModContent.ItemType<OnyxShard>(), 6);
			recipe.AddTile(TileID.DyeVat);
			recipe.Register();
		}

	}
}