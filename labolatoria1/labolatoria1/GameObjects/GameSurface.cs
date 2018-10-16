using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace labolatoria1.GameObjects
{
    public class AreaOfNumbers : IUniversalGameObject
    {
        public AreaOfNumbers(Texture2D objectTexture,  Vector2 position, Vector2 size, float rotation=0)
        {
            this.objectTexture = objectTexture;
            this.Rotation = rotation;
            this.position = position;
            this.Size = size;
        }

        public Texture2D objectTexture { get; set; }
        public float Rotation { get; set; }
        public Vector2 position { get; set; }
        public Vector2 Size { get; set; }

        public bool IsMouseOver (IUniversalGameObject mouse)
        {
            if (mouse.position.X >= position.X && mouse.position.Y >= position.Y && mouse.position.X<=Size.X+position.X && mouse.position.Y <= Size.Y+position.Y)
                return true;
            else
                return false;
        }
    }
}
