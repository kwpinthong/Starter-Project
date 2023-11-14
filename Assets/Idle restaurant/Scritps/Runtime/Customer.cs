using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace IdleRestaurant
{
    public class Customer : MonoBehaviour
    {
        public Chair Chair;
        public List<Order> Orders = new List<Order>();
        public List<Food> Foods = new List<Food>();

        public void ReceiveFood(Food food)
        {
            Foods.Add(food);
            Restaurant.ReceivePayment(food.Menu.Price);
        }

        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private int minOrder = 1;
        [SerializeField] private int maxOrder = 3;

        private void Start()
        {
            navMeshAgent.updateUpAxis = false;
            navMeshAgent.updateRotation = false;
        }

        private void OnEnable()
        {
            StartCoroutine(GoSitting());
        }

        private void OnDisable()
        {
            Orders.Clear();
            Foods.Clear();
            StopAllCoroutines();
        }

        private IEnumerator GoSitting()
        {
            yield return new WaitUntil(() => Chair != null);
            navMeshAgent.SetDestination(Chair.transform.position);
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
            MakeOrder();

        }

        private void MakeOrder()
        {
            var menus = Restaurant.GetMenus();
            int orderCount = Random.Range(minOrder, maxOrder);
            for(int i = 0; i < orderCount; i++)
            {
                var menu = menus[Random.Range(0, menus.Count)];
                Orders.Add(new Order()
                {
                    Customer = this,
                    Menu = menu,
                });
            }
            Restaurant.ReceiveOrders(Orders);
            StartCoroutine(WaitingForFood());
        }

        private IEnumerator WaitingForFood()
        {
            yield return new WaitUntil(() => Foods.Count == Orders.Count);
            StartCoroutine(ExitRestaurant());
        }

        private IEnumerator ExitRestaurant()
        {
            Customers.RemoveCustomer(this);
            navMeshAgent.SetDestination(Restaurant.FontDoor.transform.position);
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
            gameObject.SetActive(false);
        }
    }
}
