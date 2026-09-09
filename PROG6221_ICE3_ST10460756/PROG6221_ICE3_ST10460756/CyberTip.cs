using System;

namespace PROG6221_ICE3_ST10460756
{
    /// <summary>
    /// CyberTip class represents a cybersecurity tip with a category and message
    /// Uses automatic properties for encapsulation
    /// </summary>
    public class CyberTip
    {
        // ===== SECTION 1.1: Automatic properties =====
        public string Category { get; set; }
        public string Message { get; set; }

        // ===== SECTION 1.1: Constructor =====
        /// <summary>
        /// Constructor initializes both properties
        /// </summary>
        /// <param name="category">The category of the tip (e.g., Passwords, Phishing)</param>
        /// <param name="message">The tip message content</param>
        public CyberTip(string category, string message)
        {
            Category = category;
            Message = message;
        }

        // ===== SECTION 1.1: Override ToString() =====
        /// <summary>
        /// Override ToString to provide a clear display format
        /// </summary>
        /// <returns>Formatted string representation of the tip</returns>
        public override string ToString()
        {
            return $"[{Category}] {Message}";
        }

        /// <summary>
        /// Alternative method to get formatted display
        /// </summary>
        /// <returns>Formatted display string</returns>
        public string GetDisplayFormat()
        {
            return $"║ Category: {Category}\n║ Tip: {Message}\n╚═══════════════════════════════════════";
        }
    }
}