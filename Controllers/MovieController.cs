using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LAB29_2.Models;

namespace LAB29_2.Controllers
{
    public class MovieController : ApiController
    {
        //1.--works
        public List<Movies> GetMovies()
        {
            Lab29Entities2 ORM = new Lab29Entities2();
            List<Movies> movies = ORM.Movies.ToList();
            return movies;
        }
        //2.--works
        public List<Movies> GetMoviesByCategory(string cat)
        {
            Lab29Entities2 ORM = new Lab29Entities2();
            return ORM.Movies.Where(x => x.Category == cat).ToList();
        }
        //3.--works
        public string GetRandomMovie()
        {
            Lab29Entities2 ORM = new Lab29Entities2();

            Random rnd = new Random();
            int newrnd = rnd.Next(1, 10);

            List<Movies> movies = ORM.Movies.ToList();
            return movies[newrnd].Title;
        }
        //4.--works
        public string GetRandomByCat(string cat)
        {
            Lab29Entities2 ORM = new Lab29Entities2();

            Random rnd = new Random();
            int newrnd = rnd.Next(ORM.Movies.Where(x => x.Category == cat).Count());

            List<Movies> mov = ORM.Movies.Where(x => x.Category == cat).ToList();
            return mov[newrnd].Title;
        }
        //5.--works
        public List<Movies> GetRandomMovies(int quant)
        {
            Lab29Entities2 ORM = new Lab29Entities2();
            Random rnd = new Random();
            List<Movies> movies = ORM.Movies.ToList();
            List<Movies> movielist = new List<Movies>();

            if (quant > movies.Count())
            for (int i = 0; i < quant; i++)
            {
                int nrand = rnd.Next(movies.Count());
                movielist.Add(movies[nrand]);
                movies.Remove(movies[nrand]);
            }
            return movielist;

            
        }
        //6.--works
        public List<string> GetMovieCategories()
        {
            Lab29Entities2 ORM = new Lab29Entities2();
            return ORM.Movies.Where(x => x.Category != null).Select(x => x.Category).Distinct().ToList();
            //Select(x => x.City).Distinct().ToList();
        }
        //7.--works
        public string GetMovieInfo(string movietitle)
        {
            Lab29Entities2 ORM = new Lab29Entities2();
            List<Movies> mov = ORM.Movies.Where(x => x.Title.ToLower() == movietitle.ToLower()).ToList();
            return mov[0].Description;
        }
        //8.--works
        public List<Movies> GetMoviesByKeyword(string content)
        {
            Lab29Entities2 ORM = new Lab29Entities2();
            return ORM.Movies.Where(x => x.Title.ToString().Contains(content)).ToList();
        }
    }
}