using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using System.Collections.Generic;

namespace MadPongMonoGame.GameScreens
{
    internal class PlayScreen : GameScreen
    {
        public List<Component> Components { get; private set; }     // Компоненты

        public string GameMode = "sp";                              // Режим игры
                                                                    // sp - 1 игрок
                                                                    // mp - 2 игрока 

        private bool _isPlay = false;                               // Идет ли игра

        private AI _ai;                                             // ИИ

        public PlayScreen(Game game, string gameMode) : base(game)
        {
            GameMode = gameMode;
        }

        private Pong Pong => (Pong)base.Game;

        public override void Initialize()
        {
            base.Initialize();

            // Создаем и добавляем игровые объекты в список
            Pong.GameObjects.Add("batL", new Bat(Pong, "left"));
            Pong.GameObjects.Add("batR", new Bat(Pong, "right"));
            Pong.GameObjects.Add("ball", new Ball(Pong));

            // Устнавливаем игровым объектам текстуры
            Pong.GameObjects["batL"].Texture = Content.Load<Texture2D>("s_Bat_L");
            Pong.GameObjects["batR"].Texture = Content.Load<Texture2D>("s_Bat_R");
            Pong.GameObjects["ball"].Texture = Content.Load<Texture2D>("s_Ball");

            // Добавляем компоненты
            Components = new List<Component> {
                new Components.Score(Pong, "left"),
                new Components.Score(Pong, "right"),
                new Components.GridLine(Pong)
            };

            // Инициализируем все игровые объекты
            foreach (GameObject gameObject in Pong.GameObjects.Values)
            {
                gameObject.Init();
            }

            if (GameMode == "sp")
            {
                _ai = new AI((Bat)Pong.GameObjects["batL"]);
                _ai.Start();
            }

            _isPlay = true;
        }

        public override void Draw(GameTime gameTime)
        {
            Pong.SpriteBatch.Begin();

            // Отрисовка компонентов
            foreach (Component component in Components)
            {
                component.Draw();
            }

            // Отрисовка игровых объектов
            foreach (GameObject gameObject in Pong.GameObjects.Values)
            {
                gameObject.Draw();
            }

            Pong.SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(InputManager.GAME_RESTART))
                Restart();

            if (_isPlay)
            {
                // Обновляем состояния всех игровых объектов
                foreach (GameObject gameObject in Pong.GameObjects.Values)
                {
                    gameObject.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                }

                Input((float)gameTime.ElapsedGameTime.TotalSeconds);

                CheckEndGame();
            }

            // Обновляем состояния всех компонентов
            foreach (Component component in Components)
            {
                component.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (GameMode == "sp")
            {
                _ai.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        /// <summary>
        /// Проверяет закончена ли игра
        /// </summary>
        private void CheckEndGame() {
            if (Pong.Scores[0] == 10) { 
                _isPlay = false;
            }

            if (Pong.Scores[1] == 10)
            {
                _isPlay = false;
            }
        }

        /// <summary>
        /// Перезапуск игры
        /// </summary>
        public void Restart()
        {
            foreach (GameObject gameObject in Pong.GameObjects.Values)
            {
                gameObject.Init();
            }
            Pong.Scores = new int[2] { 0, 0};
            _isPlay = true;
        }

        /// <summary>
        /// Управление
        /// </summary>
        public void Input(float elapsedTime)
        {
            Bat batL = (Bat)Pong.GameObjects["batL"];
            Bat batR = (Bat)Pong.GameObjects["batR"];

            // Левая ракетка
            if (GameMode == "mp")
            {
                if (Keyboard.GetState().IsKeyDown(InputManager.BAT_L_UP))
                    batL.Position = new Vector2(batL.Position.X, (int)(batL.Position.Y - batL.Speed * elapsedTime));
                if (Keyboard.GetState().IsKeyDown(InputManager.BAT_L_DOWN))
                    batL.Position = new Vector2(batL.Position.X, (int)(batL.Position.Y + batL.Speed * elapsedTime));
            }

            // Правая ракетка
            if (Keyboard.GetState().IsKeyDown(InputManager.BAT_R_UP))
                batR.Position = new Vector2(batR.Position.X, (int)(batR.Position.Y - batR.Speed * elapsedTime));
            if (Keyboard.GetState().IsKeyDown(InputManager.BAT_R_DOWN))
                batR.Position = new Vector2(batR.Position.X, (int)(batR.Position.Y + batR.Speed * elapsedTime));
        }
    }
}
