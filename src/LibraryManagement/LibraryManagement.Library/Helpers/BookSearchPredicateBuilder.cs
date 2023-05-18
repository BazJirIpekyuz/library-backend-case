using LibraryManagement.Library.Models;
using LibraryManagement.Library.TextParsers;
using System.Linq.Expressions;

namespace LibraryManagement.Library.Helpers
{
    /// <summary>
    /// A builder to build predicate from a search string for searching books.
    /// </summary>
    internal static class BookSearchPredicateBuilder
    {

        /// <summary>
        /// Build book search predicate.
        /// </summary>
        /// <param name="searchString">search string.</param>
        /// <returns></returns>
        internal static Expression<Func<Book, bool>> Build(string searchString)
        {
            var keywords = SearchStringParser.Parse(searchString);

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
