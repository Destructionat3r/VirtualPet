using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    interface IRealTimeComponent
    {
        void Initialise();
        void Update();
        void Display();
    }
}
