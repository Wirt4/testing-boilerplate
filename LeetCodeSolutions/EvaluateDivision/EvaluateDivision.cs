namespace LeetCodeSolutions;
public class EvaluateDivisionSolution
{

    private class Connection
    {
        public double Cost;
        public string Next;
        public string Source;
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
                    Next = equations[i][1],
                    Source = equations[i][0]
                };

                table[equations[i][0]].Add(connection1);

                if (!table.ContainsKey(equations[i][1]))
                {
                    table.Add(equations[i][1], []);
                }

                Connection connection2 = new()
                {
                    Cost = Math.Pow(values[i], -1),
                    Next = equations[i][0],
                    Source = equations[i][1]
                };

                table[equations[i][1]].Add(connection2);
            }
        }

        public bool Contains(string key)
        {
            return table.ContainsKey(key);
        }

        public double FindPath(IList<string> query)
        {
            Connection starter = new()
            {
                Source = query[0],
                Next = query[1],
                Cost = 1.0
            };
            return Find(starter, []);
        }

        private double Find(Connection c, HashSet<string> visited)
        {
            if (table.ContainsKey(c.Source) && table.ContainsKey(c.Next) && !visited.Contains(c.Source) && !visited.Contains(c.Next))
            {
                if (c.Source == c.Next)
                {
                    return c.Cost;
                }

                visited.Add(c.Source);

                List<Connection> adjacentConnection = table[c.Source];

                foreach (Connection connection in adjacentConnection)
                {
                    Connection nextConnection = new()
                    {
                        Source = connection.Next,
                        Next = c.Next,
                        Cost = connection.Cost * c.Cost
                    };
                    double path = Find(nextConnection, visited);
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
            answers.Add(qBox.FindPath(query));
        }

        return answers.ToArray();
    }
}
