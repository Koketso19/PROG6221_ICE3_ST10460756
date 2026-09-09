using System;
using System.Collections.Generic;

namespace PROG6221_ICE3_ST10460756
{
    internal class Program
    {
        // ===== SECTION 1.5: Event subscription =====
        /// <summary>
        /// Event handler for TipDisplayed event
        /// Subscribed in Main method
        /// </summary>
        private static void OnTipDisplayed(object sender, TipEventArgs e)
        {
            // Display a confirmation message when a tip is displayed
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ Tip displayed: Category '{e.DisplayedTip.Category}'");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            // Create a new TipManager instance
            TipManager manager = new TipManager();

            // ===== SECTION 1.5: Subscribe to event =====
            // Subscribe to the TipDisplayed event
            manager.TipDisplayed += OnTipDisplayed;

            // Display the program header
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           CYBERSECURITY TIP MANAGER                      ║");
            Console.WriteLine("║         Your Guide to Online Safety                       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // ===== SECTION 1.2: Display all tips =====
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           ALL AVAILABLE CYBERSECURITY TIPS               ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            List<CyberTip> allTips = manager.GetAllTips();
            int count = 1;
            foreach (CyberTip tip in allTips)
            {
                Console.WriteLine($"{count}. {tip.ToString()}");
                count++;
            }

            Console.WriteLine($"\nTotal: {allTips.Count} tips available\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            // ===== SECTION 1.6: Allow repeated use =====
            // Main interaction loop - allows user to filter by category or exit
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                FILTER TIPS BY CATEGORY                   ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
                Console.WriteLine();

                // Display available categories
                Console.WriteLine("Available categories:");
                Console.WriteLine("  • Passwords");
                Console.WriteLine("  • Phishing");
                Console.WriteLine("  • Privacy");
                Console.WriteLine("  • Safe Browsing");
                Console.WriteLine();

                Console.Write("Enter a category to filter (or type 'exit' to quit): ");
                string input = Console.ReadLine();

                // Check if user wants to exit
                if (input.Trim().ToLower() == "exit")
                {
                    continueRunning = false;
                    Console.WriteLine("\nThank you for using the Cybersecurity Tip Manager!");
                    Console.WriteLine("Stay safe online! 👋");
                    continue;
                }

                // ===== SECTION 1.3: Lambda expression filtering =====
                // Use lambda expression to filter tips by category
                // The lambda: tip => tip.Category.Equals(input, StringComparison.OrdinalIgnoreCase)
                // is used inside the FilterTipsByCategory method
                string category = input.Trim();
                List<CyberTip> filteredTips = manager.FilterTipsByCategory(category);

                // ===== SECTION 1.4: Delegate for formatting =====
                // Define a delegate using a lambda expression for formatting
                // This delegate formats the tip in a nice visual style
                TipFormatter formatter = (tip) =>
                {
                    return $"║ 📋 Category: {tip.Category}\n" +
                           $"║ 💡 Tip: {tip.Message}\n" +
                           $"╚═══════════════════════════════════════";
                };

                // Display the filtered tips using the delegate
                Console.WriteLine("\n╔═══════════════════════════════════════════════════════════╗");
                Console.WriteLine($"║           TIPS IN CATEGORY: {category.ToUpper()}           ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");

                // Use the delegate to format and display tips
                manager.DisplayTipsWithFormatter(filteredTips, formatter);

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}