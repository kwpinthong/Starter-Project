using System.Collections.Generic;
using UnityEngine;

namespace StarterProject.CommandLib
{
    public class CommandInvoker : MonoBehaviour
    {
        private static CommandInvoker _instance;

        public static void AddCommand(Command command)
        {
            _instance._commandQueue.Enqueue(command);   
        }
        
        private Queue<Command> _commandQueue = new Queue<Command>();

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }

        private void Update()
        {
            if (_commandQueue.Count > 0)
            {
                var _cmd = _commandQueue.Dequeue();
                _cmd.Execute();
            }
        }
    }
}
