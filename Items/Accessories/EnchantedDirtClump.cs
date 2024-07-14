using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Items.Accessories
{
	public class EnchantedDirtClump : ModItem
	{
		public override void SetDefaults() {
			//Item.CloneDefaults(ItemID.EoCShield);
			Item.width = 28;
			Item.height = 28;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Gray;
			Item.expert = true;
			Item.damage = 1;
			//Item.DamageType = DamageClass.Summon;
			//Item.defense = 1;
			//Item.knockBack = 0.5f;
		}
        /*public override void ModifyTooltips(List<TooltipLine> tooltips) {
            foreach (var line in tooltips) {
				if (line.Mod == "Terraria" && line.Name == "Defense") {
					line.Hide();
				}
			}
        }*/
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			if (WorldGen.currentWorldSeed.ToLower() == "autumn") texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/EnchantedDirtClump_Autumn");
			spriteBatch.Draw(texture, position, frame, drawColor, 0f, origin, scale, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			if (WorldGen.currentWorldSeed.ToLower() == "autumn") texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/EnchantedDirtClump_Autumn");
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;
			spriteBatch.Draw(texture, drawPos, null, lightColor, rotation, frameOrigin, scale, SpriteEffects.None, 0);
			return false;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
			//player.statDefense -= 1;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.dirtballExpert = true;
			player.AddBuff(ModContent.BuffType<Buffs.Minions.DirtBlock>(), 60);
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>()] < 5 && player.whoAmI == Main.myPlayer)
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>(), Item.damage, 0.5f, Main.myPlayer);
		}
        public override void UpdateVanity(Player player) { //No buff needed for visual only.
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.dirtballExpertVanity = true;
			//player.AddBuff(ModContent.BuffType<Buffs.Minions.DirtBlock>(), 60);
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.DirtBlockVanity>()] < 5 && player.whoAmI == Main.myPlayer)
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<Projectiles.Minions.DirtBlockVanity>(), 0, 0f, Main.myPlayer);
        }
    }
}