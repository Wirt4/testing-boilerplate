namespace LeetCodeSolutions;
public class EvaluateDivisionSolution
{
    private class MathNode
    {
        public List<double> Values;
        public List<string> Variables;
        public MathNode()
        {
            Values = [];
            Variables = [];
        }
    }

    private Dictionary<string, MathNode> CreateTable(IList<IList<string>> equations, double[] values)
    {
        Dictionary<string, MathNode> table = [];
        for (int i = 0; i < equations.Count; i++)
        {
            //add forward track
            if (!table.ContainsKey(equations[i][0]))
            {
                table.Add(equations[i][0], new MathNode());
            }

            table[equations[i][0]].Values.Add(values[i]);
            table[equations[i][0]].Variables.Add(equations[i][1]);

            //add refverse track
            if (!table.ContainsKey(equations[i][1]))
            {
                table.Add(equations[i][1], new MathNode());
            }

            table[equations[i][1]].Values.Add(1.0 / values[i]);
            table[equations[i][1]].Variables.Add(equations[i][0]);


        }
        return table;
    }

    private double PathCost(string target, string currentNode, double cost, Dictionary<string, MathNode> table, HashSet<string> visited)
    {
        if (target == currentNode)
        {
            return cost;
        }
        if (table.ContainsKey(currentNode) && !visited.Contains(currentNode))
        {
            visited.Add(currentNode);

            for (int i = 0; i < table[currentNode].Variables.Count; i++)
            {
                string neighbor = table[currentNode].Variables[i];
                double multiplier = table[currentNode].Values[i];

                double temp = PathCost(target, neighbor, cost * multiplier, table, visited);
                if (temp > 0)
                {
                    return temp;
                }
            }

        }

        return -1;
    }
    private double Foo(IList<string> query, Dictionary<string, MathNode> table)
    {
        if (!table.ContainsKey(query[0]) || !table.ContainsKey(query[1]))
        {
            return -1;
        }

        HashSet<string> visited = [query[0]];

        return PathCost(query[0], query[1], table[query[0]].Values[0], table, visited);

    }
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        // create a lookup table
        Dictionary<string, MathNode> table = CreateTable(equations, values);
        List<double> answers = [];

        foreach (IList<string> query in queries)
        {
            answers.Add(Foo(query, table));
        }

        return answers.ToArray();
    }
}
