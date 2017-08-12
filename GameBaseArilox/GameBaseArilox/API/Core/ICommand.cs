using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Core
{
    public interface ICommand
    {
        void Execute(GameTime gameTime);
    }
}
