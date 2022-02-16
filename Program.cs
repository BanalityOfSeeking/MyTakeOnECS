using BonesOfTheFallen.Services.Components;
using BonesOfTheFallen.Services.Components.Classes;
using BonesOfTheFallen.Services.Components.Forms;
using DotNext;
using System;
using System.Threading;
using System.Windows.Forms;

namespace BonesOfTheFallen.Services
{

    internal class Program
    {
        [STAThread]
        static void Main()
        {
            var go = new GameObject();

            UserDataStorage storage = go.GetUserData();
            storage.Set(go.Class, SelectClass());
            storage.Set(go.Race, SelectRace());
            storage.Set(go.Attributes, new GameSequence<int>().AddSegment(new(Range.EndAt(19))));

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
         

        }

        private static Race SelectRace()
        {
            return Race.Human;
        }

        private static GameClass SelectClass()
        {

            return GameClass.Farmer;
        }
    }
    public static class AttibutesExtensions
    {
        internal static GameObject ApplyRace(this GameObject po, Race race)
        {
            var storage = po.GetUserData();
            storage.Set(po.Race, race);
            if (storage.TryGet(po.Attributes, out var attributes))
            {
                attributes = race switch
                {
                    // Charisma,
                    // Constitution,
                    // Dexterity,
                    // Health,
                    // Intelligence,
                    // Mana,
                    // Strength,
                    // Wisdom
                    Race.Human => attributes.AddSegment(new(new int[] {
                        1,
                        1,
                        1,
                        40,
                        1,
                        20,
                        1,
                        1,
                    })),
                    Race.Elf => attributes.AddSegment(new(new int[] {
                    
                        2,
                        0,
                        2,
                        30,
                        1,
                        30,
                        0,
                        1,
                    })),
                    Race.Dwarf => attributes.AddSegment(new(new int[] {
                        0,
                        2,
                        0,
                        50,
                        0,
                        20,
                        2,
                        2,
                    })),
                    _ => throw new NotImplementedException(),
                };
                attributes.SumSegments();
                storage.Set(po.Attributes, attributes);
            }
            return po;
        }

        internal static GameObject ApplyClass(this GameObject po, GameClass @class)
        {
            var storage = po.GetUserData();
            storage.Set(po.Class, @class);
            if (storage.TryGet(po.Attributes, out GameSequence<int>? attributes))
            {
                attributes = @class switch
                {
 
                    GameClass.Archer => attributes.AddSegment(new(new int[] 
                    {
                        2,
                        -2,
                        2,
                        25,
                        -1,
                        25,
                        -2,
                        2,
                    })),
                    // Elf (best class : Mage, Archer)
                    GameClass.Cleric => attributes.AddSegment(new(new int[] {
                    
                        -1,
                        1,
                        -2,
                        35,
                        -2,
                        50,
                        2,
                        1,
                    })),
                    // Dwarf (best class: Cleric / Fighter)
                    GameClass.Fighter => attributes.AddSegment(new(new int[] {
                        -2,
                        4,
                        -2,
                        50,
                        -2,
                        25,
                        2,
                        -2,
                    })),
                    GameClass.Mage => attributes.AddSegment(new(new int[] {
                        -1,
                        -2,
                        2,
                        25,
                        2,
                        50,
                        -2,
                        3,
                    })),
                    _ => throw new NotImplementedException(),
                };
                attributes.SumSegments();
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
