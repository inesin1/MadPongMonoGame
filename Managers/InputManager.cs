using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadPongMonoGame
{
    /// <summary>
    /// Управление
    /// </summary>
    internal static class InputManager
    {
        // Игра
        public static Keys GAME_RESTART = Keys.R;
        //

        // Ракетки
        public static Keys BAT_L_UP = Keys.W;
        public static Keys BAT_L_DOWN = Keys.S;

        public static Keys BAT_R_UP = Keys.Up;
        public static Keys BAT_R_DOWN = Keys.Down;
        //
    }
}
