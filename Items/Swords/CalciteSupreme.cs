using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class CalciteSupreme : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 457;
			Item.DamageType = DamageClass.Melee;
			Item.width = 112;
			Item.height = 112;
			Item.useTime = 47;
			Item.useAnimation = 47;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 7.5f;
			Item.value = Item.sellPrice(1);
			Item.rare = ModContent.RarityType<HBDeusDev>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
			TooltipLine xline = new TooltipLine(Mod, "Tooltip0", "~Developer Item (HBDeus)~");
			xline.OverrideColor = new Color(224, 153, 0);
			list.Add(xline);
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
            if (Main.rand.NextBool(3)) target.AddBuff(BuffID.Confused, Main.rand.Next(8, 13)*60);

			if (Main.myPlayer == player.whoAmI && target.type != NPCID.TargetDummy) for (int i = 0; i < 2; i++)
				Projectile.NewProjectile(player.GetSource_FromThis(), target.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Swords.CalciteSupremeProj>(), damageDone/2, 3f, player.whoAmI, i, target.whoAmI);
			
			if (target.life < 1) for (int i = 0; i < 12; i++)
				Projectile.NewProjectile(player.GetSource_FromThis(), target.Center, new Vector2(0, 12).RotatedBy(MathHelper.ToRadians(i*30)), ModContent.ProjectileType<Projectiles.Swords.CalciteSupremeBoulder>(), damageDone/2, 3.75f, player.whoAmI);
		}
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
            if (Main.rand.NextBool(3)) target.AddBuff(BuffID.Confused, Main.rand.Next(8, 13)*60);
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Stalactite>());
			recipe.AddIngredient(ItemID.Marble, 50);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 8);
			recipe.AddIngredient(ItemID.StoneBlock, 100);
			recipe.AddIngredient(ModContent.ItemType<Materials.FantasticalFinality>(), 13);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
    }
}