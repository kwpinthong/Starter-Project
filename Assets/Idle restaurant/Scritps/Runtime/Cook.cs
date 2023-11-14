using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace IdleRestaurant
{
    public class Cook : MonoBehaviour
    {
        public bool IsWorking { get; set; } = false;

        [SerializeField] private Order _order = null;
        public Order MakingOrder
        {
            get => _order;
            set
            {
                _order = value;
                if (_order != null && IsWorking == false)
                {
                    IsWorking = true;
                    StartCoroutine(DoMakingFood());
                }
            }
        }
        public Food MakingFood = null;

        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Food foodPrefab;

        private void Start()
        {
            navMeshAgent.updateRotation = false;
            navMeshAgent.updateUpAxis = false;
        }

        private IEnumerator DoMakingFood()
        {
            navMeshAgent.SetDestination(Restaurant.WorkingPoint.position);
            yield return new WaitUntil(() => navMeshAgent.hasPath);
            while (true)
            {
                if (navMeshAgent.hasPath && navMeshAgent.remainingDistance > 0f)
                {
                    yield return null;
                }
                else
                {
                    break;
                }
            }
            yield return new WaitForSeconds(MakingOrder.Menu.MakingTime);
            MakingFood = Instantiate(foodPrefab);
            MakingFood.Menu = MakingOrder.Menu;
            StartCoroutine(DoDeliveryFood());
        }

        private IEnumerator DoDeliveryFood()
        {
            var customer = MakingOrder.Customer;
            navMeshAgent.SetDestination(customer.transform.position);
            yield return new WaitUntil(() => navMeshAgent.hasPath);
            while (true)
            {
                if (navMeshAgent.hasPath && navMeshAgent.remainingDistance > 0f)
                {
                    yield return null;
                }
                else
                {
                    break;
                }
            }
            customer.ReceiveFood(MakingFood);
            MakingOrder = null;
            MakingFood = null;
            IsWorking = false;
        }
    }
}
