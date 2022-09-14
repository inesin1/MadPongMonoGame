using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadPongMonoGame.Components
{
    internal class GridLine : Component
    {
        public GridLine(Pong context) : base(context)
        {
            Position = Variables.DEFAULT_GRID_LINE_POS;
            _texture = Context.Content.Load<Texture2D>("i_GridLine");
        }

        public override void Draw()
        {
            for (int i = 0; i < 9; i++) {
                Context.SpriteBatch.Draw(
                    _texture, 
                    new Vector2(Position.X, Position.Y + 32.75f * i * 1.91f), 
                    Color.White);
            }
        }

        public override void Update(float elapsedTime)
        {
            // Nope
        }
    }
}
