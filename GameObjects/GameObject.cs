using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MadPongMonoGame
{
    /// <summary>
    /// Родительский класс для всех игровых объектов
    /// </summary>
    public class GameObject
    {
        public Vector2 Position { get; set; } = Vector2.Zero;   // Позиция
        public Vector2 Origin { get; set; } = Vector2.Zero;     // Центр координат
        public Texture2D Texture { get; set; }                  // Текстура
        public Rectangle CollisionBox { get; set; }             // Поле столкновений
        public int SpriteIndex { get; set; } = 0;               // Индекс текущего спрайта в спрайтбоксе
        public int SpriteCount { get; set; } = 1;               // Количество спрайтов в спрайтбоксе
        public Vector2 SpriteSize { get; set; } = Vector2.Zero; // Размер
        public Rectangle CurrentSpriteRectangle { get; set; }   // Прямоугольник текущего спрайта
        public float Rotation { get; set; } = 0;                // Угол поворота
        public Pong Context { get; }                            // Контекст

        public GameObject(Pong context) { Context = context; }

        /// <summary>
        /// Инициализация объекта. Запускается один раз при создании
        /// </summary>
        public virtual void Init() {
            if (Texture != null)
            {
                SpriteSize = new Vector2(Texture.Width / SpriteCount, Texture.Height);
                Origin = new Vector2(SpriteSize.X / 2, SpriteSize.Y / 2);
            }
        }

        /// <summary>
        /// Обновление состояния объекта. Запускается каждый кадр
        /// </summary>
        public virtual void Update(float elapsedTime) {
            CollisionBox = new Rectangle((int)Position.X, (int)Position.Y, (int)SpriteSize.X, (int)SpriteSize.Y);
            CurrentSpriteRectangle = new Rectangle((int)(SpriteIndex * SpriteSize.X), 0, (int)SpriteSize.X, (int)SpriteSize.Y);
        }

        public virtual void Draw() {
            Context.SpriteBatch.Draw(
                Texture,
                Position,
                CurrentSpriteRectangle,
                Color.White,
                Rotation,
                Origin,
                Vector2.One,
                SpriteEffects.None,
                0
                );
        }

        /// <summary>
        /// Проверка столкновения текущего объекта с другим объектом
        /// </summary>
        /// <param name="gameObject">Объект, с которым проверяется столкновение</param>
        /// <returns>Есть ли столкновение</returns>
        public bool isCollide(GameObject gameObject) { 
            return 
                Position.X + SpriteSize.X / 2 >= gameObject.Position.X - gameObject.SpriteSize.X / 2 &&
                Position.X - SpriteSize.X / 2 <= gameObject.Position.X + gameObject.SpriteSize.X / 2 &&
                Position.Y + SpriteSize.Y / 2 >= gameObject.Position.Y - gameObject.SpriteSize.Y / 2 &&
                Position.Y - SpriteSize.Y / 2 <= gameObject.Position.Y + gameObject.SpriteSize.Y / 2;
        }

        /// <summary>
        /// Проверка столкновения одного объекта с другим
        /// </summary>
        /// <param name="gameObject1">Первый объект</param>
        /// <param name="gameObject2">Второй объект</param>
        /// <returns>Есть ли столкновение</returns>
        public static bool CheckCollision(GameObject gameObject1, GameObject gameObject2) {
            return
                gameObject1.Position.X + gameObject1.SpriteSize.X / 2 >= gameObject2.Position.X - gameObject2.SpriteSize.X / 2 &&
                gameObject1.Position.X - gameObject2.SpriteSize.X / 2 <= gameObject2.Position.X + gameObject2.SpriteSize.X / 2&&
                gameObject1.Position.Y + gameObject1.SpriteSize.Y / 2 >= gameObject2.Position.Y - gameObject2.SpriteSize.Y / 2 &&
                gameObject1.Position.Y - gameObject1.SpriteSize.Y / 2 <= gameObject2.Position.Y + gameObject2.SpriteSize.Y / 2;
        }
    }
}
