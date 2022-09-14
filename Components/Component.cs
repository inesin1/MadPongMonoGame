using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadPongMonoGame
{
    public abstract class Component
    {
        public Pong Context { get; }                            // Контекст
        protected Texture2D _texture;                           // Текстура
        public Vector2 Position { get; set; } = Vector2.Zero;   // Позиция

        public abstract void Draw();           // Отрисовка
        public abstract void Update(float elapsedTime);         // Обновление

        public Component(Pong context) { Context = context; }
    }
}
