using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace labolatoria1.GameObjects
{
    public class GameSurface : IUniversalGameObject
    {
        public GameSurface(Texture2D objectTexture, int positionX, int positionY)
        {
            this.objectTexture = objectTexture;
            this.positionX = positionX;
            this.positionY = positionY;
        }

        public Texture2D objectTexture { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public float rotation { get; set; }

    }
}
