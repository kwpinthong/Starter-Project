using System.Collections.Generic;
using UnityEngine;

namespace IdleRestaurant
{
    public class Restaurant : MonoBehaviour
    {
        private static Restaurant _instance;

        public static List<Menu> GetMenus()
        {
            return _instance.menus;
        }

        public static void ReceiveOrders(List<Order> orders)
        {
            _instance._ReciveOrders(orders);
        }

        public static void ReceivePayment(int price)
        {
            _instance._ReceivePayment(price);
        }

        public static Transform FontDoor => _instance._fontDoor;
        public static Transform WorkingPoint => _instance._workingPoint;

        [SerializeField] private Transform _fontDoor;
        [SerializeField] private Transform _workingPoint;
        [SerializeField] private long money = 0;
        [SerializeField] private List<Menu> menus;
        [SerializeField] private List<Order> _orders = new List<Order>();

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }

        private void Update()
        {
            if (_orders.Count > 0)
            {
                var emptyCook = Cooks.GetAvailableCook();
                if (emptyCook != null)
                {
                    emptyCook.MakingOrder = _orders[0];
                    _orders.RemoveAt(0);
                }
            }
        }

        private void _ReceivePayment(int price)
        {
            money += price;
        }

        private void _ReciveOrders(List<Order> orders)
        {
            _orders.AddRange(orders);
        }
    }
}
