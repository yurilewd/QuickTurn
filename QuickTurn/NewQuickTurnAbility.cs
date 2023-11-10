using Reptile;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECM.Common;

namespace QuickTurn
{
    public class NewQuickTurnAbility : Ability
    {
        public static float savedSpeed;
        public static float turnTimer = 0f;
        public static float cooldown = 0f;

        public NewQuickTurnAbility(Player player) : base(player) { }

        public override void Init()
        {
            normalRotation = false;
            allowNormalJump = false;
        }

        public override void OnStartAbility()
        {
            savedSpeed = p.GetForwardSpeed();
            p.PlayAnim(Animator.StringToHash("boostBrake"), false, false, -1f);
            p.SetForwardSpeed(p.GetForwardSpeed() * QuickTurnPlugin.abilitySpeed.Value);
            p.SetDustEmission(50);
            p.SetDustSize(0.5f);
            turnTimer = 0f;
        }

        public override void FixedUpdateAbility()
        {
            turnTimer += Core.dt;

            if (turnTimer >= QuickTurnPlugin.delay.Value)
            {
                if (p.isJumping && !p.IsGrounded())
                {
                    p.StopCurrentAbility();
                }

                if (p.jumpButtonNew)
                {
                    DoTheThing(QuickTurnPlugin.jumpDirection.Value, QuickTurnPlugin.turnAngleJump.Value, QuickTurnPlugin.returnedSpeedJump.Value);

                    p.Jump();
                    p.ForceUnground(true);
                }

                if (p.slideButtonNew)
                {
                    DoTheThing(QuickTurnPlugin.slideDirection.Value, QuickTurnPlugin.turnAngleSlide.Value, QuickTurnPlugin.returnedSpeedSlide.Value);
                    p.ActivateAbility(p.slideAbility);
                }

                if (p.AnyTrickInput())
                {
                    p.ActivateAbility(p.groundTrickAbility);
                    if (p.CheckBoostTrick())
                    {
                        DoTheThing(QuickTurnPlugin.boostTrickDirection.Value, QuickTurnPlugin.turnAngleBoostTrick.Value, QuickTurnPlugin.returnedSpeedBoostTrick.Value);
                    }
                    else
                    {
                        DoTheThing(QuickTurnPlugin.trickDirection.Value, QuickTurnPlugin.turnAngleTrick.Value, QuickTurnPlugin.returnedSpeedTrick.Value);
                    }
                }
            }

            if (turnTimer >= 0.5f)
            {
                p.SetDustEmission(0);
                p.SetDustSize(1f);
            }

            if (turnTimer >= 0.65f)
            {
                p.StopCurrentAbility();
            }
        }

        public override void OnStopAbility()
        {
            cooldown = QuickTurnPlugin.cooldown.Value;
            turnTimer = 0f;
            p.SetDustEmission(0);
            p.SetDustSize(1f);
        }

        public void PassiveUpdate()
        {
            if (cooldown > 0) { cooldown -= Core.dt; }
            float sens = Remap(QuickTurnPlugin.sens.Value, 0f, 1f, -1f, 0f);

            if (Vector3.Dot(p.dir, p.moveInput) <= sens 
                && (p.ability == null || p.ability == p.slideAbility || p.ability == p.boostAbility)
                && p.IsGrounded()
                && p.GetForwardSpeed() >= QuickTurnPlugin.minimumSpeed.Value
                && cooldown <= 0f)
            {
                p.ActivateAbility(this);
            }
        }

        public void DoTheThing(QuickTurnPlugin.Direction direction, float maxAngle, float speed)
        {
            float exitDirection = 1f;
            if (direction == QuickTurnPlugin.Direction.Backward) { exitDirection = -1f; }

            p.SetRotHard(Vector3.RotateTowards(p.forward * exitDirection, p.moveInput, maxAngle * Mathf.Deg2Rad, 0.0f));
            p.SetForwardSpeed(savedSpeed * speed);
            p.ringParticles.Emit(1);
        }

        public static float Remap(float val, float in1, float in2, float out1, float out2)
        {
            return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
        }
    }
}
