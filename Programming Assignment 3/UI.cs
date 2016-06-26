using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class UI
    {

        public LivingEntity _plr;
        public Game _game;

        public UI(LivingEntity e, Game g)
        {
            _game = g;
            _plr = e;
        }

        public void Update()
        {

        }

        public void Render(Renderer r)
        {
            r.drawBoxStill(new Vector3(1, 1), new Vector3(_plr.HP, 1), '♥');
        }
    }
}
