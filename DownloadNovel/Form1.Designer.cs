namespace Yungs
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.n_show_tlp = new System.Windows.Forms.TableLayoutPanel();
            this.n_search_btn = new System.Windows.Forms.Button();
            this.n_norvalName_tbx = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.n_si_rtb = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(607, 416);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.n_si_rtb);
            this.tabPage1.Controls.Add(this.n_show_tlp);
            this.tabPage1.Controls.Add(this.n_search_btn);
            this.tabPage1.Controls.Add(this.n_norvalName_tbx);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(599, 390);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "小说搜索";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // n_show_tlp
            // 
            this.n_show_tlp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.n_show_tlp.ColumnCount = 6;
            this.n_show_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.n_show_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.n_show_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.n_show_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.n_show_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.n_show_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.n_show_tlp.Location = new System.Drawing.Point(3, 31);
            this.n_show_tlp.Margin = new System.Windows.Forms.Padding(0);
            this.n_show_tlp.Name = "n_show_tlp";
            this.n_show_tlp.RowCount = 2;
            this.n_show_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.n_show_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.n_show_tlp.Size = new System.Drawing.Size(588, 352);
            this.n_show_tlp.TabIndex = 2;
            // 
            // n_search_btn
            // 
            this.n_search_btn.Location = new System.Drawing.Point(9, 4);
            this.n_search_btn.Name = "n_search_btn";
            this.n_search_btn.Size = new System.Drawing.Size(56, 23);
            this.n_search_btn.TabIndex = 1;
            this.n_search_btn.Text = "搜索";
            this.n_search_btn.UseVisualStyleBackColor = true;
            // 
            // n_norvalName_tbx
            // 
            this.n_norvalName_tbx.Location = new System.Drawing.Point(71, 7);
            this.n_norvalName_tbx.Name = "n_norvalName_tbx";
            this.n_norvalName_tbx.Size = new System.Drawing.Size(517, 21);
            this.n_norvalName_tbx.TabIndex = 0;
            this.n_norvalName_tbx.Text = "平凡的世界";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(599, 390);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "下载";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(178, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(599, 390);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "杂项";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // n_si_rtb
            // 
            this.n_si_rtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.n_si_rtb.Location = new System.Drawing.Point(0, 369);
            this.n_si_rtb.Multiline = false;
            this.n_si_rtb.Name = "n_si_rtb";
            this.n_si_rtb.ReadOnly = true;
            this.n_si_rtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.n_si_rtb.Size = new System.Drawing.Size(588, 18);
            this.n_si_rtb.TabIndex = 0;
            this.n_si_rtb.Text = "正在加载";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 414);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Yungs";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel n_show_tlp;
        private System.Windows.Forms.Button n_search_btn;
        private System.Windows.Forms.TextBox n_norvalName_tbx;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox n_si_rtb;
    }
}

