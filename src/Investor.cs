using System;

namespace ObserverPattern
{
    // Observador Concreto 1
    // Mantém a mesma lógica original, mas agora conectada pela interface IObserver
    public class Investor : IObserver
    {
        public string Name { get; set; }
        public decimal AlertThreshold { get; set; }

        public Investor(string name, decimal alertThreshold)
        {
            Name = name;
            AlertThreshold = alertThreshold;
        }

        // O método Update é acionado pelo Subject (Stock).
        public void Update(string symbol, decimal price, decimal changePercent)
        {
            Console.WriteLine($"  → [Investidor {Name}] Notificado sobre {symbol}");
            
            if (Math.Abs(changePercent) >= AlertThreshold)
            {
                Console.WriteLine($"  → [Investidor {Name}] ⚠️ ALERTA! Mudança de {changePercent:+0.00;-0.00}% excedeu limite de {AlertThreshold}%");
            }
        }
    }
}
