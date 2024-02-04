using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SAA.LogicalExpression.DEFINE;
using SAA.Utilities;
using SAA.BinaryTree;
using SAA.Function;
using System.Reflection.Emit;
using System.Reflection;

namespace SAA.LogicalExpressionOperations.FIND
{
    public class HeuristicMethodFind
    {
        private readonly Random random = new Random();
        private readonly Stopwatch stopwatch = new Stopwatch();
        private static TreeBuilder treeBuilder = new TreeBuilder();
     

        public string FindFitestBooleanExpression(string[,] truthTable, MyList<DefinedFunction> definedFunctions)
        {
            stopwatch.Reset();
            stopwatch.Start();

            var expressionVariableCount = truthTable.GetLength(1) - 1;
            var population = new List<List<string>>();

            var booleanExpression = GenerateRandomBooleanExpression(expressionVariableCount);
            int fitness = EvaluateExpressionFitness(booleanExpression, truthTable, definedFunctions);

            population.Add(booleanExpression);

            while (fitness < truthTable.GetLength(0) && stopwatch.Elapsed < TimeSpan.FromSeconds(2))
            {
                var newGeneration = EvolvePopulation(population, definedFunctions);
                fitness = UpdatePopulation(newGeneration, truthTable, definedFunctions, fitness);
            }

            if (stopwatch.Elapsed >= TimeSpan.FromSeconds(5))
            {
                stopwatch.Reset();
                population.Clear();
                return "";
            }

            return MyMethods.JoinWithSpacesBetween(booleanExpression);
        }

        private int UpdatePopulation(List<List<string>> newGeneration, string[,] truthTable, MyList<DefinedFunction> definedFunctions, int currentFitness)
        {
            foreach (var expression in newGeneration)
            {
                int expressionFitness = EvaluateExpressionFitness(expression, truthTable, definedFunctions);
                if (expressionFitness > currentFitness)
                {
                    currentFitness = expressionFitness;
                }
            }

            return currentFitness;
        }

        private int EvaluateExpressionFitness(List<string> booleanExpression, string[,] truthTable, MyList<DefinedFunction> definedFunctions)
        {
            int fitness = 0;
            for (int i = 0; i < truthTable.GetLength(0); i++)
            {
                var tableValues = MyMethods.ExtractRowValuesWithoutLastColumn(truthTable, i);
                string expression = MyMethods.JoinWithSpacesBetween(booleanExpression);

                var tokens = SplitIntoTokens.GetTokens(MyMethods.RemoveChar(expression, ' '));
                var postfixTokens = ConvertNotation.ToPostfix(tokens);

                int operandsCount = truthTable.GetLength(1) - 1;

                var root = TreeBuilder.BuildTree(postfixTokens, definedFunctions);
                MyList<string> operands = treeBuilder.GetLeaves(root, operandsCount);
                TreeSolver.UpdateArgumentValues(root, operands, tableValues);
                var result = TreeSolver.Solve(root);

                string truthValue = truthTable[i, truthTable.GetLength(1) - 1];
                if (result == (truthValue == "1"))
                {
                    fitness++;
                }
            }

            return fitness;
        }

        private List<string> GenerateRandomBooleanExpression(int operandCount)
        {
            List<string> booleanExpression = new();

            int letterValue = 97;

            for (int i = 0; i < operandCount; i++)
            {
                char operand = (char)letterValue;

                int randomNumber = random.Next(0, 2);

                if (randomNumber == 0)
                {
                    booleanExpression.Add(operand.ToString());
                }
                else
                {
                    booleanExpression.Add("!");
                    booleanExpression.Add(operand.ToString());
                }

                if (i != operandCount - 1)
                {
                    booleanExpression.Add(random.Next(0, 2) == 0 ? "&" : "|");
                }

                letterValue++;
            }

            return booleanExpression;
        }

        //Извършваме еволюция на популацията чрез прилагане на мутации и кросоувъри
        private List<List<string>> EvolvePopulation(List<List<string>> population, MyList<DefinedFunction> definedFunctions)
        {
            List<List<string>> newGeneration = new();

            //генерира се случаен брой мутации
            int numMutations = random.Next(0, 20);
            for (int i = 0; i < numMutations; i++)
            {
                //избираме 1 случаен израз от текущата популация
                List<string> expression = SelectRandomExpression(population);

                ApplyMutation(expression);

                //мутиралия израз се добавя към ново поколение
                newGeneration.Add(expression);
            }

            //генерира се случаен брой кросоувъри
            int numCrossovers = random.Next(0, 20);
            for (int i = 0; i < numCrossovers; i++)
            {
                //избираме 2 случайни израза от текущата популация
                List<string> expression1 = SelectRandomExpression(population);
                List<string> expression2 = SelectRandomExpression(population);

                //прилагаме кросоувър върху тях
                List<string> crossoverExpression = ApplyCrossover(expression1, expression2);

                //кросоувъртният израз се добавя към ново поколение
                newGeneration.Add(crossoverExpression);
            }

            return newGeneration;
        }

        private void ApplyMutation(List<string> booleanExpression)
        {
            int mutationIndex = random.Next(booleanExpression.Count);
            string mutation = booleanExpression[mutationIndex];

            switch (mutation)
            {
                case "&":
                    booleanExpression[mutationIndex] = "|";
                    return;
                case "|":
                    booleanExpression[mutationIndex] = "&";
                    return;
                case "!":
                    booleanExpression.RemoveAt(mutationIndex);
                    return;
                default:
                    if (mutationIndex > 0 && booleanExpression[mutationIndex - 1] == "!")
                    {
                        booleanExpression.RemoveAt(mutationIndex - 1);
                        return;
                    }

                    booleanExpression.Insert(mutationIndex, "!");
                    return;
            }
        }

        private List<string> ApplyCrossover(List<string> booleanExpression1, List<string> booleanExpression2)
        {
            //генерира се случайна точка за кросоувър в интервала [1, броя на операторите - 1]
            int crossoverPoint = random.Next(1, booleanExpression1.Count - 1);

            List<string> crossoverExpression = new List<string>();

            //копиране на частта от първия израз до точката за кросоувър (включително!)
            for (int i = 0; i < crossoverPoint; i++)
            {
                crossoverExpression.Add(booleanExpression1[i]);
            }

            //добавя се частта от втория израз след точката за кросоувър
            for (int i = crossoverPoint; i < booleanExpression2.Count; i++)
            {
                crossoverExpression.Add(booleanExpression2[i]);
            }

            return crossoverExpression;
        }

        
        private List<string> SelectRandomExpression(List<List<string>> population)
        {
            int index = random.Next(population.Count);
            return population[index];
        }

    }

}
