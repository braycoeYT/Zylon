using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class BlackSwan : ModItem
	{
        public override void SetStaticDefaults() {
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 61;
			Item.DamageType = DamageClass.Magic;
			Item.width = 70;
			Item.height = 70;
			Item.useTime = 49;
			Item.useAnimation = 49;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2.5f;
			Item.value = Item.sellPrice(0, 9);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.BlackSwanProj>();
			Item.shootSpeed = 12f;
			Item.mana = 21;
			Item.noMelee = true;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            for (int i = 0; i < 8; i++) {
				//Bell curve?
				float rand = 0.25f*Main.rand.NextFloat();
				velocity *= Main.rand.NextFloat(1f-rand, 1f+rand);
				float rand2 = MathHelper.ToRadians(Main.rand.NextFloat(45f));
				Projectile.NewProjectile(source, position+Vector2.Normalize(velocity)*100f, velocity.RotatedByRandom(rand2), type, damage, knockback, Main.myPlayer);
			}
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<UglyDuckling>());
			recipe.AddIngredient(ItemID.SpookyWood, 150);
			recipe.AddIngredient(ItemID.Feather, 30);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<HideousDuckling>());
			recipe.AddIngredient(ItemID.SpookyWood, 150);
			recipe.AddIngredient(ItemID.Feather, 30);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
    }
}