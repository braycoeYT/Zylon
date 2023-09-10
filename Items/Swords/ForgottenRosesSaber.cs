using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class ForgottenRosesSaber : ModItem
	{

		public override void SetDefaults() {
			Item.damage = 87;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 51;
			Item.useAnimation = 51;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 7.6f;
			Item.value = Item.sellPrice(0, 16, 50);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.scale = 1.3f;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.MegaRose>();
			Item.shootSpeed = 12f;
		}
        public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool()) Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.CarnalliteDust>());
            rot++;
        }
        public override bool AltFunctionUse(Player player) {
			return true;
		}
        public override bool CanUseItem(Player player) {
			if (rot > 360) rot = 0;
			if (player.altFunctionUse == 2) {
				Item.useTurn = !Item.useTurn;
				CombatText.NewText(player.getRect(), Color.DarkGreen, Item.useTurn.ToString());
			}
			return !(player.altFunctionUse == 2);
		}
		int shootCount;
		int rot;
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			if (target.type != NPCID.TargetDummy) Projectile.NewProjectile(player.GetSource_FromThis(), target.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Swords.MiniRose2>(), Item.damage/4, Item.knockBack/4, Main.myPlayer, rot, target.whoAmI);
        }
		int shootCount2;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount2++;
			if (!(shootCount2 % 2 == 0)) return false;
			shootCount++;
			int jimbo = 0;
			if (shootCount % 3 == 0) jimbo = 1;
			Projectile.NewProjectile(source, position, velocity, type, (int)(damage*0.4f), knockback, Main.myPlayer, jimbo);
			SoundEngine.PlaySound(SoundID.Item69, position);
			return false;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CarnalliteCutlass>());
			recipe.AddIngredient(ItemID.ChlorophyteSaber);
			recipe.AddIngredient(ItemID.JungleRose);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 20);
			recipe.AddIngredient(ItemID.BeetleHusk, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}