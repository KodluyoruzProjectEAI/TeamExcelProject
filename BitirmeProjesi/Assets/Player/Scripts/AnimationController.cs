using UnityEngine;

namespace Player.Scripts
{
   public class AnimationController : MonoBehaviour
   {
      public Animator animator;
      private static readonly int RunningID = Animator.StringToHash("Running");
      private static readonly int IdleID = Animator.StringToHash("idle");
      private static readonly int InjuredRunID = Animator.StringToHash("Injured");
      private static readonly int DeadID = Animator.StringToHash("Dead");
      private static readonly int DanceID = Animator.StringToHash("Dance");
      private static readonly int SlideRunID = Animator.StringToHash("SlideRun");

      public void Idle()
      {
         animator.SetTrigger(IdleID);
      }
      public void Run()
      {
         animator.SetTrigger(RunningID);
      }
      public void InjuredRun()
      {
         animator.SetTrigger(InjuredRunID);
      }
      public void Dead()
      {
         animator.SetTrigger(DeadID);
      }
      public void Dance()
      {
         animator.SetTrigger(DanceID);
      }
      public void SlideRun()
      {
         animator.SetTrigger(SlideRunID);
      }
   }
}
