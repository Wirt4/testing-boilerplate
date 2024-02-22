namespace LeetCodeSolutions;
public class EvaluateDivisionSolution
{

    private class Connection
    {
        public double Cost;
        public string Next;
    }


    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        List<double> answers = [];
        Dictionary<string, List<Connection>> table = [];

        for (int i = 0; i < equations.Count; i++)
        {
            if (!table.ContainsKey(equations[i][0]))
            {
                table.Add(equations[i][0], []);
            }

            Connection connection1 = new()
            {
                Cost = values[i],
                Next = equations[i][1]
            };

            table[equations[i][0]].Add(connection1);

            if (!table.ContainsKey(equations[i][1]))
            {
                table.Add(equations[i][1], []);
            }

            Connection connection2 = new()
            {
                Cost = Math.Pow(values[i], -1),
                Next = equations[i][0]
            };

            table[equations[i][1]].Add(connection2);
        }

        foreach (IList<string> query in queries)
        {
            if (!table.ContainsKey(query[0]) || !table.ContainsKey(query[1]))
            {
                answers.Add(-1);
                continue;
            }

            double path = FindPath(query[0], query[1], 1.0, table, []);

            if (path > 0)
            {
                answers.Add(path);
            }
            else
            {
                answers.Add(path * FindPath(query[1], query[0], 1.0, table, []));
            }
        }

        return answers.ToArray();
    }

    private double FindPath(string q1, string q2, double cost, Dictionary<string, List<Connection>> table, HashSet<string> visited)
    {
        if (table.ContainsKey(q1) && table.ContainsKey(q2) && !visited.Contains(q1) && !visited.Contains(q2))
        {
            if (q1 == q2)
            {
                return cost;
            }

            visited.Add(q1);

            for (int i = 0; i < table[q1].Count; i++)
            {
                double path = FindPath(table[q1][i].Next, q2, table[q1][i].Cost * cost, table, visited);
                if (path > 0)
                {
                    return path;
                }
            }
        }

        return -1;
    }
}
