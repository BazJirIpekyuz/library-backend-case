using LibraryManagement.Library.Models;
using System.Linq.Expressions;

namespace LibraryManagement.Library.Helpers
{
    /// <summary>
    /// A builder to build predicate from a search string for searching books.
    /// </summary>
    internal class BookSearchPredicateBuilder
    {
        /// <summary>
        /// Build book search predicate.
        /// </summary>
        /// <param name="keywords">search keywords.</param>
        /// <returns></returns>
        internal static Expression<Func<Book, bool>> Build(List<string> keywords)
        {
            var searchExpression = PredicateBuilder.True<Book>();

            foreach (string keyword in keywords)
            {
                searchExpression = searchExpression.And(p =>
                p.Title.Contains(keyword) ||
                p.Authors.Any(q => q.Contains(keyword)) ||
                p.Publisher.Contains(keyword) ||
                p.PublicationYear.ToString().Contains(keyword));
            }

            return searchExpression;
        }
    }
}
