namespace ObserverPattern
{
    // A interface do Subject que notifica os Observadores de mudanças
    public interface ISubject
    {
        // Adiciona um observador a notificação
        void Attach(IObserver observer);

        // Remove o observador para que não receba notificações
        void Detach(IObserver observer);

        // Dispara as mudanças para os itens observados
        void Notify();
    }
}
