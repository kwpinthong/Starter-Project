using UnityEngine;

namespace StarterProject.CommandLib
{
    public class MoveCommand : Command
    {
        public Transform Transform;
        public Vector3 Direction;
        public float Speed = 1f;

        public MoveCommand(Transform transform, Vector3 direction, float speed)
        {
            Transform = transform;
            Direction = direction;
            Speed = speed;
        }

        public override void Execute()
        {
            MoveReceiver.Receive(this);
        }

        public override void Undo()
        {
        }
    }
}
