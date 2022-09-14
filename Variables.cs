using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadPongMonoGame
{
    /// <summary>
    /// Глобальные переменные для игры
    /// </summary>
    internal static class Variables
    {
        // Размеры окна
        public const int WINDOW_WIDTH = 800;    
        public const int WINDOW_HEIGHT = 600;
        public const int WINDOW_HALF_WIDTH = WINDOW_WIDTH / 2;
        public const int WINDOW_HALF_HEIGHT = WINDOW_HEIGHT / 2;
        //

        // Стандартные расположения объектов
        public static Vector2 DEFAULT_BALL_POS = new Vector2(WINDOW_HALF_WIDTH, WINDOW_HALF_HEIGHT);
        
        public static Vector2 DEFAULT_BAT_L_POS = new Vector2(34, WINDOW_HALF_HEIGHT);
        public static Vector2 DEFAULT_BAT_R_POS = new Vector2(WINDOW_WIDTH - 34, WINDOW_HALF_HEIGHT);
        
        public static Vector2 DEFAULT_SCORE_L_POS = new Vector2(275, 38);
        public static Vector2 DEFAULT_SCORE_R_POS = new Vector2(470, 38);

        public static Vector2 DEFAULT_GRID_LINE_POS = new Vector2(397, 34);

        public static Vector2 DEFAULT_RESULT_L_POS = new Vector2(86, 158);
        public static Vector2 DEFAULT_RESULT_R_POS = new Vector2(450, 158);
        //


    }
}
