using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labolatoria1.GameObjects
{
    public class PointerStateGamer : IUniversalGameObject
    {
        public Texture2D objectTexture { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }

        
    }
}
