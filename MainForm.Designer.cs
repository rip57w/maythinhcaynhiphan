namespace DoAnCayNhiPhan
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExample;

        private System.Windows.Forms.Label lblPostfix;
        private System.Windows.Forms.TextBox txtPostfix;

        private System.Windows.Forms.Label lblPreorder;
        private System.Windows.Forms.TextBox txtPreorder;

        private System.Windows.Forms.Label lblInorder;
        private System.Windows.Forms.TextBox txtInorder;

        private System.Windows.Forms.Label lblPostorder;
        private System.Windows.Forms.TextBox txtPostorder;

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtResult;

        private System.Windows.Forms.TreeView treeViewExpr;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExample = new System.Windows.Forms.Button();
            this.lblPostfix = new System.Windows.Forms.Label();
            this.txtPostfix = new System.Windows.Forms.TextBox();
            this.lblPreorder = new System.Windows.Forms.Label();
            this.txtPreorder = new System.Windows.Forms.TextBox();
            this.lblInorder = new System.Windows.Forms.Label();
            this.txtInorder = new System.Windows.Forms.TextBox();
            this.lblPostorder = new System.Windows.Forms.Label();
            this.txtPostorder = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.treeViewExpr = new System.Windows.Forms.TreeView();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblInput
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(20, 20);
            this.lblInput.Text = "Nhập biểu thức:";

            // txtInput
            this.txtInput.Location = new System.Drawing.Point(150, 17);
            this.txtInput.Size = new System.Drawing.Size(420, 26);

            // btnCheck
            this.btnCheck.Location = new System.Drawing.Point(590, 15);
            this.btnCheck.Size = new System.Drawing.Size(95, 32);
            this.btnCheck.Text = "Kiểm tra";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);

            // btnBuild
            this.btnBuild.Location = new System.Drawing.Point(695, 15);
            this.btnBuild.Size = new System.Drawing.Size(95, 32);
            this.btnBuild.Text = "Xây cây";
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);

            // btnCalculate
            this.btnCalculate.Location = new System.Drawing.Point(800, 15);
            this.btnCalculate.Size = new System.Drawing.Size(95, 32);
            this.btnCalculate.Text = "Tính";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(905, 15);
            this.btnClear.Size = new System.Drawing.Size(95, 32);
            this.btnClear.Text = "Xóa";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // btnExample
            this.btnExample.Location = new System.Drawing.Point(1010, 15);
            this.btnExample.Size = new System.Drawing.Size(120, 32);
            this.btnExample.Text = "Ví dụ mẫu";
            this.btnExample.Click += new System.EventHandler(this.btnExample_Click);

            // lblPostfix
            this.lblPostfix.AutoSize = true;
            this.lblPostfix.Location = new System.Drawing.Point(20, 70);
            this.lblPostfix.Text = "Hậu tố:";

            // txtPostfix
            this.txtPostfix.Location = new System.Drawing.Point(150, 67);
            this.txtPostfix.ReadOnly = true;
            this.txtPostfix.Size = new System.Drawing.Size(980, 26);

            // lblPreorder
            this.lblPreorder.AutoSize = true;
            this.lblPreorder.Location = new System.Drawing.Point(20, 110);
            this.lblPreorder.Text = "Preorder:";

            // txtPreorder
            this.txtPreorder.Location = new System.Drawing.Point(150, 107);
            this.txtPreorder.ReadOnly = true;
            this.txtPreorder.Size = new System.Drawing.Size(980, 26);

            // lblInorder
            this.lblInorder.AutoSize = true;
            this.lblInorder.Location = new System.Drawing.Point(20, 150);
            this.lblInorder.Text = "Inorder:";

            // txtInorder
            this.txtInorder.Location = new System.Drawing.Point(150, 147);
            this.txtInorder.ReadOnly = true;
            this.txtInorder.Size = new System.Drawing.Size(980, 26);

            // lblPostorder
            this.lblPostorder.AutoSize = true;
            this.lblPostorder.Location = new System.Drawing.Point(20, 190);
            this.lblPostorder.Text = "Postorder:";

            // txtPostorder
            this.txtPostorder.Location = new System.Drawing.Point(150, 187);
            this.txtPostorder.ReadOnly = true;
            this.txtPostorder.Size = new System.Drawing.Size(980, 26);

            // lblResult
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(20, 230);
            this.lblResult.Text = "Kết quả:";

            // txtResult
            this.txtResult.Location = new System.Drawing.Point(150, 227);
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(220, 26);

            // treeViewExpr
            this.treeViewExpr.Location = new System.Drawing.Point(24, 290);
            this.treeViewExpr.Size = new System.Drawing.Size(350, 320);

            // lblLog
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(390, 265);
            this.lblLog.Text = "Nhật ký xử lý";

            // lstLog
            this.lstLog.Location = new System.Drawing.Point(394, 290);
            this.lstLog.Size = new System.Drawing.Size(360, 324);

            // lblHistory
            this.lblHistory.AutoSize = true;
            this.lblHistory.Location = new System.Drawing.Point(775, 265);
            this.lblHistory.Text = "Lịch sử tính toán";

            // lstHistory
            this.lstHistory.Location = new System.Drawing.Point(779, 290);
            this.lstHistory.Size = new System.Drawing.Size(351, 324);
            this.lstHistory.DoubleClick += new System.EventHandler(this.lstHistory_DoubleClick);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 640);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExample);
            this.Controls.Add(this.lblPostfix);
            this.Controls.Add(this.txtPostfix);
            this.Controls.Add(this.lblPreorder);
            this.Controls.Add(this.txtPreorder);
            this.Controls.Add(this.lblInorder);
            this.Controls.Add(this.txtInorder);
            this.Controls.Add(this.lblPostorder);
            this.Controls.Add(this.txtPostorder);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.treeViewExpr);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.lstHistory);
            this.Name = "MainForm";
            this.Text = "Cây nhị phân và tính toán biểu thức toán học";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}