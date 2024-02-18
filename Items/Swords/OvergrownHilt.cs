using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Items.Swords
{
	public class OvergrownHilt : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'Only at 0.1% of its true power'");
		}
		public override void SetDefaults() {
			Item.damage = 1;
			Item.DamageType = DamageClass.Melee;
			Item.width = 26;
			Item.height = 28;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 0.8f;
			Item.value = 1;
			Item.rare = ItemRarityID.Gray;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
		}
        public override void UpdateInventory(Player player) {
            if (Main.remixWorld) {
				Item.damage = 174;
				Item.knockBack = 10f;
				Item.shoot = ModContent.ProjectileType<Projectiles.DirtGlobFriendly>();
				Item.shootSpeed = 20f;
				Item.rare = ItemRarityID.Yellow;
				Item.value = Item.sellPrice(0, 5);
            }
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (Main.remixWorld) {
				damage /= 2;
				knockback /= 4;
			}
        }
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, DustID.Dirt);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AdeniteSecurityBlade>());
			recipe.AddIngredient(ItemID.DirtBlock, 100);
            recipe.AddIngredient(ItemID.Ectoplasm, 13);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddCondition(Condition.RemixWorld);
			recipe.Register();
		}
	}
}