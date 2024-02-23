namespace LeetCodeSolutions;
public class EvaluateDivisionSolution
{
    /**
represents equation "y = mx"
    **/
    private class Equation(string y, double m, string x)
    {
        public double m = m;
        public string x = x;
        public string y = y;
    }

    private class QueryBox
    {
        private readonly Dictionary<string, List<Equation>> EquationTable = [];
        private readonly double noAnswer = -1;
        public QueryBox(IList<IList<string>> equations, double[] values)
        {
            for (int i = 0; i < equations.Count; i++)
            {
                string y = equations[i][0];
                double m = values[i];
                string x = equations[i][1];

                Equation yInTermsOfX = new(y, m, x);
                AddToTable(yInTermsOfX);
                Equation XInTermsOfY = new(x, 1 / m, y);
                AddToTable(XInTermsOfY);
            }
        }

        private void AddToTable(Equation equation)
        {
            string key = equation.y;
            if (!EquationTable.ContainsKey(key))
            {
                EquationTable.Add(key, []);
            }

            EquationTable[key].Add(equation);
        }

        public bool Contains(string key)
        {
            return EquationTable.ContainsKey(key);
        }

        public double FindFactor(string a, string b)
        {
            Equation baseCase = new(a, 1.0, b);
            HashSet<string> visitedVariables = [];
            return IsolateMultiplier(baseCase, visitedVariables);
        }

        private bool IsValidConnection(Equation c, HashSet<string> visited)
        {
            if (EquationTable.ContainsKey(c.y) && EquationTable.ContainsKey(c.x))
            {
                return !visited.Contains(c.y) && !visited.Contains(c.x);
            }

            return false;
        }
        private double IsolateMultiplier(Equation currentEquation, HashSet<string> visited)
        {
            if (!IsValidConnection(currentEquation, visited))
            {
                return noAnswer;
            }

            string currentVariable = currentEquation.y;

            if (currentVariable == currentEquation.x)
            {
                return currentEquation.m;
            }

            visited.Add(currentVariable);

            double path = noAnswer;

            foreach (Equation adjacentEquasion in EquationTable[currentVariable])
            {
                Equation nextEquation = GetNextEquation(currentEquation, adjacentEquasion);

                path = IsolateMultiplier(nextEquation, visited);

                if (path != noAnswer)
                {
                    break;
                }
            }

            return path;
        }
        private Equation GetNextEquation(Equation current, Equation adjacent)
        {
            return new(adjacent.x, adjacent.m * current.m, current.x);
        }
    }
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        List<double> answers = [];
        QueryBox qBox = new QueryBox(equations, values);

        foreach (IList<string> query in queries)
        {
            answers.Add(qBox.FindFactor(query[0], query[1]));
        }

        return answers.ToArray();
    }
}
