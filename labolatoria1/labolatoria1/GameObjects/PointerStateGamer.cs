using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labolatoria1.GameObjects
{
    public class MousePointerInGame : IUniversalGameObject
    {
        public Texture2D objectTexture { get; set; }
        public Vector2 position { get; set; }

    }
}
