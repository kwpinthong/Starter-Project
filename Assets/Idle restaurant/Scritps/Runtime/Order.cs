using System;

namespace IdleRestaurant
{
    [Serializable]
    public class Order
    {
        public Customer Customer;
        public Menu Menu;
    }
}
