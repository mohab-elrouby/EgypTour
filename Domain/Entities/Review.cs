using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review
    {
        //proprties
        public int Id { get; private  set; }
        public string Content { get; private set; }

        public float Rating { get; private set; }

        public int ReviwerId { get; private set; }
        public virtual Tourist Reviwer { get; private set; }

        //Constructors
        public Review(string content , float rating  , Tourist writer)
        {
            this.Content = content;
            this.Rating = rating;
            this.Reviwer = writer;
        }
        
        protected Review() { }

        //for entity framework

        //methods
        public void UpdateReview(float newRating,string newContent)
        {
            Rating = newRating;
            Content = newContent;
        }
    }
}
