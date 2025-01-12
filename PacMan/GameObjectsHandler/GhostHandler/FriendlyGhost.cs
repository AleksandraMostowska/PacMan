using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameObjectsHandler.GhostHandler;

public class FriendlyGhost : Ghost
{
    public override char Symbol => 'F';

    public FriendlyGhost()
    {
        moveBehavior = new FriendlyMoveBehavior();
        HpToRemove = 1;
    }
}
