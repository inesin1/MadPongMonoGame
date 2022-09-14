using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadPongMonoGame
{
    /// <summary>
    /// Искусственный интеллект противника
    /// </summary>
    internal class AI
    {
        private bool _active = false;       // Включен

        private Bat _bat;                   // Ракетка, к-й он управляет
        private Ball _ball;                 // Мяч
        private float _speedDecrease;         // Уменьшение скорости

        public AI(Bat bat) {
            _bat = bat;
            _ball = _bat.Context.GameObjects["ball"] as Ball;
            switch (_bat.Context.Settings["complexity"]) {
                case "easy": _speedDecrease = 2f; break;
                case "normal": _speedDecrease = 1.5f; break;
                case "hard": _speedDecrease = 1f; break;
            };
        }

        // Управление 
        public void Start() { _active = true; }     // Вкл
        public void Stop() { _active = false; }     // Выкл

        /// <summary>
        /// Обновление
        /// </summary>
        public void Update(float elapsedTime) {
            if (_active) {
                if (Math.Abs(_bat.Position.X - _ball.Position.X) < Variables.WINDOW_HALF_WIDTH)
                {
                    if (_ball.Position.Y < _bat.Position.Y - _bat.SpriteSize.Y / 2)
                        _bat.Position = new Vector2(_bat.Position.X, (int)(_bat.Position.Y - _bat.Speed / _speedDecrease * elapsedTime));
                    if (_ball.Position.Y > _bat.Position.Y + _bat.SpriteSize.Y / 2)
                        _bat.Position = new Vector2(_bat.Position.X, (int)(_bat.Position.Y + _bat.Speed / _speedDecrease * elapsedTime));
                }
            }
        }
    }
}
