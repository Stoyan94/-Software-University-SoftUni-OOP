
using ResturantExample;

Waiter waiter = new Waiter(new MoleucalarKitches());

while (true)
{
    waiter.TakeOrder(Console.ReadLine());
}
