using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class AssetManager : IAssetManager
    {
        private readonly Game _game;

        private Dictionary<string, Texture2D> _textures;
        private Dictionary<string, SpriteFont> _fonts;
        private Dictionary<string, Song> _songs;
        private Dictionary<string, SoundEffect> _soundEffects;
        
        public AssetManager(Game game)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));

            _textures = new Dictionary<string, Texture2D>();
            _fonts = new Dictionary<string, SpriteFont>();
            _songs = new Dictionary<string, Song>();
            _soundEffects = new Dictionary<string, SoundEffect>();
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

        public void LoadSong(string name, string fileName)
        {
            var song = _game.Content.Load<Song>(fileName);
            if (song != null)
            {
                _songs.Add(name, song);
            }
        }

        public Song GetSong(string name)
        {
            throw new NotImplementedException();
        }

        public void LoadSoundEffect(string name, string fileName)
        {
            throw new NotImplementedException();
        }

        public Song GetSoundEffect(string name)
        {
            throw new NotImplementedException();
        }
    }
}