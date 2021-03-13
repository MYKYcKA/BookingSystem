
namespace BookingSystem
{
    public abstract class AbstractViewer
    {
        protected int money;
        public Ticket ticket;
        public int cash
        {
            get => money;
            set => money = value;
        }
        public AbstractViewer()
        {
            money = 0;
            ticket = new Ticket { price = 12, film = "", time = "", row = 1, place = 1 };
        }
        public AbstractViewer(int money, Ticket tick)
        {
            this.money = money;
            ticket = tick;
        }
        public AbstractViewer(int money) : this(money, new Ticket())
        {
        }
        
        public AbstractViewer(AbstractViewer copy)
        {
            money = copy.money;
            ticket = copy.ticket;
        }
    }
}
