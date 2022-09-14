using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadPongMonoGame
{
    internal class Button : Component
    {
        private MouseState _currentMouse;   // Текущее состояние мыши
        private MouseState _previousMouse;  // Предыдущее состояние мыши
        private bool _isHover;              // Наведение курсора
        private Texture2D _textureOnHover;  // Текстура при наведении

        public event EventHandler Click;                           // Событие нажатия
        public bool Clicked { get; private set; }                  // Нажата ли
        public bool Hold { get; set; }                             // Зажатие 
        public Rectangle ClickBox {                                // Зона нажатия
            get {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)_texture.Width, (int)_texture.Height);
            } 
        }

        // Конструкторы
        public Button(Pong context,  Texture2D texture) : base(context) { _texture = texture; }
        public Button(Pong context,  Texture2D texture, Texture2D textureOnHover) : base(context) { _texture = texture; _textureOnHover = textureOnHover; }
        public Button(Pong context, Texture2D texture, Vector2 position) : this(context, texture) { Position = position; }
        public Button(Pong context, Texture2D texture, Texture2D textureOnHover, Vector2 position) : this(context, texture, textureOnHover) { Position = position; }

        public override void Draw()
        {
            // Меняем текстуру при наведении
            if ((_isHover || Hold) & _textureOnHover != null)
                Context.SpriteBatch.Draw(_textureOnHover, Position, Color.White);
            else 
                Context.SpriteBatch.Draw(_texture, Position, Color.White);
        }

        public override void Update(float elapsedTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            // Расположение курсора
            Rectangle mouseRect = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHover = false;

            // Если не зажата
            if (!Hold)
            {
                // Если навелись
                if (mouseRect.Intersects(ClickBox))
                {
                    _isHover = true;

                    // Если нажали
                    if (_currentMouse.LeftButton == ButtonState.Pressed)
                    {
                        Click?.Invoke(this, new EventArgs());
                    }
                }
            }
        }
    }
}
