using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Accessories
{
	public class ManaBattery : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 36;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 1);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.statMana < 20 && !player.HasBuff(ModContent.BuffType<Buffs.Accessories.ManaRechargeCooldown>())) {
				SoundEngine.PlaySound(SoundID.Item27);
				player.ManaEffect(player.statManaMax2-player.statMana);
				player.statMana = player.statManaMax2;
				player.AddBuff(ModContent.BuffType<Buffs.Accessories.ManaRechargeCooldown>(), 30*60);
            }
		}
	}
}