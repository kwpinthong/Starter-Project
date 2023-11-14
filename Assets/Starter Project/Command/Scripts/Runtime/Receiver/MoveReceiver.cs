using System.Collections;
using UnityEngine;

namespace StarterProject.CommandLib
{
    public class MoveReceiver : MonoBehaviour
    {
        private static MoveReceiver _instance;

        public static void Receive(MoveCommand moveCommand)
        {
            _instance._Move(moveCommand);
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }

        private void _Move(MoveCommand moveCommand)
        {
            StartCoroutine(_DoMoving(moveCommand));
        }

        private IEnumerator _DoMoving(MoveCommand moveCommand)
        {
            var _transform = moveCommand.Transform;
            var _direction = moveCommand.Direction;
            var _speed = moveCommand.Speed;
            _transform.Translate(_direction * _speed * Time.deltaTime);
            yield return null;
        }
    }
}
