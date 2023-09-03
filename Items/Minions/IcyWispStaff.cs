using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Minions
{
	public class IcyWispStaff : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Summons icy wisps to fight for you\nSpawns two wisps that share a single minion slot");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}

		public override void SetDefaults() {
			Item.damage = 9;
			Item.knockBack = 0.5f;
			Item.mana = 10;
			Item.width = 46;
			Item.height = 46;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(0, 0, 5, 12);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item44;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;
			Item.buffType = BuffType<Buffs.Minions.IcyWisp>();
			Item.shoot = ProjectileType<Projectiles.Minions.IcyWisp>();
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			//Main.NewText(player.slotsMinions.ToString()+"/"+player.maxMinions.ToString(), Color.White);
			
			player.AddBuff(Item.buffType, 2);
			position = Main.MouseWorld;
			//if (player.maxMinions - player.slotsMinions > 0f)
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.IcyWisp>()]);
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.IcyWisp>()]+1);
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.EnchantedIceCube>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}