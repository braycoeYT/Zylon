using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Swords
{
	public class EightLegs : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Every third swing releases a Spider Egg that explodes into Venom Fangs a few seconds after landing\nStriking enemies will lay Spider Eggs within them\nUp to three enemy-laid eggs can be active at once\nTrue melee hits and Venom Fangs inflict Acid Venom");
		}
		public override void SetDefaults() {
			Item.damage = 54;
			Item.DamageType = DamageClass.Melee;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6.1f;
			Item.value = Item.sellPrice(0, 1, 50);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.SpiderEgg>();
			Item.shootSpeed = 12f;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool()) Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Web);
		}
        int swingCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            swingCount++;
			if (swingCount % 3 == 0) SoundEngine.PlaySound(SoundID.Item83, position);
			return swingCount % 3 == 0;
        }
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
			target.AddBuff(BuffID.Venom, Main.rand.Next(5, 8)*60);
		}
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Venom, Main.rand.Next(5, 8)*60);
			int counter = 0;
			for (int x = 0; x < Main.maxProjectiles; x++) {
				if (Main.projectile[x].type == ModContent.ProjectileType<Projectiles.Swords.SpiderEggInvis>()) counter++;
            }
			if (counter < 3) Projectile.NewProjectile(player.GetSource_FromThis(), target.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Swords.SpiderEggInvis>(), Item.damage, Item.knockBack, Main.myPlayer, target.whoAmI);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyMythrilBar", 12);
			recipe.AddIngredient(ItemID.SpiderFang, 14);
			recipe.AddIngredient(ItemID.SoulofNight, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}