using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadPongMonoGame
{
    /// <summary>
    /// Мяч
    /// </summary>
    internal class Ball : GameObject
    {
        private long _startSleep = 0;       // Время старта сна
        private int _sleepTime = 0;         // Время сна
        private bool _isSleep = false;      // Спит ли

        private float _speed = 400.0f;      // Скорость
        private float _direction = 45.0f;   // Направление

        public Ball(Pong context) : base(context) { }

        public override void Init()
        {
            Position = Variables.DEFAULT_BALL_POS;
            _speed = 400.0f;

            // Устанавливаем случайное направление
            if (new Random().Next(2) == 0)
                _direction = 45.0f;
            else
                _direction = 135.0f;

            Sleep(1000);

            base.Init();
        }

        public override void Update(float elapsedTime)
        {
            if (!_isSleep) 
                Move(elapsedTime);
            CheckCollisions();

            if (TimeSpan.FromTicks(DateTime.Now.Ticks - _startSleep).TotalMilliseconds >= _sleepTime)
                _isSleep = false;

            if (_speed > 400.0f)
                _speed -= 0.5f;

            base.Update(elapsedTime);
        }

        /// <summary>
        /// Останавливает объект на установленное время
        /// </summary>
        /// <param name="sleepTime">Время сна</param>
        public void Sleep(int sleepTime) {
            _startSleep = DateTime.Now.Ticks;
            _sleepTime = sleepTime;
            _isSleep = true;
        }

        /// <summary>
        /// Перемещает мяч в заданном направлении
        /// </summary>
        private void Move(float elapsedTime) {
            float newX = Position.X + (float)Math.Cos(DegToRad(_direction)) * _speed * elapsedTime;
            float newY = Position.Y - (float)Math.Sin(DegToRad(_direction)) * _speed * elapsedTime;
            Position = new Vector2(newX, newY);
        }

        /// <summary>
        /// Проверяет столкновения мяча с ракетками и границами поля
        /// </summary>
        private void CheckCollisions() {
            // Столкновение с вертикальными границами поля
            if (
                Position.Y <= 0 + SpriteSize.Y / 2 || 
                Position.Y >= Variables.WINDOW_HEIGHT - SpriteSize.Y / 2
                )
                _direction = 360 - _direction;

            // Столкновение с правой горизонтальной границей поля
            if (Position.X >= Variables.WINDOW_WIDTH - SpriteSize.X / 2) 
            {
                Init();
                Context.Scores[0]++;
                Sleep(1000);
            }

            // Столкновение с левой горизонтальной границей поля
            if (Position.X <= 0 + SpriteSize.X / 2)
            {
                Init();
                Context.Scores[1]++;
                Sleep(1000);
            }

            // Столкновение с ракетками
            if (
                isCollide(Context.GameObjects["batL"]) ||
                isCollide(Context.GameObjects["batR"])
                ) {

                _direction = 180 - _direction;
                _speed += 200;
            }

            if (_direction < 0)
                _direction += 360;
        }

        /// <summary>
        /// Переводит градусы в радианы
        /// </summary>
        /// <param name="deg">Значение в градусах</param>
        /// <returns>Значение в радианах</returns>
        private float DegToRad(float deg) { return deg * (float)Math.PI / 180; }
    }
}
