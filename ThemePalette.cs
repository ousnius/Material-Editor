using System.Drawing;

namespace Material_Editor
{
    public enum UITheme
    {
        Default,
        PipBoy3000
    }

    public readonly struct ThemePalette
    {
        public Color FormBackground { get; }
        public Color ControlBackground { get; }
        public Color PanelBackground { get; }
        public Color MenuBackground { get; }
        public Color Foreground { get; }
        public Color Accent { get; }

        public ThemePalette(Color formBackground, Color controlBackground, Color panelBackground, Color menuBackground, Color foreground, Color accent)
        {
            FormBackground = formBackground;
            ControlBackground = controlBackground;
            PanelBackground = panelBackground;
            MenuBackground = menuBackground;
            Foreground = foreground;
            Accent = accent;
        }
    }

    internal static class ThemeManager
    {
        private static readonly ThemePalette DefaultPalette = new(
            SystemColors.Control,
            SystemColors.Control,
            Color.WhiteSmoke,
            SystemColors.Control,
            SystemColors.ControlText,
            Color.Empty);

        private static readonly ThemePalette DarkPalette = new(
            Color.FromArgb(10, 12, 5),
            Color.FromArgb(33, 37, 17),
            Color.FromArgb(24, 32, 14),
            Color.FromArgb(12, 15, 8),
            Color.FromArgb(159, 255, 101),
            Color.FromArgb(88, 178, 71));

        public static ThemePalette GetPalette(UITheme theme)
        {
            return theme switch
            {
                UITheme.PipBoy3000 => DarkPalette,
                _ => DefaultPalette
            };
        }
    }
}
