namespace LeetCodeSolutions;
public class EvaluateDivisionSolution
{
    /**
represents equation "y = mx"
    **/
    private class Equation
    {
        public Equation(string y, double m, string x)
        {
            this.y = y;
            this.m = m;
            this.x = x;
        }
        public double m;
        public string x;
        public string y;
    }

    private class QueryBox
    {
        private readonly Dictionary<string, List<Equation>> table = [];
        private readonly double noAnswer = -1;
        public QueryBox(IList<IList<string>> equations, double[] values)
        {
            for (int i = 0; i < equations.Count; i++)
            {
                Equation connection1 = new(equations[i][0], values[i], equations[i][1]);
                AddToTable(connection1);
                Equation connection2 = new(equations[i][1], Math.Pow(values[i], -1), equations[i][0]);
                AddToTable(connection2);
            }
        }

        private void AddToTable(Equation connection)
        {
            if (!table.ContainsKey(connection.y))
            {
                table.Add(connection.y, []);
            }

            table[connection.y].Add(connection);
        }

        public bool Contains(string key)
        {
            return table.ContainsKey(key);
        }

        public double FindPath(IList<string> query)
        {
            string y = query[0];
            Equation starter = new(y, 1.0, query[1]);
            return Find(starter, []);
        }

        private bool IsValidConnection(Equation c, HashSet<string> visited)
        {
            if (table.ContainsKey(c.y) && table.ContainsKey(c.x))
            {
                return !visited.Contains(c.y) && !visited.Contains(c.x);
            }

            return false;
        }
        private double Find(Equation c, HashSet<string> visited)
        {
            if (!IsValidConnection(c, visited))
            {
                return noAnswer;
            }

            if (c.y == c.x)
            {
                return c.m;
            }

            visited.Add(c.y);

            return RecursiveCall(table[c.y], c, visited);
        }

        private double RecursiveCall(List<Equation> connections, Equation current, HashSet<string> visited)
        {
            double path = noAnswer;
            foreach (Equation connection in connections)
            {
                Equation nextConnection = new(connection.x, connection.m * current.m, current.x);

                path = Find(nextConnection, visited);

                if (path != noAnswer)
                {
                    break;
                }
            }

            return path;
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
