namespace ex18_winControlApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families; // 현재 OS내에 설치된 폰트를 다가져와
            foreach (var font in Fonts)
            {
                CboFonts.Items.Add(font.Name);
            }
        }

        // 글자체, 볼드, 이탤릭으로 변경하는 메서드
        void ChangeFont()
        {
            if (CboFonts.SelectedIndex < 0) // 아무것도 선택안됨
                return;

            FontStyle style = FontStyle.Regular; // 일반 글자(볼드X, 이탤릭X)로 초기화

            if (ChkBold.Checked)  // 굵게 체크박스를 체크하면
                style |= FontStyle.Bold;

            if (ChkItalic.Checked) // 이탤릭 체크박스를 체크하면
                style |= FontStyle.Italic;

            TxtSampleText.Font = new Font((string)CboFonts.SelectedItem, 12, style);
        }

        private void CboFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }
    }
}
