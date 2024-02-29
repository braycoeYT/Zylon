using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Guns
{
	public class AdeniteSecurityHandgun : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.damage = 22;
			Item.width = 26;
			Item.height = 24;
			Item.knockBack = 2f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 18f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Green;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
        public override void UpdateInventory(Player player) {
            if (Main.remixWorld) {
				Item.damage = 5;
				Item.knockBack = 0.5f;
				Item.rare = ItemRarityID.Gray;
				Item.value = Item.sellPrice(0, 0, 0, 1);
				Item.shootSpeed = 12f;
            }
        }
        int shootNum;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootNum++;
			if (shootNum % 3 == 0) {
				SoundEngine.PlaySound(SoundID.Item96, position);
				Projectile.NewProjectile(source, position, velocity*1.3f, ModContent.ProjectileType<Projectiles.ElectricBoltPassive>(), (int)(damage*1.5f), knockback, Main.myPlayer, 1f);
			}
			return shootNum % 3 != 0;
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
			recipe.AddIngredient(ModContent.ItemType<OvergrownHandgunFragment>());
			recipe.AddIngredient(ModContent.ItemType<Materials.AdeniteCrumbles>(), 16);
            recipe.AddIngredient(ModContent.ItemType<Materials.SearedStone>(), 27);
			recipe.AddIngredient(ItemID.Obsidian, 12);
            recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Condition.NotRemixWorld);
			recipe.Register();
		}
	}
}