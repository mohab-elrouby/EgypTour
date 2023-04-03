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
        public string? Content { get; private set; }

        public float Rating { get; private set; }

        public int ReviwerId { get; private set; }
        public DateTime Time { get; private set; }
        public virtual Tourist Reviwer { get; private set; }


        //Constructors
        public Review( float rating  , Tourist writer, string? content = null)
        {
            this.Content = content;
            this.Rating = rating;
            this.Reviwer = writer;
            this.Time = DateTime.Now;
        }
        
        protected Review() { }

        //for entity framework

        //methods
        public void UpdateReview(float newRating,string newContent)
        {
            
            if(newRating>0 && newRating <=5)
            {
                this.Rating = newRating;
            }
            else
            {
                throw new ArgumentOutOfRangeException("rating must be higher than 0 and less thean 5 ");
            }
           
                Content = newContent;
            
          
        }
    }
}
