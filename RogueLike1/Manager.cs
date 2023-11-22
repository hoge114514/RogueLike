using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RogueLike1
{
    public class Manager
    {
        NormalIO scene;
        Title title;
        string[] mapPaths;
        string[] moviePaths;


        public Manager(Title title, string[] mapPaths, string[] moviePaths)
        {
            this.title = title;
            this.mapPaths = mapPaths;
            this.moviePaths = moviePaths;
        }

        public async void startGame()
        {

            TitleIO titleScene = new TitleIO(title);
            Task titleTask = Task.Run(() =>
            {
                titleScene.Generate();
            });
            while (titleScene.getFlag()) { System.Threading.Thread.Sleep(500); };
            titleScene.Dispose();

            for (int i=0;i < mapPaths.Length; i++)
            {
                MovieIO movie = new MovieIO(moviePaths[i]);
                Task movieTask = Task.Run( () =>
                {
                    movie.Generate();
                });
                while (movie.getFlag()) { System.Threading.Thread.Sleep(500); };
                movie = null;
                
                NormalIO stage = new NormalIO(mapPaths[i]);
                Task stageTask = Task.Run(() =>
                {
                    stage.Generate();
                });
                while (stage.getFlag()) { System.Threading.Thread.Sleep(500); };
                stage = null;
            }
            
        }



    }
}
