using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoAnCayNhiPhan
{
    public partial class MainForm : Form
    {
        private ExprNode currentRoot;
        private List<HistoryItem> history = new List<HistoryItem>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                string expr = txtInput.Text.Trim();

                

                ExpressionEngine.ValidateExpression(expr);

                lstLog.Items.Add("Biểu thức hợp lệ.");
                MessageBox.Show("Biểu thức hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lstLog.Items.Add("Lỗi kiểm tra: " + ex.Message);
                MessageBox.Show("Lỗi thật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuild_Click(object sender, EventArgs e)
        {
            try
            {
                string expr = txtInput.Text.Trim();
                List<string> postfix = ExpressionEngine.InfixToPostfix(expr);

                txtPostfix.Text = string.Join(" ", postfix);

                currentRoot = ExpressionEngine.BuildExpressionTree(postfix);

                txtPreorder.Text = ExpressionEngine.Preorder(currentRoot);
                txtInorder.Text = ExpressionEngine.Inorder(currentRoot);
                txtPostorder.Text = ExpressionEngine.Postorder(currentRoot);

                DisplayTree(currentRoot);

                lstLog.Items.Add("Đã chuyển sang hậu tố.");
                lstLog.Items.Add("Đã xây cây biểu thức.");
            }
            catch (Exception ex)
            {
                lstLog.Items.Add("Lỗi xây cây: " + ex.Message);
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string expr = txtInput.Text.Trim();

                if (currentRoot == null)
                {
                    List<string> postfix = ExpressionEngine.InfixToPostfix(expr);
                    txtPostfix.Text = string.Join(" ", postfix);
                    currentRoot = ExpressionEngine.BuildExpressionTree(postfix);

                    txtPreorder.Text = ExpressionEngine.Preorder(currentRoot);
                    txtInorder.Text = ExpressionEngine.Inorder(currentRoot);
                    txtPostorder.Text = ExpressionEngine.Postorder(currentRoot);

                    DisplayTree(currentRoot);
                }

                double result = ExpressionEngine.Evaluate(currentRoot);
                txtResult.Text = result.ToString();

                lstLog.Items.Add("Kết quả: " + result);

                HistoryItem item = new HistoryItem
                {
                    Expression = expr,
                    Postfix = txtPostfix.Text,
                    Result = result.ToString()
                };

                history.Add(item);
                RefreshHistory();
            }
            catch (Exception ex)
            {
                lstLog.Items.Add("Lỗi tính toán: " + ex.Message);
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtPostfix.Clear();
            txtPreorder.Clear();
            txtInorder.Clear();
            txtPostorder.Clear();
            txtResult.Clear();

            treeViewExpr.Nodes.Clear();
            lstLog.Items.Clear();
            currentRoot = null;
        }

        private void btnExample_Click(object sender, EventArgs e)
        {
            txtInput.Text = "(-3.5+5)*(7-2)";
            lstLog.Items.Add("Đã nạp ví dụ mẫu.");
        }

        private void RefreshHistory()
        {
            lstHistory.Items.Clear();
            foreach (var item in history)
            {
                lstHistory.Items.Add(item);
            }
        }

        private void lstHistory_DoubleClick(object sender, EventArgs e)
        {
            if (lstHistory.SelectedItem is HistoryItem item)
            {
                txtInput.Text = item.Expression;
                txtPostfix.Text = item.Postfix;
                txtResult.Text = item.Result;
                lstLog.Items.Add("Đã tải lại biểu thức từ lịch sử.");
            }
        }

        private void DisplayTree(ExprNode root)
        {
            treeViewExpr.Nodes.Clear();

            if (root != null)
            {
                TreeNode rootNode = CreateNode(root);
                treeViewExpr.Nodes.Add(rootNode);
                treeViewExpr.ExpandAll();
            }
        }

        private TreeNode CreateNode(ExprNode exprNode)
        {
            TreeNode node = new TreeNode(exprNode.Value);

            if (exprNode.Left != null)
                node.Nodes.Add(CreateNode(exprNode.Left));

            if (exprNode.Right != null)
                node.Nodes.Add(CreateNode(exprNode.Right));

            return node;
        }
    }
}