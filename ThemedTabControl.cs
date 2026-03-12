using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Material_Editor
{
    internal sealed class ThemedTabControl : TabControl
    {
        public Func<ThemePalette?> PaletteProvider { get; set; }
        public Func<bool> ShouldPaintBody { get; set; } = () => true;

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWindowTheme(Handle, "", "");
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var palette = PaletteProvider?.Invoke();
            if (!palette.HasValue)
            {
                base.OnPaint(e);
                return;
            }
            base.OnPaint(e);

            var headerBottom = Enumerable.Range(0, TabCount)
                .Select(GetTabRect)
                .DefaultIfEmpty(new Rectangle(0, 0, 0, 0))
                .Max(rect => rect.Bottom);

            var display = DisplayRectangle;
            var bodyTop = Math.Max(display.Y, headerBottom);
            var bodyHeight = ClientRectangle.Height - bodyTop;

            var paintBody = ShouldPaintBody?.Invoke() ?? true;
            if (!paintBody)
                return;

            if (bodyHeight > 0)
            {
                var bodyRect = new Rectangle(ClientRectangle.X, bodyTop, ClientRectangle.Width, bodyHeight);
                using var brush = new SolidBrush(palette.Value.PanelBackground);
                e.Graphics.FillRectangle(brush, bodyRect);
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_PAINT = 0x000F;
            base.WndProc(ref m);

            if (m.Msg != WM_PAINT)
                return;

            var palette = PaletteProvider?.Invoke();
            if (!palette.HasValue)
                return;

            using var graphics = Graphics.FromHwnd(Handle);
            var accent = palette.Value.Accent.IsEmpty ? palette.Value.MenuBackground : palette.Value.Accent;
            var unselected = ControlPaint.Dark(palette.Value.PanelBackground, 0.1f);
            var border = palette.Value.MenuBackground;
            var textColor = palette.Value.Foreground;

            for (int i = 0; i < TabCount; i++)
            {
                var rect = GetTabRect(i);
                var fill = i == SelectedIndex ? accent : unselected;

                using (var brush = new SolidBrush(fill))
                {
                    graphics.FillRectangle(brush, rect);
                }

                using (var pen = new Pen(border))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    graphics.DrawRectangle(pen, rect);
                }

                TextRenderer.DrawText(graphics, TabPages[i].Text, Font, rect, textColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
