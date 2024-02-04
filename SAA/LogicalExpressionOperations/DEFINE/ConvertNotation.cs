using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAA.Utilities;

namespace SAA.LogicalExpression.DEFINE
{
    public class ConvertNotation
    {
        // речник типовете оператори с техните приоритети
        private static readonly MyDictionary<Token.TokenType, int> OperatorPriority = new MyDictionary<Token.TokenType, int> (3)
        {
            { Token.TokenType.NOT, 3 },
            { Token.TokenType.AND, 2 },
            { Token.TokenType.OR, 1 }
        };

        private static int GetOperatorPriority(Token.TokenType type)
        {
            if (OperatorPriority.TryGetValue(type, out var priority))
            {
                return priority;
            }
            else
            {
                return 0;
            }
        }

        public static MyList<Token> ToPostfix(MyList<Token> infixTokens)
        {
            MyList<Token> postfixTokens = new MyList<Token>(infixTokens.Count);
            MyStack<Token> stack = new MyStack<Token>(infixTokens.Count);

            for (int i = 0; i < infixTokens.Count; i++)
            {
                var token = infixTokens.GetElementAt(i);
                //добавя директно към постфиксния израз
                if (token.Type == Token.TokenType.LITERAL || token.Type == Token.TokenType.NESTED_FUNCTION)
                {
                    postfixTokens.Add(token);
                }
                //добавя към стека
                else if (token.Type == Token.TokenType.OPEN_PAREN)
                {
                    stack.Push(token);
                }
                else if (token.Type == Token.TokenType.CLOSE_PAREN)
                { 
                    //извежда от стека, докато не стигне отваряща скоба
                    while (stack.Count > 0 && stack.GetLastElement().Type != Token.TokenType.OPEN_PAREN)
                    {
                        postfixTokens.Add(stack.Pop());
                    }

                    stack.Pop(); 
                }

                //при AND, OR, NOT
                else if (OperatorPriority.ContainsKey(token.Type))
                {
                    //проверява стека за оператори с по-висок или равен приоритет и ги добавя към постфиксния израз
                    while (stack.Count > 0 && GetOperatorPriority(stack.GetLastElement().Type) >= GetOperatorPriority(token.Type))
                    {
                        postfixTokens.Add(stack.Pop());
                    }
                    // текущият оператор се добавя в стека
                    stack.Push(token);
                }
            }

            //изважда останалите оператори от стека и ги добави към постфиксния израз
            while (stack.Count > 0)
            {
                postfixTokens.Add(stack.Pop());
            }

            return postfixTokens;
        }
    }
}
