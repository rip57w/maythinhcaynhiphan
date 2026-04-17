namespace DoAnCayNhiPhan
{
    public class HistoryItem
    {
        public string Expression { get; set; }
        public string Postfix { get; set; }
        public string Result { get; set; }

        public override string ToString()
        {
            return $"{Expression} = {Result}";
        }
    }
}