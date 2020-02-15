using DBEntities;
using DBContext;
using System.Collections.Generic;
using System.Linq;

namespace Provider
{
    public class ReviewCommentProvider : IReviewCommentProvider
    {
        private readonly ReviewCommentContext _dbContext;

        public ReviewCommentProvider(ReviewCommentContext _dbContext)
        {

            this._dbContext = _dbContext;
        }

        public IEnumerable<BookReview> GetBookReviews()
        {
            return _dbContext.BookReview.ToList();
        }

        async public void SaveReviewComment(BookReview bookReview)
        {
            using (var context = new ReviewCommentContext())
            {
                context.Database.EnsureCreated();
                context.Add(bookReview);
                await context.SaveChangesAsync();
            }
            /*_dbContext.BookReview.Add(bookReview);
            _dbContext.SaveChanges();*/
        }
    }
}
