using System.Collections.Generic;
using UnityEngine;

namespace IdleRestaurant
{
    public class Customers : MonoBehaviour
    {
        private static Customers _instance;

        public static void AddNewCustomer(Chair emptyChair)
        {
            _instance._AddNewCustomer(emptyChair);
        }

        public static void RemoveCustomer(Customer customer)
        {
            _instance._RemoveCustomer(customer);
        }

        [SerializeField] private Customer customerPrefab;
        [SerializeField] private List<Customer> customers = new List<Customer>();
        private List<Customer> pool = new List<Customer>();

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }

        private void _AddNewCustomer(Chair emptyChair)
        {
            var newCustomer = pool.Find(c => c.gameObject.activeSelf == false);
            if (newCustomer == null)
            {
                newCustomer = Instantiate(customerPrefab, transform);
                pool.Add(newCustomer);
            }
            else
            {
                newCustomer.gameObject.SetActive(true);
            }
            emptyChair.Customer = newCustomer;
            newCustomer.Chair = emptyChair;
            newCustomer.transform.position = Restaurant.FontDoor.position;
            customers.Add(newCustomer);
        }

        private void _RemoveCustomer(Customer customer)
        {
            customer.Chair.Customer = null;
            customer.Chair = null;
            customers.Remove(customer);
        }
    }
}
