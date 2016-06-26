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

        public Vector3 camPos = new Vector3(0, 0);//camera position. currently disabled

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


        public void drawDot(Vector3 pos, char c)
        {
            if ((int)pos.x >= (int)camPos.x && (int)pos.y >= (int)camPos.y && (int)pos.x < (int)camPos.x + RenderSize.x && (int)pos.y < (int)camPos.y + RenderSize.y)
                canvas[(int)pos.x - (int)camPos.x, (int)pos.y - (int)camPos.y] = c;
            
        }

        //draws a box at a desired position by setting canvas chars in its range. A bit buggy
        public void drawBox(Vector3 pos, Vector3 size, char c)
        {
            for (int y = 0; y < size.y; y++)
                for (int x = 0; x < size.x; x++)
                    if ((int)pos.x + x >= (int)camPos.x && (int)pos.y + y >= (int)camPos.y && (int)pos.x + x < (int)camPos.x + RenderSize.x && (int)pos.y + y < (int)camPos.y + RenderSize.y)
                    canvas[(int)pos.x - (int)camPos.x + x, (int)pos.y - (int)camPos.y + y] = c;
        }

        public void drawDotStill(Vector3 pos, char c)
        {
           // if ((int)pos.x >= (int)camPos.x && (int)pos.y >= (int)camPos.y && (int)pos.x < (int)camPos.x + RenderSize.x && (int)pos.y < (int)camPos.y + RenderSize.y)
                canvas[(int)pos.x, (int)pos.y] = c;

        }

        //draws a box at a desired position by setting canvas chars in its range. A bit buggy
        public void drawBoxStill(Vector3 pos, Vector3 size, char c)
        {
            for (int y = 0; y < size.y; y++)
                for (int x = 0; x < size.x; x++)
                  //  if ((int)pos.x + x >= (int)camPos.x && (int)pos.y + y >= (int)camPos.y && (int)pos.x + x < (int)camPos.x + RenderSize.x && (int)pos.y + y < (int)camPos.y + RenderSize.y)
                        canvas[(int)pos.x + x, (int)pos.y + y] = c;
        }

        //Changes the camera position. currently commented out due to the renderer being buggy
        public void setCameraPosition(Vector3 pos)
        {
            camPos = new Vector3((int)pos.x - (int)(RenderSize.x * .5f), (int)pos.y - (int)(RenderSize.y * .5f));
        }
    }
}
