using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadPongMonoGame.Components
{
    internal class Score : Component
    {
        private string _side;       // Сторона
        private int _value;         // Значение

        public Score(Pong context, string side) : base(context)
        {
            _side = side;

            if (side == "left")
                Position = Variables.DEFAULT_SCORE_L_POS;
            else
                Position = Variables.DEFAULT_SCORE_R_POS;

            _texture = Context.Content.Load<Texture2D>(@$"Scores\0");
        }

        public override void Draw()
        {
            Context.SpriteBatch.Draw(_texture, Position, Color.White);
        }

        public override void Update(float elapsedTime)
        {
            if (_side == "left")
                _value = Context.Scores[0];
            else
                _value = Context.Scores[1];

            _texture = Context.Content.Load<Texture2D>(@$"Scores\{_value}");
        }
    }
}
