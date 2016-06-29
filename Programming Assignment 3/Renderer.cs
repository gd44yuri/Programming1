using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Renderer
    {

        Vector3 RenderSize = new Vector3(55, 25);//Canvas size

        public Vector3 camPos = new Vector3(0, 0);//camera position.

        Game game;//reference back to the game class

        char[,] canvas;//char canvas
        ConsoleColor[,] colorCanvas;//Un-used. was meant to be color variable for the renderer, but didn't work out.

        public Renderer(Game _game) {
            game = _game;
            MakeCanvas();
        }

        //creates canvas array. may be replaced later
        void MakeCanvas()
        {
            canvas = new char[(int)RenderSize.x, (int)RenderSize.y];
            //colorCanvas = new ConsoleColor[(int)RenderSize.x, (int)RenderSize.y];
        }


        //clears the canvas array. may be replaced later
        public void ClearCanvas(){
            for (int y = 0; y < RenderSize.y; y++)
            {
                for (int x = 0; x < RenderSize.x; x++)
                {
                    canvas[x, y] = ' ';
                }
            }
        }

        // this is where the magic happens. may be changed drasticaly later
        public void Render()
        {
            ClearCanvas();//clears the canvas
            game.Render(this);//takes all of the render orders

            String render = "";//used as the final console render

            //this array adds all of the chars from the canvas to the render string
            for (int y = 0; y < RenderSize.y; y++)
            {
                for (int x = 0; x < RenderSize.x; x++)
                {
                    render += canvas[x, y];
                }
                render += '\n';
            }

            Console.Clear();//clear the console
            Console.Write(render);//write the render out
        }


        //draws a char at a position relative to the camera
        public void drawDot(Vector3 pos, char c)
        {
            if ((int)pos.x >= (int)camPos.x && (int)pos.y - (int)pos.z >= (int)camPos.y && (int)pos.x < (int)camPos.x + RenderSize.x && (int)pos.y - (int)pos.z < (int)camPos.y + RenderSize.y)
                canvas[(int)pos.x - (int)camPos.x, (int)pos.y - (int)camPos.y - (int)pos.z] = c;
            
        }

        //draws a box at a position relative to the camera
        public void drawBox(Vector3 pos, Vector3 size, char c)
        {
            for (int y = 0; y < size.y; y++)
                for (int x = 0; x < size.x; x++)
                    if ((int)pos.x + x >= (int)camPos.x && (int)pos.y + y - (int)pos.z >= (int)camPos.y && (int)pos.x + x < (int)camPos.x + RenderSize.x && (int)pos.y + y - (int)pos.z < (int)camPos.y + RenderSize.y)
                        canvas[(int)pos.x - (int)camPos.x + x, (int)pos.y - (int)camPos.y + y - (int)pos.z] = c;
        }

        //draws a char at a position relative to the canvas
        public void drawDotStill(Vector3 pos, char c)
        {
            canvas[(int)pos.x, (int)pos.y - (int)pos.z] = c;

        }

        //draws a box at a position relative to the canvas
        public void drawBoxStill(Vector3 pos, Vector3 size, char c)
        {
            for (int y = 0; y < size.y; y++)
                for (int x = 0; x < size.x; x++)
                  canvas[(int)pos.x + x, (int)pos.y + y] = c;
        }

        //Changes the camera position.
        public void setCameraPosition(Vector3 pos)
        {
            camPos = new Vector3((int)pos.x - (int)(RenderSize.x * .5f), (int)pos.y - (int)(RenderSize.y * .5f));
        }
    }
}
