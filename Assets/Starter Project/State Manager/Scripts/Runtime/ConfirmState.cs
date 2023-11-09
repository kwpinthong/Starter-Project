using Sirenix.OdinInspector;
using StarterProject.UIFramework;
using System.Collections;
using UnityEngine;

namespace StarterProject.StateLib
{
    public class ConfirmState : State
    {
        [Required]
        public ConfirmPanel ConfirmPanel;
        [TextArea]
        public string Message;

        public override void Enter()
        {
            ConfirmPanel.Message = Message;
            base.Enter();
        }
    }
}
