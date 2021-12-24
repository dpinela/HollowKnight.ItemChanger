﻿using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace ItemChanger.FsmStateActions
{
    public class DecideToStopSuperdash : ComponentAction<Rigidbody2D>
    {
        private readonly FsmFloat _hSpeed;
        private readonly FsmFloat _vSpeed;
        private readonly FsmBool _zeroLast;

        public DecideToStopSuperdash(FsmFloat hSpeed, FsmFloat vSpeed, FsmBool zeroLast)
        {
            _hSpeed = hSpeed;
            _vSpeed = vSpeed;
            _zeroLast = zeroLast;
        }


        public override void OnEnter()
        {
            try
            {
                UpdateCache(Fsm.FsmComponent.gameObject);
            }
            catch (Exception e)
            {
                LogError("Error in DecideToStopSuperdash (OnEnter/UpdateCache):\n" + e);
            }

            try
            {
                DecideToStop();
            }
            catch (Exception e)
            {
                LogError("Error in DecideToStopSuperdash (OnEnter):\n" + e);
            }
        }

        public override void OnUpdate()
        {
            try
            {
                DecideToStop();
            }
            catch (Exception e)
            {
                LogError("Error in DecideToStopSuperdash (OnUpdate):\n" + e);
            }
        }

        private void DecideToStop()
        {
            Vector2 vector = rigidbody2d.velocity;

            if (Math.Abs(_hSpeed.Value) >= 0.2f && Math.Abs(vector.x) < 0.1f) _zeroLast.Value = true;
            else if (Math.Abs(_vSpeed.Value) >= 0.2f && Math.Abs(vector.y) < 0.1f) _zeroLast.Value = true;
            else _zeroLast.Value = false;
        }
    }
}
