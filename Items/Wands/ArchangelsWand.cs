using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class ArchangelsWand : ModItem
	{
		public override void SetStaticDefaults() {
			Item.staff[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 51;
			Item.width = 56;
			Item.height = 58;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4.5f;
			Item.value = Item.sellPrice(0, 4, 96);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.ArchangelsWandProj>();
			Item.shootSpeed = 6f;
			Item.noMelee = true;
			Item.mana = 10;
			Item.stack = 1;
			Item.UseSound = SoundID.NPCHit5;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PearlstoneBlock, 39);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpectralFairyDust>(), 4);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}