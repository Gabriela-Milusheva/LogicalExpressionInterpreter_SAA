using System;
using System.Collections.Generic;
using SAA.Utilities;

namespace SAA.LogicalExpression.DEFINE
{
    public class SplitIntoTokens
    {
        public static MyList<Token> GetTokens(string body)
        {
            int bodyLength = 0;
            foreach (char c in body)
            {
                bodyLength++;
            }
            MyList<Token> tokens = new MyList<Token>(bodyLength);

            int index = 0;

            while (index < body.Length)
            {
                char currentChar = body[index];

                switch (currentChar)
                {
                    case '&':
                        tokens.Add(new Token(Token.TokenType.AND, "&"));
                        index++;
                        break;

                    case '|':
                        tokens.Add(new Token(Token.TokenType.OR, "|"));
                        index++;
                        break;

                    case '!':
                        tokens.Add(new Token(Token.TokenType.NOT, "!"));
                        index++;
                        break;

                    case '(':
                        tokens.Add(new Token(Token.TokenType.OPEN_PAREN, "("));
                        index++;
                        break;

                    case ')':
                        tokens.Add(new Token(Token.TokenType.CLOSE_PAREN, ")"));
                        index++;
                        break;

                    default:
                        int endIndex = index;
                        bool encounteredCloseParen = false;

                        while (endIndex < body.Length && IsPartOfLiteralOrFunction(body[endIndex]) && !encounteredCloseParen)
                        {
                            if (body[endIndex] == ')')
                            {
                                encounteredCloseParen = true;
                            }
                            endIndex++;
                        }

                        string tokenValue = MyMethods.Substring(body, index, endIndex - index);
                        if (MyMethods.StartsWith(tokenValue, "func"))
                        {
                            tokens.Add(new Token(Token.TokenType.NESTED_FUNCTION, tokenValue));
                        }
                        else
                        {
                            tokens.Add(new Token(Token.TokenType.LITERAL, tokenValue[0].ToString()));
                            if (MyMethods.EndsWith(tokenValue, ")"))
                            {
                                tokens.Add(new Token(Token.TokenType.CLOSE_PAREN, ")"));
                            }
                        }

                        index = endIndex;
                        break;
                }
            }

            return tokens;
        }


        private static bool IsPartOfLiteralOrFunction(char c)
        {
            if (c >= 'a' && c <= 'z' || c >= '0' && c <= '9')
            {
                return true;
            }

            if (c == '(' || c == ')' || c == ',')
            {
                return true;
            }

            return false;
        }
    }
} //define func6(a,b): (a&func7(a,b))&(b|func9(a,b))