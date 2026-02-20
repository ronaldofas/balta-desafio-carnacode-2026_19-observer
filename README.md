![CO-7](https://github.com/user-attachments/assets/4db802a1-1546-4908-b34b-e25dfb6e04d5)

## 🥁 CarnaCode 2026 - Desafio 19 - Observer

Oi, eu sou o Ronaldo e este é o espaço onde compartilho minha jornada de aprendizado durante o desafio **CarnaCode 2026**, realizado pelo [balta.io](https://balta.io). 👻

Aqui você vai encontrar projetos, exercícios e códigos que estou desenvolvendo durante o desafio. O objetivo é colocar a mão na massa, testar ideias e registrar minha evolução no mundo da tecnologia.

### Sobre este desafio
No desafio **Observer** eu tive que resolver um problema real implementando o **Design Pattern** em questão.
Neste processo eu aprendi:
* ✅ Boas Práticas de Software
* ✅ Código Limpo
* ✅ SOLID
* ✅ Design Patterns (Padrões de Projeto)

## Problema
Um sistema financeiro precisa notificar múltiplos investidores quando o preço de ações muda.
O código atual faz polling constante ou tem dependências diretas entre as ações e os investidores, criando acoplamento forte e código difícil de manter.

## Solução (Observer Pattern)
A refatoração consistiu em aplicar o **Observer Pattern** para resolver o problema de forte acoplamento (dependências diretas da classe pai - *Subject* - em relação aos *Observers*) e o problema de desperdício de recursos (*polling*).

Foram criadas duas interfaces:
- `ISubject`: Define métodos para gerenciar inscrições (`Attach`, `Detach`) e disparar notificações genéricas (`Notify`).
- `IObserver`: Define o contrato com a assinatura `Update` esperado de quem tem interesse na ação.

**Principais Melhorias Implementadas:**
1. A classe `Stock` abandonou os IFs contendo métodos literais e passou a gerenciar uma lista unificada contendo `IObserver`.
2. As classes dependentes `Investor`, `MobileApp` e `TradingBot` passaram a implementar `IObserver` em arquivos separados e limpos.
3. Agora é possível plugar um novo tipo de notificação sem alterar o código primário da Ação (respeitando o Princípio Aberto/Fechado do SOLID) bastando apenas instanciar o objeto chamando o `Attach()`. Múltiplos inscritos de uma mesma categoria ou até remoção dinâmica agora são totalmente possíveis.
  
## Sobre o CarnaCode 2026
O desafio **CarnaCode 2026** consiste em implementar todos os 23 padrões de projeto (Design Patterns) em cenários reais. Durante os 23 desafios desta jornada, os participantes são submetidos ao aprendizado e prática na idetinficação de códigos não escaláveis e na solução de problemas utilizando padrões de mercado.

### eBook - Fundamentos dos Design Patterns
Minha principal fonte de conhecimento durante o desafio foi o eBook gratuito [Fundamentos dos Design Patterns](https://lp.balta.io/ebook-fundamentos-design-patterns).

### Veja meu progresso no desafio
[Repositório central](https://github.com/ronaldofas/balta-desafio-carnacode-2026-central)
