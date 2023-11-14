using Sirenix.OdinInspector;
using UnityEngine;

namespace IdleRestaurant
{
    public class Chair : MonoBehaviour
    {
        public bool IsEmpty => Customer == null;

        public Customer Customer;
    }
}
