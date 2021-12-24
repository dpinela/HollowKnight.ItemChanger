// Lifted from Flib's SkillUpgrades mod.
using System;
using HutongGames.PlayMaker;

namespace ItemChanger.FsmStateActions
{
    public class LambdaEveryFrameB : FsmStateAction
    {
        private readonly Action<bool> _method;

        /// <summary>
        /// FsmStateAction to execute the given method every frame. The method will be passed true the first frame, and false on subsequent frames.
        /// Differs from LambdaEveryFrame in that the latter does not run
        /// on the first frame.
        /// </summary>
        public LambdaEveryFrameB(Action<bool> method)
        {
            _method = method;
        }

        public override void OnEnter()
        {
            try
            {
                _method(true);
            }
            catch (Exception e)
            {
                LogError("Error in ExecuteLambdaEveryFrame (OnEnter):\n" + e);
            }
        }

        public override void OnUpdate()
        {
            try
            {
                _method(false);
            }
            catch (Exception e)
            {
                LogError("Error in ExecuteLambdaEveryFrame (OnUpdate):\n" + e);
            }
        }
    }
}