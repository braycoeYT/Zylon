using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Projectiles.Swords;

namespace Zylon.Items.Swords
{
	public class AlbinoMandiblade : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 51;
			Item.DamageType = DamageClass.Melee;
			Item.width = 64;
			Item.height = 64;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.75f;
			Item.value = Item.sellPrice(0, 12);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
		}
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			if (player.ownedProjectileCounts[ModContent.ProjectileType<AlbinoMandibladeProj>()] < 10 && player.whoAmI == Main.myPlayer && target.type != NPCID.TargetDummy)
				Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, Vector2.Zero, ModContent.ProjectileType<AlbinoMandibladeProj>(), (int)(damageDone*0.67f), Item.knockBack, player.whoAmI, target.Center.X, target.Center.Y, target.whoAmI);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AntlionClaw);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpectralFairyDust>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}