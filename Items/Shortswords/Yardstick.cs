using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Shortswords
{
	public class Yardstick : ModItem
	{
        public override void SetDefaults() {
			Item.damage = 42;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 3.4f;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.shoot = ProjectileType<Projectiles.Shortswords.Yardstick>();
			Item.shootSpeed = 5.1f;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(25f));
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Ruler);
			recipe.AddRecipeGroup("Wood", 16);
			recipe.AddIngredient(ItemID.SoulofLight);
			recipe.AddIngredient(ItemID.SoulofNight);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}