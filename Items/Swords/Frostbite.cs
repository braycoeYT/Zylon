using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Frostbite : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 77;
			Item.DamageType = DamageClass.Melee;
			Item.width = 54;
			Item.height = 54;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6.2f;
			Item.value = Item.sellPrice(0, 3, 98);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.FrostbiteProj>();
			Item.shootSpeed = 16f;
		}
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(3, 8), false);
		}
		public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
			target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(3, 8), false);
		}
		int shootCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			if (shootCount % 2 == 0) SoundEngine.PlaySound(SoundID.Item84, position); //EVIL CODE MWHAHAH
			shootCount++;
			return shootCount % 2 == 1;
		}
        public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, DustID.Ice);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
		public override void AddRecipes()  {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IceBlade);
			recipe.AddRecipeGroup("Zylon:AnyAdamantiteBar", 6);
			recipe.AddIngredient(ItemID.SoulofMight, 8);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}