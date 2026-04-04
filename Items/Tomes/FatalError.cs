using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Tomes
{
	public class FatalError : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 81;
			Item.DamageType = DamageClass.Magic;
			Item.width = 30;
			Item.height = 36;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5f;
			Item.value = Item.sellPrice(0, 4, 60);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.FatalErrorProj>();
			Item.shootSpeed = 14f;
			Item.noMelee = true;
			Item.mana = 12;
			Item.UseSound = SoundID.Item8;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Bars.DarkronBar>(), 12);
			recipe.AddIngredient(ItemType<Materials.SoulofByte>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}