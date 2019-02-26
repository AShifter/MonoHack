using Microsoft.Xna.Framework;
using System;

namespace MonoHack.Engine
{
    public class MonoHack : IGameComponent, IUpdateable
    {
        ///
        /// Our main Engine class. Instantiate this to get a lot of critical engine components started.
        ///

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => true;
        public int UpdateOrder => 0;

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
