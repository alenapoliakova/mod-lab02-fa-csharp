using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }


  // 1. Develop a DFA class that accepts a binary string
  // containing exactly one '0' and at least one '1'.
  public class FA1
  {
    public static State a = new State()
    {
        Name = "a",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    public static State b = new State()
    {
        Name = "b",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };
    public static State c = new State()
    {
        Name = "c",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    State InitialState = a;

    public FA1()
    {
        a.Transitions['0'] = b;
        a.Transitions['1'] = a;
        b.Transitions['0'] = c;
        b.Transitions['1'] = b;
        c.Transitions['0'] = c;
        c.Transitions['1'] = c;
    }

    public bool? Run(IEnumerable<char> s)
    {
        State currentState = InitialState;
        foreach (var c in s) 
        {
            currentState = currentState.Transitions[c];
            if (currentState == null)           
                return null;
        }
        return currentState.IsAcceptState;        
    }
  }


  // 2. Develop a DFA class that accepts a binary string
  // containing an odd number of '0's and an odd number of '1's.
  public class FA2
  {
    public static State a = new State()
    {
        Name = "a",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public static State b = new State()
    {
        Name = "b",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public static State c = new State()
    {
        Name = "c",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };
    public static State d = new State()
    {
        Name = "d",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    State InitialState = a;

    public FA2()
    {
        a.Transitions['0'] = d;
        a.Transitions['1'] = b;
        b.Transitions['0'] = c;
        b.Transitions['1'] = a;
        c.Transitions['0'] = b;
        c.Transitions['1'] = d;
        d.Transitions['0'] = a;
        d.Transitions['1'] = c;
    }

    public bool? Run(IEnumerable<char> s)
    {
        State currentState = InitialState;
        foreach (var c in s)
        {
            currentState = currentState.Transitions[c];
            if (currentState == null)
                return null;
        }
        return currentState.IsAcceptState;
    }
  }

  // Develop a DFA class that accepts a binary string containing '11'.
  public class FA3
  {
    public static State a = new State()
    {
        Name = "a",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public static State b = new State()
    {
        Name = "b",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public static State c = new State()
    {
        Name = "c",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };

    State InitialState = a;

    public FA3()
    {
        a.Transitions['0'] = a;
        a.Transitions['1'] = b;
        b.Transitions['0'] = a;
        b.Transitions['1'] = c;
        c.Transitions['0'] = c;
        c.Transitions['1'] = c;
    }

    public bool? Run(IEnumerable<char> s)
    {
        State currentState = InitialState;
        foreach (var c in s)
        {
            currentState = currentState.Transitions[c];
            if (currentState == null)
                return null;
        }
        return currentState.IsAcceptState;
    }
  }


    class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}