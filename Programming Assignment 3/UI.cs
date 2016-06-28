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
            r.drawBoxStill(new Vector3(1, 3), new Vector3(1, 1), 'k');
            r.drawBoxStill(new Vector3(2, 3), new Vector3(1, 1), 'e');
            r.drawBoxStill(new Vector3(3, 3), new Vector3(1, 1), 'y');
            r.drawBoxStill(new Vector3(4, 3), new Vector3(1, 1), 's');
            r.drawBoxStill(new Vector3(5, 3), new Vector3(1, 1), ':');

            char c = _game.keys.ToString().ToCharArray()[0];

            r.drawBoxStill(new Vector3(6, 3), new Vector3(1, 1), (char)c);
        }
    }
}
