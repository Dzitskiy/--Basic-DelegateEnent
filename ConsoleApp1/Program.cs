using System.Runtime.CompilerServices;

var caclulator = new Calculator();

var list = new List<int>() { 1,2,3};

var res1 =  list.Where(x => x > 2).ToList();


//caclulator.Operation(2,2, (a,b) =>  a + b );
//caclulator.Operation(2, 2, CustomOperation);

CalculatorDelegate handler = caclulator.GetHandler('+');

CalculatorDelegate handler2 = caclulator.GetHandler('-');
CalculatorDelegate handler3 = caclulator.GetHandler('*');

var res = caclulator.Operation(2, 2, handler);
Console.WriteLine(res);
var res2 = caclulator.Operation(3, 2, handler2);
Console.WriteLine(res2);
var res3 = caclulator.Operation(3, 2, handler3);
Console.WriteLine(res3);


int CustomOperation (int a, int b)
{
    return a + b;
}

public delegate int CalculatorDelegate(int i, int j);


public class Calculator : ICalculator
{
    public int Operation(int a, int b, CalculatorDelegate hadler)
    {
        int result = hadler(a, b);
        Console.WriteLine($"Operation result hendler ({a},{b}) = {result}");
        return result;
    }

    public CalculatorDelegate GetHandler(char operation)
    {
        switch (operation)
        {
            case '+':
                return (int a, int b) => { return a + b; };
                break;
            case '-':
                return (int a, int b) => { return a - b; };
                break;

            default:
                return (int a, int b) => 
                {
                    Console.WriteLine("Operation not found!");
                    return 0; 
                };
                break;

            //default:
            //    return GetDefaultHandler; 
            //    break;
        }
    }

    private int GetDefaultHandler(int a, int b)
    {
        return (a + b);
    }

}

interface ICalculator
{
    int Operation(int a, int b, CalculatorDelegate hadler);
}