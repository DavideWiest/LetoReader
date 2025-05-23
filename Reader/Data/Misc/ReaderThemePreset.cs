namespace Reader.Data.Misc
{
    public class ReaderThemePreset
    {
        public string Name { get; set; } = string.Empty;
        public string ReaderBackgroundColor { get; set; } = string.Empty;
        public string ReaderTextColor { get; set; } = string.Empty;
        public string ReaderPeripheralTextColor { get; set; } = string.Empty;
        public string ReaderMiddleCharHighlightColor { get; set; } = string.Empty;

        // Optional: If themes should also influence general UI accents (like FABs in ReaderView)
        // public string AccentColor1 { get; set; } = string.Empty; // e.g., for FABs, primary buttons
        // public string AccentColor2 { get; set; } = string.Empty; // e.g., for secondary controls
    }
}
