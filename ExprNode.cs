using System;

namespace DoAnCayNhiPhan
{
    public class ExprNode
    {
        public string Value { get; set; }
        public ExprNode Left { get; set; }
        public ExprNode Right { get; set; }

        public ExprNode(string value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public bool IsOperator()
        {
            return Value == "+" || Value == "-" || Value == "*" || Value == "/";
        }
    }
}