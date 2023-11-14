using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleRestaurant
{
    public class World : MonoBehaviour
    {
        [SerializeField] private bool isOpen = false;
        [SerializeField] private float customerInterval = 1f;
        private float? waitTime;

        private void Update()
        {
            if (isOpen)
            {
                if (waitTime.HasValue && Time.time > waitTime.Value)
                {
                    waitTime = null;
                }

                if (waitTime == null)
                {
                    var emptyChair = Chairs.GetEmptyChair();

                    if (emptyChair != null)
                    {
                        Customers.AddNewCustomer(emptyChair);
                        waitTime = Time.time + customerInterval;
                    }
                }
            }
        }
    }
}
