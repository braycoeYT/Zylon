using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class AdeniteSecurityBlade : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Every third swing releases an electric bolt");
		}
		public override void SetDefaults() {
			Item.damage = 28;
			Item.DamageType = DamageClass.Melee;
			Item.width = 36;
			Item.height = 38;
			Item.useTime = 31;
			Item.useAnimation = 31;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3.6f;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.ElectricBoltPassive>();
			Item.shootSpeed = 15f;
		}
        public override void UpdateInventory(Player player) {
            if (Main.remixWorld) {
				Item.damage = 7;
				Item.knockBack = 1f;
				Item.rare = ItemRarityID.Gray;
				Item.value = Item.sellPrice(0, 0, 0, 1);
            }
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            knockback /= 2;
        }
        int shootNum;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootNum++;
			if (shootNum % 3 == 0)
				SoundEngine.PlaySound(SoundID.Item96, position);
			return shootNum % 3 == 0;
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, DustID.Electric);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<OvergrownHilt>());
			recipe.AddIngredient(ModContent.ItemType<Materials.AdeniteCrumbles>(), 16);
            recipe.AddIngredient(ModContent.ItemType<Materials.SearedStone>(), 27);
			recipe.AddIngredient(ItemID.Obsidian, 12);
            recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Condition.NotRemixWorld);
			recipe.Register();
		}
	}
}