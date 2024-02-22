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
        private readonly Dictionary<string, List<Connection>> table = [];
        private readonly double noAnswer = -1;
        public QueryBox(IList<IList<string>> equations, double[] values)
        {
            for (int i = 0; i < equations.Count; i++)
            {
                Connection connection1 = new()
                {
                    Cost = values[i],
                    Next = equations[i][1],
                    Source = equations[i][0]
                };

                AddToTable(connection1);

                Connection connection2 = new()
                {
                    Cost = Math.Pow(values[i], -1),
                    Next = equations[i][0],
                    Source = equations[i][1]
                };

                AddToTable(connection2);
            }
        }

        private void AddToTable(Connection connection)
        {
            if (!table.ContainsKey(connection.Source))
            {
                table.Add(connection.Source, []);
            }

            table[connection.Source].Add(connection);
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

        private bool IsValidConnection(Connection c, HashSet<string> visited)
        {
            if (table.ContainsKey(c.Source) && table.ContainsKey(c.Next))
            {
                return !visited.Contains(c.Source) && !visited.Contains(c.Next);
            }

            return false;
        }
        private double Find(Connection c, HashSet<string> visited)
        {
            if (!IsValidConnection(c, visited))
            {
                return noAnswer;
            }

            if (c.Source == c.Next)
            {
                return c.Cost;
            }

            visited.Add(c.Source);

            return RecursiveCall(table[c.Source], c, visited);
        }

        private double RecursiveCall(List<Connection> connections, Connection current, HashSet<string> visited)
        {
            foreach (Connection connection in connections)
            {
                Connection nextConnection = new()
                {
                    Source = connection.Next,
                    Next = current.Next,
                    Cost = connection.Cost * current.Cost
                };

                double path = Find(nextConnection, visited);

                if (path > 0)
                {
                    return path;
                }
            }

            return noAnswer;
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
