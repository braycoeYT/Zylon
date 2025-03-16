﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Whips
{
	public class DarkstrandDebuff : ModBuff
	{
		public static readonly int TagDamage = 6;
		public override void SetStaticDefaults() {
			BuffID.Sets.IsATagBuff[Type] = true;
		}
	}
	public class DarkstrandAdvancedDebuff : ModBuff
	{
		public static readonly int TagDamagePercent = 30;
		public static readonly float TagDamageMultiplier = TagDamagePercent / 100f;
		public override void SetStaticDefaults() {
			BuffID.Sets.IsATagBuff[Type] = true;
		}
	}
	public class DarkstrandDebuffNPC : GlobalNPC
	{
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers) {
			if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
				return;

			var projTagMultiplier = ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
			if (npc.HasBuff<DarkstrandDebuff>()) {
				modifiers.FlatBonusDamage += DarkstrandDebuff.TagDamage * projTagMultiplier;
			}

			if (npc.HasBuff<DarkstrandAdvancedDebuff>()) {
				modifiers.ScalingBonusDamage += DarkstrandAdvancedDebuff.TagDamageMultiplier * projTagMultiplier;
				npc.RequestBuffRemoval(ModContent.BuffType<DarkstrandAdvancedDebuff>());
			}
		}
	}
}