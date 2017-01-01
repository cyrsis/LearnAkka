using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStreaming.Message
{
    public class PlayMovieMessage
    {
        public string _movieTitle { get; private set; }
    
        public int _userId { get; private set; }
    

        public PlayMovieMessage(string movieTitle,int userId)
        {
            _movieTitle = movieTitle;
            _userId = userId;
        }
    }
}
