using System;
using System.Collections.Generic;

namespace PROG6221_ICE3_ST10460756
{
    // ===== SECTION 1.4: Delegate declaration =====
    /// <summary>
    /// TipFormatter delegate - accepts a CyberTip and returns a formatted string
    /// This delegate allows flexible formatting of tips
    /// </summary>
    /// <param name="tip">The CyberTip to format</param>
    /// <returns>A formatted string representation</returns>
    public delegate string TipFormatter(CyberTip tip);

    /// <summary>
    /// TipManager class manages the collection of tips and handles events
    /// </summary>
    public class TipManager
    {
        // ===== SECTION 1.5: Event declaration =====
        /// <summary>
        /// TipDisplayed event is raised after a tip is displayed
        /// </summary>
        public event EventHandler<TipEventArgs> TipDisplayed;

        // ===== SECTION 1.2: Generic collection =====
        /// <summary>
        /// List of CyberTip objects - demonstrates generic collection usage
        /// </summary>
        private List<CyberTip> tips;

        /// <summary>
        /// Constructor initializes the tips collection
        /// </summary>
        public TipManager()
        {
            tips = new List<CyberTip>();
            InitializeTips();
        }

        /// <summary>
        /// Initializes the tip collection with at least 6 tips across 3 categories
        /// </summary>
        private void InitializeTips()
        {
            // Add at least 6 tips across at least 3 categories
            tips.Add(new CyberTip("Passwords", "Use a strong password with at least 12 characters, including uppercase, lowercase, numbers, and special symbols."));
            tips.Add(new CyberTip("Passwords", "Never reuse passwords across different websites or accounts."));
            tips.Add(new CyberTip("Passwords", "Consider using a password manager to generate and store secure passwords."));

            tips.Add(new CyberTip("Phishing", "Never click on suspicious links in emails or messages from unknown senders."));
            tips.Add(new CyberTip("Phishing", "Always verify the sender's email address before opening attachments or clicking links."));

            tips.Add(new CyberTip("Privacy", "Use two-factor authentication (2FA) whenever possible to add an extra layer of security."));
            tips.Add(new CyberTip("Privacy", "Be careful about what personal information you share on social media platforms."));
            tips.Add(new CyberTip("Privacy", "Regularly review and update your privacy settings on all online accounts."));

            // Add extra tips for variety
            tips.Add(new CyberTip("Safe Browsing", "Always look for 'https://' and a padlock icon in the address bar before entering sensitive information."));
            tips.Add(new CyberTip("Safe Browsing", "Avoid using public Wi-Fi for banking or other sensitive transactions without using a VPN."));
        }

        /// <summary>
        /// Returns all tips in the collection
        /// </summary>
        /// <returns>List of all CyberTip objects</returns>
        public List<CyberTip> GetAllTips()
        {
            return tips;
        }

        // ===== SECTION 1.3: Lambda expression and filtering =====
        /// <summary>
        /// Filters tips by category using a lambda expression
        /// </summary>
        /// <param name="category">The category to filter by</param>
        /// <returns>List of matching CyberTip objects</returns>
        public List<CyberTip> FilterTipsByCategory(string category)
        {
            // Using lambda expression with FindAll
            // The lambda: tip => tip.Category.Equals(category, StringComparison.OrdinalIgnoreCase)
            // checks if the tip's category matches the input category (case-insensitive)
            return tips.FindAll(tip => tip.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        // ===== SECTION 1.4: Delegate usage =====
        /// <summary>
        /// Displays tips using the provided formatter delegate
        /// </summary>
        /// <param name="filteredTips">List of tips to display</param>
        /// <param name="formatter">The delegate that formats each tip</param>
        public void DisplayTipsWithFormatter(List<CyberTip> filteredTips, TipFormatter formatter)
        {
            if (filteredTips == null || filteredTips.Count == 0)
            {
                Console.WriteLine("╔═══════════════════════════════════════╗");
                Console.WriteLine("║   No tips found in this category     ║");
                Console.WriteLine("╚═══════════════════════════════════════╝");
                return;
            }

            Console.WriteLine("\n╔═══════════════════════════════════════╗");
            Console.WriteLine($"║   Found {filteredTips.Count} tip(s) in this category   ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");

            int tipNumber = 1;
            foreach (CyberTip tip in filteredTips)
            {
                Console.WriteLine($"\n╔═══ Tip #{tipNumber} ═══╗");
                // Use the delegate to format the tip
                string formattedTip = formatter(tip);
                Console.WriteLine(formattedTip);
                Console.WriteLine("╚═══════════════════════════════════════╝");

                // ===== SECTION 1.5: Raise event =====
                // Raise the TipDisplayed event after displaying the tip
                OnTipDisplayed(tip);

                tipNumber++;
            }
        }

        // ===== SECTION 1.5: Event raising method =====
        /// <summary>
        /// Raises the TipDisplayed event with the displayed tip information
        /// </summary>
        /// <param name="tip">The tip that was displayed</param>
        protected virtual void OnTipDisplayed(CyberTip tip)
        {
            // Check if there are any subscribers to the event
            if (TipDisplayed != null)
            {
                // Raise the event with the tip data
                TipDisplayed(this, new TipEventArgs(tip));
            }
        }
    }

    /// <summary>
    /// Event arguments class that contains the tip that was displayed
    /// </summary>
    public class TipEventArgs : EventArgs
    {
        public CyberTip DisplayedTip { get; private set; }

        public TipEventArgs(CyberTip tip)
        {
            DisplayedTip = tip;
        }
    }
}