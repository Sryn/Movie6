using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTheater.Business_Logic
{
    public class MovieLogic
    {
        public static List<Movie> getMovieList()
        {
            var context = new MovieTheaterEntities();
            return context.Movie.Where(s => s.Active_Indicator == true).ToList<Movie>();
        }

        public static Movie getMovieByPK(int mid)
        {
            var context = new MovieTheaterEntities();
            return context.Movie.Where(s => s.Movie_ID == mid).First();
        }

        public static void insertMovie(string name, int duration, string description,
            string language, string subtitle, double ratings, string pictureURl, string imdbLink)
        {
            using (var context = new MovieTheaterEntities())
            {
                Movie mv = new Movie();
                mv.Movie_Name = name;
                mv.Duration = duration;
                mv.Description = description;
                mv.Language = language;
                mv.Subtitle = subtitle;
                mv.Ratings = ratings;
                mv.IMDB_Link = imdbLink;
                mv.PictureURL = pictureURl;
                mv.Active_Indicator = true;
                mv.Update_Datetime = DateTime.Today;
                context.Movie.Add(mv);
                context.SaveChanges();
            }
        }

        public static void updateMovie(int mid, string name, int duration,
            string description, string language, string subtitle, double ratings, string pictureURl, string imdbLink)
        {
            using (var context = new MovieTheaterEntities())
            {
                Movie mv = context.Movie.Where(s => s.Movie_ID == mid).First();
                mv.Movie_Name = name;
                mv.Duration = duration;
                mv.Description = description;
                mv.Language = language;
                mv.Subtitle = subtitle;
                mv.Ratings = ratings;
                if (pictureURl != "" && pictureURl != null)
                    mv.PictureURL = pictureURl;
                mv.IMDB_Link = imdbLink;
                mv.Update_Datetime = DateTime.Today;
                context.SaveChanges();
            }
        }

        public static void deleteMovie(int mid)
        {
            using (var context = new MovieTheaterEntities())
            {
                Movie mv = context.Movie.Where(s => s.Movie_ID == mid).First();
                mv.Active_Indicator = false;
                context.SaveChanges();
            }
        }
    }
}