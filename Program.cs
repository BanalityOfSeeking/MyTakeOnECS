using BonesOfTheFallen.Services.Components;
using BonesOfTheFallen.Services.Components.Classes;
using DotNext;
using System;
using System.Threading;

namespace BonesOfTheFallen.Services
{

    internal class Program
    {
        [STAThread]
        static void Main()
        {
            var go = new GameObject();

            UserDataStorage storage = go.GetUserData();
            storage.GetOrSet(go.Class, () => SelectClass());
            storage.GetOrSet(go.Race, () => SelectRace());
            storage.GetOrSet(go.Attributes, () => new GameSequence<int>().AddSegment(new(Range.EndAt(19))));

        }

        private static Race SelectRace()
        {
            throw new NotImplementedException();
        }

        private static GameClass SelectClass()
        {
            Console.SetCursorPosition(0, Console.WindowHeight);
            Console.Out.WriteLineAsync("Hello");
            return GameClass.None;
        }
    }
    public static class AttibutesExtensions
    {
        internal static GameObject ApplyRace(this GameObject po, Race race)
        {
            var storage = po.GetUserData();
            storage.Set(po.Race, race);
            if (storage.TryGet(po.Attributes, out GameSequence<int>?  attributes))
            {
                attributes = race switch
                {
                    Race.Human => attributes +new AttributeModifiers()
                    {
                        CharismaMod = 1,
                        ConstitutionMod = 1,
                        DexterityMod = 1,
                        HealthMod = 40,
                        IntelligenceMod = 1,
                        ManaMod = 20,
                        StrengthMod = 1,
                        WisdomMod = 1,
                    },
                    Race.Elf => attributes +new AttributeModifiers()
                    {
                        CharismaMod = 2,
                        ConstitutionMod = 0,
                        DexterityMod = 2,
                        HealthMod = 30,
                        IntelligenceMod = 1,
                        ManaMod = 30,
                        StrengthMod = 0,
                        WisdomMod = 1,
                    },
                    Race.Dwarf => attributes +new AttributeModifiers()
                    {
                        CharismaMod = 0,
                        ConstitutionMod = 2,
                        DexterityMod = 0,
                        HealthMod = 50,
                        IntelligenceMod = 0,
                        ManaMod = 20,
                        StrengthMod = 2,
                        WisdomMod = 2,
                    },
                    _ => throw new NotImplementedException(),
                };
                storage.Set(po.Attributes, attributes);
            }
            return po;
        }

        internal static GameObject ApplyClass(this GameObject po, GameClass @class)
        {
            var storage = po.GetUserData();
            storage.Set(po.Class, @class);
            if (storage.TryGet(po.Attributes, out Attributes attributes))
            {
                attributes = @class switch
                {
                    // Human (best class: any)
                    GameClass.Archer => attributes +new AttributeModifiers()
                    {
                        CharismaMod = 2,
                        ConstitutionMod = -2,
                        DexterityMod = 2,
                        HealthMod = 25,
                        IntelligenceMod = -1,
                        ManaMod = 25,
                        StrengthMod = -2,
                        WisdomMod = 2,
                    },
                    // Elf (best class : Mage, Archer)
                    GameClass.Cleric => attributes +new AttributeModifiers()
                    {
                        CharismaMod = -1,
                        ConstitutionMod = 1,
                        DexterityMod = -2,
                        HealthMod = 35,
                        IntelligenceMod = -2,
                        ManaMod = 50,
                        StrengthMod = 2,
                        WisdomMod = 1,
                    },
                    // Dwarf (best class: Cleric / Fighter)
                    GameClass.Fighter => attributes +new AttributeModifiers()
                    {
                        CharismaMod = -2,
                        ConstitutionMod = 4,
                        DexterityMod = -2,
                        HealthMod = 50,
                        IntelligenceMod = -2,
                        ManaMod = 25,
                        StrengthMod = 2,
                        WisdomMod = -2,

                    },
                    GameClass.Mage => attributes +new AttributeModifiers()
                    {
                        CharismaMod = -1,
                        ConstitutionMod = -2,
                        DexterityMod = 2,
                        HealthMod = 25,
                        IntelligenceMod = 2,
                        ManaMod = 50,
                        StrengthMod = -2,
                        WisdomMod = 3,
                    },
                    _ => throw new NotImplementedException(),
                };
                storage.Set(po.Attributes, attributes);
            }
            return po;
        }
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
