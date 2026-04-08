using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Projectiles.Tomes;

namespace Zylon.Items.Swords
{
	public class Bloodshed : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 24;
			Item.DamageType = DamageClass.Melee;
			Item.width = 80;
			Item.height = 84;
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3.5f;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.crit = 4;
		}
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			if (target.HasBuff(ModContent.BuffType<Buffs.Debuffs.OpenWounds>()) && hit.Crit) {
				float dir = player.Center.DirectionTo(target.Center).ToRotation();

				if (Main.myPlayer == player.whoAmI) for (int i = 0; i < Main.rand.Next(2, 5); i++)
					Projectile.NewProjectile(player.GetSource_FromThis(), target.Center, new Vector2(0, Main.rand.Next(-8, -5)).RotatedBy(dir + MathHelper.ToRadians(Main.rand.NextFloat(-30f, 30f) + 90f)), ModContent.ProjectileType<Projectiles.Swords.BloodshedProj>(), damageDone/5, 0f, player.whoAmI);
			}
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.OpenWounds>(), Main.rand.Next(2, 5)*60);
        }
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.OpenWounds>(), Main.rand.Next(2, 5)*60);
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