using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.MagicGuns
{
	public class AdeniteSecurityElectrifier : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 22;
			Item.DamageType = DamageClass.Magic;
			Item.width = 33;
			Item.height = 33;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1.2f;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.ElectricBoltPassive>();
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.mana = 6;
			Item.UseSound = SoundID.Item91;
		}
        public override void UpdateInventory(Player player) {
            if (Main.remixWorld) {
				Item.damage = 4;
				Item.knockBack = 0.5f;
				Item.rare = ItemRarityID.Gray;
				Item.value = Item.sellPrice(0, 0, 0, 1);
				Item.mana = 1;
            }
        }
        int shootNum;
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (shootNum % 3 == 2)
				type = ModContent.ProjectileType<Projectiles.MagicGuns.ElectricBoltPassiveExplode>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootNum++;
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, 2f);
			return false;
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
			recipe.AddIngredient(ModContent.ItemType<OvergrownElectricalComponent>());
			recipe.AddIngredient(ModContent.ItemType<Materials.AdeniteCrumbles>(), 16);
            recipe.AddIngredient(ModContent.ItemType<Materials.SearedStone>(), 27);
			recipe.AddIngredient(ItemID.Obsidian, 12);
            recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Condition.NotRemixWorld);
			recipe.Register();
		}
	}
}