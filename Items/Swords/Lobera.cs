using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Lobera : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Hits will slash the enemy's soul, causing their defense to be halved\nStriking foes will rain tropical orbs upon them");
		}
		public override void SetDefaults() {
			Item.damage = 67;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.width = 58;
			Item.height = 58;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 7.1f;
			Item.value = Item.sellPrice(0, 18, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item93;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.LoberaProj>();
			Item.shootSpeed = 6f;
		}
		bool SwingSide = false;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			if (SwingSide == true)
            {
				Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Swords.LoberaProj>(), damage, knockback, player.whoAmI, 0, 0);
			} else
            {
				Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Swords.LoberaProj>(), damage, knockback, player.whoAmI, 0, 1);
			}

			SwingSide = !SwingSide;

			return false;
        }
        /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            if (player.direction == 0) position.X -= 6;
			else position.X += 6;
			return true;
        }*/
        public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, ModContent.DustType<Dusts.LoberaDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void AddRecipes()  {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(ItemID.PixieDust, 30);
			recipe.AddIngredient(ItemID.SoulofMight, 8);
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}