namespace LeetCodeSolutions;
public class EvaluateDivisionSolution
{

    private class Connection
    {
        public double Cost;
        public string Next;
    }

    private class QueryBox
    {
        private Dictionary<string, List<Connection>> table = [];
        public QueryBox(IList<IList<string>> equations, double[] values)
        {
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
        }

        public bool Contains(string key)
        {
            return table.ContainsKey(key);
        }

        public double FindPath(string n1, string n2)
        {
            return Find(n1, n2, 1.0, []);
        }

        private double Find(string q1, string q2, double cost, HashSet<string> visited)
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
                    double path = Find(table[q1][i].Next, q2, table[q1][i].Cost * cost, visited);
                    if (path > 0)
                    {
                        return path;
                    }
                }
            }

            return -1;
        }
    }
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        List<double> answers = [];
        QueryBox qBox = new QueryBox(equations, values);

        foreach (IList<string> query in queries)
        {
            if (!qBox.Contains(query[0]) || !qBox.Contains(query[1]))
            {
                answers.Add(-1);
                continue;
            }

            double path = qBox.FindPath(query[0], query[1]);

            if (path > 0)
            {
                answers.Add(path);
            }
            else
            {
                answers.Add(path * qBox.FindPath(query[1], query[0]));
            }
        }

        return answers.ToArray();
    }
}
