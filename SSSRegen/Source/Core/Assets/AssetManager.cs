using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SSSRegen.Source.Core.Interfaces.Assets;

namespace SSSRegen.Source.Core.Assets
{
    public class AssetManager : IAssetManager
    {
        private readonly Microsoft.Xna.Framework.Game _game;

        private readonly Dictionary<string, Texture2D> _textures;
        private readonly Dictionary<string, SpriteFont> _fonts;
        private readonly Dictionary<string, Song> _songs;
        private readonly Dictionary<string, SoundEffect> _soundEffects;
        
        public AssetManager(Microsoft.Xna.Framework.Game game)
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
            return _songs[name];
        }

        public void LoadSoundEffect(string name, string fileName)
        {
            var soundEffect = _game.Content.Load<SoundEffect>(fileName);
            if (soundEffect != null)
            {
                _soundEffects.Add(name, soundEffect);
            }
        }

        public SoundEffect GetSoundEffect(string name)
        {
            return _soundEffects[name];
        }
    }
}