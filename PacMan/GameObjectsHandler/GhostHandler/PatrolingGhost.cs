using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameObjectsHandler.GhostHandler;

public class PatrolingGhost : Ghost
{
    public override char Symbol => 'T';

    public PatrolingGhost()
    {
        moveBehavior = new PatrolingMoveBehavior();
        HpToRemove = 1;
    }
}