using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    // Subject (Observável) refatorado
    // Manteve-se o modelo da entidade ação, porém sem referências diretas
    // aos interessados via acoplamento forte
    public class Stock : ISubject
    {
        public string Symbol { get; set; }
        public decimal Price { get; private set; }
        public DateTime LastUpdate { get; private set; }
        private decimal _lastChangePercent;

        // Nova implementação: Lista genérica de observadores
        // Funciona como base para múltiplos tipos de inscritos 
        private readonly List<IObserver> _observers = new();

        public Stock(string symbol, decimal initialPrice)
        {
            Symbol = symbol;
            Price = initialPrice;
            LastUpdate = DateTime.Now;
        }

        // Operação para inscrever (Attach) o observador na notificação
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"[Sistema] Novo observador registrado para {Symbol}.");
        }

        // Operação para desinscrever (Detach) o observador da notificação
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"[Sistema] Observador removido de {Symbol}.");
        }

        // Propaga a mensagem que o Preço do ativo subiu / desceu
        public void UpdatePrice(decimal newPrice)
        {
            if (Price != newPrice)
            {
                decimal oldPrice = Price;
                Price = newPrice;
                LastUpdate = DateTime.Now;
                
                _lastChangePercent = ((newPrice - oldPrice) / oldPrice) * 100;
                
                Console.WriteLine($"\n[{Symbol}] Preço atualizado: R$ {oldPrice:N2} → R$ {newPrice:N2} ({_lastChangePercent:+0.00;-0.00}%)");

                // Chama o "Gatilho" para notificar todos da lista de uma vez só!
                Notify();
            }
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(Symbol, Price, _lastChangePercent);
            }
        }
    }
}
