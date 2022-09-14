using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadPongMonoGame
{
    /// <summary>
    /// Ракетка
    /// side: left/right
    /// </summary>
    internal class Bat : GameObject
    {
        public float Speed = 500.0f;      // Скорость
        private string _side = "left";      // Сторона

        public Bat(Pong context, string side) : base(context){ 
            _side = side;
        }

        public override void Init()
        {
            if (_side == "left") 
                Position = Variables.DEFAULT_BAT_L_POS; 
            else
                Position = Variables.DEFAULT_BAT_R_POS;

            base.Init();
        }

        public override void Update(float elapsedTime)
        {
            CheckBordersCollision();

            base.Update(elapsedTime);
        }

        /// <summary>
        /// Ограничивает движение ракеток по вертикали
        /// </summary>
        private void CheckBordersCollision() {
            if (Position.Y <= 0 + SpriteSize.Y / 2)
                Position = new Vector2(Position.X, 0 + SpriteSize.Y / 2);
            if (Position.Y >= Variables.WINDOW_HEIGHT - SpriteSize.Y / 2)
                Position = new Vector2(Position.X, Variables.WINDOW_HEIGHT - SpriteSize.Y / 2);
        }
    }
}
