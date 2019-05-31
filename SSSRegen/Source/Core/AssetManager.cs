using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class AssetManager : IAssetManager
    {
        private readonly Game _game;

        private Dictionary<string, Texture2D> _textures;
        private Dictionary<string, SpriteFont> _fonts;
        
        public AssetManager(Game game)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));

            _textures = new Dictionary<string, Texture2D>();
            _fonts = new Dictionary<string, SpriteFont>();
        }

        public void LoadTexture(string name, string fileName)
        {
            var texture = _game.Content.Load<Texture2D>(fileName);
            if (texture != null)
            {
                _textures.Add(name, texture);
            }
        }

        public Texture2D GetTexture(string name)
        {
            return _textures[name];
        }

        public void LoadFont(string name, string fileName)
        {
            var font = _game.Content.Load<SpriteFont>(fileName);
            if (font != null)
            {
                _fonts.Add(name, font);
            }
        }

        public SpriteFont GetFont(string name)
        {
            return _fonts[name];
        }
    }
}