using System;

namespace ObserverPattern
{
    // Observador Concreto 3
    // Responde ativamente a ações de compra e venda por meio da variação do IObserver
    public class TradingBot : IObserver
    {
        public string BotName { get; set; }
        public decimal BuyThreshold { get; set; }
        public decimal SellThreshold { get; set; }

        public TradingBot(string botName, decimal buyThreshold, decimal sellThreshold)
        {
            BotName = botName;
            BuyThreshold = buyThreshold;
            SellThreshold = sellThreshold;
        }

        public void Update(string symbol, decimal price, decimal changePercent)
        {
            Console.WriteLine($"  → [Bot {BotName}] 🤖 Analisando {symbol}...");
            
            if (changePercent <= -BuyThreshold)
            {
                Console.WriteLine($"  → [Bot {BotName}] 💰 COMPRANDO {symbol} por R$ {price:N2}");
            }
            else if (changePercent >= SellThreshold)
            {
                Console.WriteLine($"  → [Bot {BotName}] 💸 VENDENDO {symbol} por R$ {price:N2}");
            }
        }
    }
}
