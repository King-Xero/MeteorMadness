﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IGameState
    {
        IEnumerable<IGameObject> GameObjects { get; }

        void Initialize();
        void HandleInput();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
        void Pause();
        void Resume();
    }
}