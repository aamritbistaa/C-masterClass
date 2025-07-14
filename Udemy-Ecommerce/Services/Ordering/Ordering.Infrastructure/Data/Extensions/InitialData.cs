using System;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Extensions;

internal static class InitialData
{
    public static IEnumerable<Customer> Customers => new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("166b43c2-e5f7-4797-8c75-0255167b2600")), name: "Amrit Bista", email: "aamritbistaa@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("eb8bb6c7-34ce-4919-a470-8370e429bd1f")), name: "Test User 1", email: "testuser1@gmail.com"),
    };

    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("b210daf3-0652-45b6-9fa4-40f4005e6d28")), "Sony 50mm f1.8", 158.00m),
        Product.Create(ProductId.Of(new Guid("60920263-8649-4b7b-a195-414d37fcadc4")), "Viltrox 35mm f1.7", 129.00m),
        Product.Create(ProductId.Of(new Guid("90402174-e252-44e7-aab4-642e7160c03d")), "Sony A6400", 750.00m),
    };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("Amrit", "Bista", "aamritbistaa@gmail.com", "Mandikatar, Kathmandu", "Nepal", "Bagmati", "33333");
            var address2 = Address.Of("Test", "User 1", "testuser1@gmail.com", "test, test", "Test", "Test", "11111");

            var payment1 = Payment.Of("Amrit Bista", "123-723-23", "2027-01-01", "4444", 1);
            var payment2 = Payment.Of("Test User 1", "123-723-29", "2027-10-01", "3333", 2);

            var order1 = Order.Create(
                id: OrderId.Of(Guid.NewGuid()),
                customerId: CustomerId.Of(new Guid("166b43c2-e5f7-4797-8c75-0255167b2600")),
                orderName: OrderName.Of("Order 1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment: payment1
            );
            order1.Add(ProductId.Of(new Guid("b210daf3-0652-45b6-9fa4-40f4005e6d28")), 1, 139.00m);
            order1.Add(ProductId.Of(new Guid("90402174-e252-44e7-aab4-642e7160c03d")), 1, 750.00m);


            var order2 = Order.Create(
                id: OrderId.Of(Guid.NewGuid()),
                customerId: CustomerId.Of(new Guid("eb8bb6c7-34ce-4919-a470-8370e429bd1f")),
                orderName: OrderName.Of("Order 2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment: payment2
            );

            order2.Add(ProductId.Of(new Guid("90402174-e252-44e7-aab4-642e7160c03d")), 1, 750.00m);
            order2.Add(ProductId.Of(new Guid("60920263-8649-4b7b-a195-414d37fcadc4")), 1, 129.00m);


            return new List<Order> { order1, order2 };
        }
    }
}
