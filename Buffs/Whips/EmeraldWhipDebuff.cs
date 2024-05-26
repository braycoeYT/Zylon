﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Whips
{
	public class EmeraldWhipDebuff : ModBuff
	{
		public static readonly int TagDamage = 3;
		public override void SetStaticDefaults() {
			BuffID.Sets.IsATagBuff[Type] = true;
		}
	}
	public class EmeraldWhipAdvancedDebuff : ModBuff
	{
		public static readonly int TagDamagePercent = 30;
		public static readonly float TagDamageMultiplier = TagDamagePercent / 100f;
		public override void SetStaticDefaults() {
			BuffID.Sets.IsATagBuff[Type] = true;
		}
	}
	public class EmeraldWhipDebuffNPC : GlobalNPC
	{
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers) {
			if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
				return;

			var projTagMultiplier = ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
			if (npc.HasBuff<EmeraldWhipDebuff>()) {
				modifiers.FlatBonusDamage += EmeraldWhipDebuff.TagDamage * projTagMultiplier;
			}

			if (npc.HasBuff<EmeraldWhipAdvancedDebuff>()) {
				modifiers.ScalingBonusDamage += EmeraldWhipAdvancedDebuff.TagDamageMultiplier * projTagMultiplier;
				npc.RequestBuffRemoval(ModContent.BuffType<EmeraldWhipAdvancedDebuff>());
			}
		}
	}
}