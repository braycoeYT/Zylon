using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Swords
{
	public class TrueLobera : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 96;
			Item.DamageType = DamageClass.Melee;
			Item.width = 34;
			Item.height = 60;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.5f;
			Item.value = Item.sellPrice(0, 7, 19);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.TrueLoberaRing>();
			Item.shootSpeed = 11f;
		}
		public override void UpdateInventory(Player player) {
            float hp = (float)player.statLife/(float)player.statLifeMax2;
			Item.damage = 126 - (int)(30*hp);
			Item.knockBack = 10f - 4.5f*hp;
			Item.useTime = 12 + (int)(18*hp);
			Item.useAnimation = 12 + (int)(18*hp);
        }
        int shootCount;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount++;
			float hp = (float)player.statLife/(float)player.statLifeMax2;
			if (shootCount % 2 == 0) {
				if (hp <= 0.25f || hp == 1f) type = ModContent.ProjectileType<Projectiles.Swords.TrueLoberaBeam>();
				SoundEngine.PlaySound(SoundID.Item71, position);
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            }
			return false;
		}
        public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, ModContent.DustType<Dusts.LoberaDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void AddRecipes()  {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Lobera>());
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(ItemID.PixieDust, 23);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}