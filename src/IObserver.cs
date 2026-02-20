namespace ObserverPattern
{
    // A interface do Observer define o método Update que os os observadores vão receber.
    public interface IObserver
    {
        // Neste padrão passamos as informações úteis para não termos um acoplamento mais severo de ISubject
        void Update(string symbol, decimal price, decimal changePercent);
    }
}
