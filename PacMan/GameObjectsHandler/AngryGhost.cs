using PacMan.MapHandler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameObjectsHandler;

public class AngryGhost : Ghost
{
    public override char Symbol => 'A';
    public AngryGhost() : base()
    {
        moveBehavior = new AngryMoveBehavior();
        HpToRemove = 2;
    }
}
