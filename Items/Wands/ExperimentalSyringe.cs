using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class ExperimentalSyringe : ModItem
	{
        public override void SetStaticDefaults() {
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 71;
			Item.DamageType = DamageClass.Magic;
			Item.width = 64;
			Item.height = 64;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.4f;
			Item.value = Item.sellPrice(0, 6, 23);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item64.WithPitchOffset(0.5f);
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.ExperimentalSyringeProj>();
			Item.shootSpeed = 15f;
			Item.mana = 6;
			Item.noMelee = true;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10f));
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Accessories.MagicalVaccine>());
			recipe.AddIngredient(ModContent.ItemType<Materials.Oozeberry>(), 13);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
    }
}