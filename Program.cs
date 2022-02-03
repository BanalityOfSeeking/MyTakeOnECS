using BonesOfTheFallen.Classes;
using BonesOfTheFallen.GameItems;
using System;
using System.Runtime.Caching;
using System.Threading;

namespace BonesOfTheFallen.Services
{

    internal class Program
    {
        private static ObjectCache SettingsCache = default!;
        [STAThread]
        static void Main()
        {
            static void LoadSettings()
            {
                SettingsCache = MemoryCache.Default;
                foreach (var race in Enum.GetValues(typeof(Race)))
                {
                    AttributeModifiers Modifiers = race switch
                    {
                        // Human (best class: any)
                        Race.Human => new AttributeModifiers()
                        {
                            CharismaMod = 1,
                            ConstitutionMod = 1,
                            DexterityMod = 1,
                            HealthMod = 40,
                            InteligenceMod = 1,
                            ManaMod = 20,
                            StrengthMod = 1,
                            WisdomMod = 1,
                        },
                        // Elf (best class : Mage, Archer)
                        Race.Elf => new AttributeModifiers()
                        {
                            CharismaMod = 2,
                            ConstitutionMod = 0,
                            DexterityMod = 2,
                            HealthMod = 30,
                            InteligenceMod = 1,
                            ManaMod = 30,
                            StrengthMod = 0,
                            WisdomMod = 1,
                        },
                        // Dwarf (best class: Cleric / Fighter)
                        Race.Dwarf => new AttributeModifiers()
                        {
                            CharismaMod = 0,
                            ConstitutionMod = 2,
                            DexterityMod = 0,
                            HealthMod = 50,
                            InteligenceMod = 0,
                            ManaMod = 40,
                            StrengthMod = 2,
                            WisdomMod = 2,

                        },
                        _ => throw new NotImplementedException(),
                    };
                    CacheItem? cacheItem = new(Enum.GetName(typeof(Race), race), Modifiers);
                    SettingsCache.Add(cacheItem, null);
                }
            }
            LoadSettings();
            Attributes attributes = new()
            {
                Charisma = Random.Shared.Next(1, 19),
                Constitution = Random.Shared.Next(1, 19),
                Dexterity = Random.Shared.Next(1, 19),
                Expierence = 1,
                Health = 100,
                Inteligence = Random.Shared.Next(1, 19),
                Level = 1,
                Mana = 50,
                Strength = Random.Shared.Next(1, 19),
                Wisdom = Random.Shared.Next(1, 19),
            };

            Fighter fighter = new();
            RaceContainer race = new(Race.Dwarf);
            attributes += fighter.Modifiers;
            attributes += race.Modifiers;
            var playable = new PlayableObject(0, attributes, new Inventory(), new Position(), Race.Dwarf);
        }

        public class Time
        {
            public readonly PeriodicTimer timer = new(TimeSpan.FromMilliseconds(17));
        }
        /// <summary>
        /// Codes representing keyboard keys.
        /// </summary>
        /// <remarks>
        /// Key code documentation:
        /// http://msdn.microsoft.com/en-us/library/dd375731%28v=VS.85%29.aspx
        /// </remarks>
        public enum KeyCode : int
        {
            /// <summary>
            /// The left arrow key.
            /// </summary>
            Left = 0x25,

            /// <summary>
            /// The up arrow key.
            /// </summary>
            Up,

            /// <summary>
            /// The right arrow key.
            /// </summary>
            Right,

            /// <summary>
            /// The down arrow key.
            /// </summary>
            Down
        }

        /// <summary>
        /// Provides keyboard access.
        /// </summary>
        public static class NativeKeyboard
        {
            /// <summary>
            /// A positional bit flag indicating the part of a key state denoting
            /// key pressed.
            /// </summary>
            private const int KeyPressed = 0x8000;

            /// <summary>
            /// Returns a value indicating if a given key is pressed.
            /// </summary>
            /// <param name="key">The key to check.</param>
            /// <returns>
            /// <c>true</c> if the key is pressed, otherwise <c>false</c>.
            /// </returns>
            public static bool IsKeyDown(KeyCode key)
            {
                return (GetKeyState((int)key) & KeyPressed) != 0;
            }

            /// <summary>
            /// Gets the key state of a key.
            /// </summary>
            /// <param name="key">Virtuak-key code for key.</param>
            /// <returns>The state of the key.</returns>
            [global::System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
            private static extern short GetKeyState(int key);
        }
    }
}
