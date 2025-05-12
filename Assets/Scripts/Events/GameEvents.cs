using SimpleEventBus.SimpleEventBus.Runtime;
using SimpleGame.General;

namespace SimpleGame.Events
{
    public class ScoreChangedEvent : IEvent
    {
        public int Score;
    }
    
    public class GatesPassedEvent : IEvent
    {
    }

    public class CarRequestedEvent : IEvent
    {
    }

    public class SpeedRequestedEvent : IEvent
    {
    }
    
    public class IncomeRequestedEvent : IEvent
    {
    }

    public class SpawnCarEvent : IEvent
    {
    }

    public class UpgradeSpeedEvent : IEvent
    {
    }
    
    public class UpgradeIncomeEvent : IEvent
    {
    }

    public abstract class PriceChanged : IEvent
    {
        public int Price;

        protected PriceChanged(int price)
        {
            Price = price;
        }
    }

    public class CarPriceChanged : PriceChanged
    {
        public CarPriceChanged(int price) : base(price)
        {
        }
    }

    public class SpeedPriceChanged : PriceChanged
    {
        public SpeedPriceChanged(int price) : base(price)
        {
        }
    }

    public class IncomePriceChanged : PriceChanged
    {
        public IncomePriceChanged(int price) : base(price)
        {
        }
    }
    
    public class SoundRequestEvent : IEvent
    {
        public ESoundType SoundType;
    }
}