using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SSSRegen.Source.Core.Interfaces
{
    interface IAssetManager
    {
        void LoadTexture(string name, string fileName);
        Texture2D GetTexture(string name);

        void LoadFont(string name, string fileName);
        SpriteFont GetFont(string name);
    }
}
