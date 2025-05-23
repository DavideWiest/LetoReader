using System;
using System.Collections.Generic;
using System.Linq;
using Reader.Data.Misc; // For ReaderThemePreset
// Add using Blazored.LocalStorage; if saving theme preference is desired later

namespace Reader.Modules
{
    public class ThemeService
    {
        public List<ReaderThemePreset> AvailableThemes { get; private set; }
        public ReaderThemePreset CurrentTheme { get; private set; }

        public event Action? OnThemeChanged;

        public ThemeService(/* Potentially ILocalStorageService localStorage if saving preference */)
        {
            // Initialize themes
            AvailableThemes = new List<ReaderThemePreset>
            {
                new ReaderThemePreset 
                { 
                    Name = "Default Dark", 
                    ReaderBackgroundColor = "var(--mud-palette-surface)", // Default MudBlazor dark surface
                    ReaderTextColor = "var(--mud-palette-text-primary)", // Default MudBlazor dark text
                    ReaderPeripheralTextColor = "var(--mud-palette-text-secondary)", // Default MudBlazor secondary text
                    ReaderMiddleCharHighlightColor = "#FFFFFF" // Current hardcoded value
                },
                new ReaderThemePreset 
                { 
                    Name = "Sepia", 
                    ReaderBackgroundColor = "#fbf0d9",
                    ReaderTextColor = "#5b4636",
                    ReaderPeripheralTextColor = "#8d6e63", // Or derive from ReaderTextColor with opacity
                    ReaderMiddleCharHighlightColor = "#000000"
                },
                new ReaderThemePreset 
                { 
                    Name = "Paper White", 
                    ReaderBackgroundColor = "#ffffff",
                    ReaderTextColor = "#000000",
                    ReaderPeripheralTextColor = "#555555",
                    ReaderMiddleCharHighlightColor = "#ff0000" 
                },
                new ReaderThemePreset 
                { 
                    Name = "Nordic Blue", 
                    ReaderBackgroundColor = "#2e3440", // Nord Polar Night
                    ReaderTextColor = "#d8dee9",       // Nord Snow Storm
                    ReaderPeripheralTextColor = "#81a1c1", // Nord Frost (lighter blue)
                    ReaderMiddleCharHighlightColor = "#ebcb8b" // Nord Frost (yellow)
                }
            };

            // Set a default theme (e.g., the first one, or load from local storage)
            CurrentTheme = AvailableThemes.FirstOrDefault(t => t.Name == "Default Dark") ?? AvailableThemes[0];
        }

        public void SetTheme(string themeName)
        {
            var newTheme = AvailableThemes.FirstOrDefault(t => t.Name == themeName);
            if (newTheme != null && newTheme != CurrentTheme)
            {
                CurrentTheme = newTheme;
                OnThemeChanged?.Invoke();
            }
        }
    }
}
