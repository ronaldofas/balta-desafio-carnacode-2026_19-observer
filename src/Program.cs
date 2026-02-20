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
            Console.WriteLine("A implementação refatorada será adicionada nas próximas etapas...");
        }
    }
}
