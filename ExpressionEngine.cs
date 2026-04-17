using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DoAnCayNhiPhan
{
    public static class ExpressionEngine
    {
        public static List<string> Tokenize(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new Exception("Biểu thức rỗng.");

            List<string> tokens = new List<string>();
            int i = 0;

            while (i < expression.Length)
            {
                char c = expression[i];

                if (char.IsWhiteSpace(c))
                {
                    i++;
                    continue;
                }

                if (c == '-' && IsUnaryMinus(expression, i))
                {
                    StringBuilder negativeNumber = new StringBuilder();
                    negativeNumber.Append('-');
                    i++;

                    while (i < expression.Length && char.IsWhiteSpace(expression[i]))
                        i++;

                    bool hasDigit = false;
                    bool hasDot = false;

                    while (i < expression.Length &&
                           (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        if (expression[i] == '.')
                        {
                            if (hasDot)
                                throw new Exception("Số không hợp lệ.");
                            hasDot = true;
                        }

                        hasDigit = true;
                        negativeNumber.Append(expression[i]);
                        i++;
                    }

                    if (!hasDigit)
                    {
                        tokens.Add("-1");
                        tokens.Add("*");
                        continue;
                    }

                    tokens.Add(negativeNumber.ToString());
                    continue;
                }

                if (char.IsDigit(c) || c == '.')
                {
                    StringBuilder number = new StringBuilder();
                    bool hasDot = false;

                    while (i < expression.Length &&
                           (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        if (expression[i] == '.')
                        {
                            if (hasDot)
                                throw new Exception("Số không hợp lệ.");
                            hasDot = true;
                        }

                        number.Append(expression[i]);
                        i++;
                    }

                    tokens.Add(number.ToString());
                    continue;
                }

                if ("+-*/()".Contains(c))
                {
                    tokens.Add(c.ToString());
                    i++;
                    continue;
                }

                throw new Exception("Biểu thức chứa ký tự không hợp lệ: " + c);
            }

            return tokens;
        }

        private static bool IsUnaryMinus(string expr, int index)
        {
            if (expr[index] != '-') return false;

            int j = index - 1;
            while (j >= 0 && char.IsWhiteSpace(expr[j])) j--;

            if (j < 0) return true;

            return expr[j] == '(' || expr[j] == '+' || expr[j] == '-' || expr[j] == '*' || expr[j] == '/';
        }

        public static bool IsNumber(string token)
        {
            return double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }

        public static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }

        public static int Precedence(string op)
        {
            if (op == "+" || op == "-") return 1;
            if (op == "*" || op == "/") return 2;
            return 0;
        }

        public static void ValidateExpression(string expression)
        {
            List<string> tokens = Tokenize(expression);

            if (tokens.Count == 0)
                throw new Exception("Biểu thức rỗng.");

            Stack<string> bracketStack = new Stack<string>();

            for (int i = 0; i < tokens.Count; i++)
            {
                string token = tokens[i];

                if (token == "(")
                {
                    bracketStack.Push(token);
                }
                else if (token == ")")
                {
                    if (bracketStack.Count == 0)
                        throw new Exception("Ngoặc không cân bằng.");
                    bracketStack.Pop();
                }

                if (IsOperator(token))
                {
                    if (i == 0 || i == tokens.Count - 1)
                        throw new Exception("Toán tử không được ở đầu hoặc cuối biểu thức.");

                    if (IsOperator(tokens[i - 1]) || IsOperator(tokens[i + 1]))
                        throw new Exception("Có hai toán tử đứng liên tiếp.");
                }

                if (token == "(" && i < tokens.Count - 1 && tokens[i + 1] == ")")
                    throw new Exception("Không được có ngoặc rỗng ().");
            }

            if (bracketStack.Count > 0)
                throw new Exception("Ngoặc không cân bằng.");
        }

        public static List<string> InfixToPostfix(string expression)
        {
            ValidateExpression(expression);

            List<string> tokens = Tokenize(expression);
            List<string> output = new List<string>();
            Stack<string> operators = new Stack<string>();

            foreach (string token in tokens)
            {
                if (IsNumber(token))
                {
                    output.Add(token);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        output.Add(operators.Pop());
                    }

                    if (operators.Count == 0)
                        throw new Exception("Ngoặc không cân bằng.");

                    operators.Pop();
                }
                else if (IsOperator(token))
                {
                    while (operators.Count > 0 &&
                           IsOperator(operators.Peek()) &&
                           Precedence(operators.Peek()) >= Precedence(token))
                    {
                        output.Add(operators.Pop());
                    }

                    operators.Push(token);
                }
            }

            while (operators.Count > 0)
            {
                if (operators.Peek() == "(")
                    throw new Exception("Ngoặc không cân bằng.");

                output.Add(operators.Pop());
            }

            return output;
        }

        public static ExprNode BuildExpressionTree(List<string> postfix)
        {
            Stack<ExprNode> stack = new Stack<ExprNode>();

            foreach (string token in postfix)
            {
                if (IsNumber(token))
                {
                    stack.Push(new ExprNode(token));
                }
                else if (IsOperator(token))
                {
                    if (stack.Count < 2)
                        throw new Exception("Biểu thức không hợp lệ để xây cây.");

                    ExprNode right = stack.Pop();
                    ExprNode left = stack.Pop();

                    ExprNode node = new ExprNode(token);
                    node.Left = left;
                    node.Right = right;

                    stack.Push(node);
                }
            }

            if (stack.Count != 1)
                throw new Exception("Không thể xây cây biểu thức.");

            return stack.Pop();
        }

        public static double Evaluate(ExprNode root)
        {
            if (root == null)
                throw new Exception("Cây rỗng.");

            if (!root.IsOperator())
                return double.Parse(root.Value, CultureInfo.InvariantCulture);

            double left = Evaluate(root.Left);
            double right = Evaluate(root.Right);

            switch (root.Value)
            {
                case "+": return left + right;
                case "-": return left - right;
                case "*": return left * right;
                case "/":
                    if (right == 0)
                        throw new DivideByZeroException("Không thể chia cho 0.");
                    return left / right;
                default:
                    throw new Exception("Toán tử không hợp lệ.");
            }
        }

        public static string Preorder(ExprNode root)
        {
            if (root == null) return "";
            return (root.Value + " " + Preorder(root.Left) + " " + Preorder(root.Right)).Trim();
        }

        public static string Inorder(ExprNode root)
        {
            if (root == null) return "";

            if (!root.IsOperator())
                return root.Value;

            return "(" + Inorder(root.Left) + " " + root.Value + " " + Inorder(root.Right) + ")";
        }

        public static string Postorder(ExprNode root)
        {
            if (root == null) return "";
            return (Postorder(root.Left) + " " + Postorder(root.Right) + " " + root.Value).Trim();
        }
    }
}