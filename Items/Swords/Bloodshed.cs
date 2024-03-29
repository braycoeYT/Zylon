using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Bloodshed : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 39;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.9f;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
		}
        int rotHit;
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
			rotHit++;
			for (int i = 0; i < 4; i++) Projectile.NewProjectile(player.GetSource_FromThis(), target.Center - new Vector2(0, -120).RotatedBy(MathHelper.ToRadians(rotHit*5+i*90)), new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(rotHit*5+i*90)), ModContent.ProjectileType<Projectiles.Swords.BloodOrb>(), Item.damage/3, Item.knockBack/2, Main.myPlayer);
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			rotHit++;
			for (int i = 0; i < 4; i++) Projectile.NewProjectile(player.GetSource_FromThis(), target.Center - new Vector2(0, -120).RotatedBy(MathHelper.ToRadians(rotHit*5+i*90)), new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(rotHit*5+i*90)), ModContent.ProjectileType<Projectiles.Swords.BloodOrb>(), Item.damage/3, Item.knockBack/2, Main.myPlayer);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bone, 55);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 20);
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}