using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class Crocus : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 51;
			Item.DamageType = DamageClass.Magic;
			Item.width = 38;
			Item.height = 44;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2.75f;
			Item.value = Item.sellPrice(0, 6);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.CrocusProj>();
			Item.shootSpeed = 18f;
			Item.noMelee = true;
			Item.mana = 6;
			Item.UseSound = SoundID.Item43;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpellTome);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 16);
			recipe.AddIngredient(ItemID.Vine, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}