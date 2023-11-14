using UnityEngine;

namespace StarterProject.CommandLib
{
    public class YellCommand : Command
    {
        public string Message;

        public YellCommand(string message)
        {
            Message = message;
        }

        public override void Execute()
        {
            Debug.Log(Message);
        }

        public override void Undo()
        {
        }
    }
}
