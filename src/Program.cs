using System;
using System.Reflection;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Execução do Sistema Legado ===");
            
            // Utilizamos Reflection para acionar a classe Program do Challenge.cs
            // sem a necessidade de alterá-la para 'public'. Em respeito à restrição.
            try
            {
                var legacyAssembly = Assembly.GetExecutingAssembly();
                var legacyProgramType = legacyAssembly.GetType("DesignPatternChallenge.Program");
                
                if (legacyProgramType != null)
                {
                    // Busca o Main, mesmo que seja privado (NonPublic) ou estático
                    var mainMethod = legacyProgramType.GetMethod("Main", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                    
                    if (mainMethod != null)
                    {
                        mainMethod.Invoke(null, new object[] { args });
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Método Main legado não encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ Classe Program legada não encontrada em DesignPatternChallenge.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao executar sistema legado: {ex.Message}");
            }

            Console.WriteLine("\n\n=== Execução do Sistema Refatorado com Observer ===");
            var petr4 = new Stock("PETR4", 35.50m);

            // Criando os observers independentes
            var investor1 = new Investor("João Silva", 3.0m);
            var investor2 = new Investor("Maria Santos", 5.0m);
            var mobileApp = new MobileApp("user123");
            var tradingBot = new TradingBot("AlgoTrader", 2.0m, 2.5m);

            // Vinculando (attach) os observadores ao Subject (ação)
            petr4.Attach(investor1);
            petr4.Attach(investor2);
            petr4.Attach(mobileApp);
            petr4.Attach(tradingBot);

            Console.WriteLine("\n=== Movimentações do Mercado (Observer Pattern) ===");

            petr4.UpdatePrice(36.20m); // +1.97%
            Thread.Sleep(500);

            petr4.UpdatePrice(37.50m); // +3.59%
            Thread.Sleep(500);

            petr4.UpdatePrice(35.00m); // -6.67%
            Thread.Sleep(500);

            Console.WriteLine("\n=== REMOVENDO OBSERVADORES DINAMICAMENTE ===");
            petr4.Detach(investor2);
            petr4.Detach(tradingBot);

            petr4.UpdatePrice(36.50m); // Preço sobe, menos observadores assinam
            Thread.Sleep(500);

            Console.WriteLine("\n=== NOVA NOTIFICAÇÃO ADICIONADA FACILMENTE ===");
            // Criar múltiplos observadores do mesmo tipo!
            var mobileApp2 = new MobileApp("user456_admin");
            petr4.Attach(mobileApp2);

            petr4.UpdatePrice(37.00m); 
            
            Console.WriteLine("\nRefatoração concluída! Observer pattern aplicado com sucesso.");
        }
    }
}
